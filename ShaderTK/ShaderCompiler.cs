// This file is part of ShaderTK.
//
// Copyright (c) 2014 Stefanos Apostolopoulos
//
// ShaderTK is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as
// published by the Free Software Foundation, either version 3 of
// the License, or (at your option) any later version.
//
// ShaderTK is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with ShaderTK.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Reflection;
using System.Text;

namespace ShaderTK
{
    public class ShaderCompiler
    {
        int Indent = 0;

        public ShaderCompiler()
        {
        }

        public void Compile(Shader shader, StringBuilder sb)
        {
            sb.Length = 0;

            if (shader.Version != 0)
            {
                sb.Append("#version ");
                sb.AppendLine(shader.Version.ToString());
            }

            EmitStructures(shader, sb);
            EmitUniforms(shader, sb);
            EmitInputs(shader, sb);
            EmitOutputs(shader, sb);
            EmitMethods(shader, sb);
        }

        #region Private Members

        void EmitIndentation(StringBuilder sb)
        {
            const string space = "    ";
            for (int i = 0; i < Indent; i++)
            {
                sb.Append(space);
            }
        }

        void EmitStructures(Shader shader, StringBuilder sb)
        {
            foreach (var type in shader.GetStructures())
            {
                sb.Append("struct ");
                sb.AppendLine(type.Name);
                sb.AppendLine("{");
                Indent++;
                foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.Instance))
                {
                    ProcessType(field, sb);
                }
                Indent--;
                sb.AppendLine("};");
            }
            sb.AppendLine();
        }

        void EmitUniforms(Shader shader, StringBuilder sb)
        {
            foreach (var uniform in shader.GetUniforms())
            {
                sb.Append("uniform ");
                ProcessType(uniform, sb);
            }
            sb.AppendLine();
        }

        void EmitInputs(Shader shader, StringBuilder sb)
        {
            foreach (var input in shader.GetInputs())
            {
                sb.Append("in ");
                ProcessType(input, sb);
            }
            sb.AppendLine();
        }

        void EmitOutputs(Shader shader, StringBuilder sb)
        {
            foreach (var output in shader.GetOutputs())
            {
                sb.Append("out ");
                ProcessType(output, sb);
            }
            sb.AppendLine();
        }

        void EmitMethods(Shader shader, StringBuilder sb)
        {
            var shader_type = shader.GetType();
            foreach (var method in shader.GetMethods())
            {
                if (method.DeclaringType != shader_type)
                    continue;

                sb.Append(Shader.GLSL330.Types[method.ReturnType]);
                sb.Append(" ");
                sb.Append(method.Name);

                sb.Append("(");
                bool has_parameters = false;
                foreach (var parameter in method.GetParameters())
                {
                    has_parameters = true;
                    ProcessParameter(parameter, sb);
                    sb.Append(", ");
                }

                if (has_parameters)
                {
                    // remove comma from last parameter
                    sb.Remove(sb.Length - 2, 2);
                }
                else
                {
                    // empty parameter lists require "void"
                    sb.Append(Shader.GLSL330.Types[typeof(void)]);
                }
                sb.AppendLine(")");

                sb.AppendLine("{");
                Indent++;
                Indent--;
                sb.AppendLine("}");
                sb.AppendLine();
            }
        }

        void ProcessType(FieldInfo field, StringBuilder sb)
        {
            EmitIndentation(sb);
            sb.Append(field.FieldType.Name);
            sb.Append(" ");
            sb.Append(field.Name);
            sb.AppendLine(";");
        }

        void ProcessParameter(ParameterInfo parameter, StringBuilder sb)
        {
            sb.Append(parameter.IsIn ? "in " : "out ");
            sb.Append(Shader.GLSL330.Types[parameter.ParameterType]);
            sb.Append(" ");
            sb.Append(parameter.Name);
        }

        #endregion
    }
}

