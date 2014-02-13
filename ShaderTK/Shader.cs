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
using System.Collections.Generic;
using System.Reflection;

namespace ShaderTK
{
    public abstract partial class Shader
    {
        const BindingFlags flags =
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static;

        internal Shader() { }

        protected abstract void main();

        internal int Version
        {
            get
            {
                return 0;
            }
        }

        internal IEnumerable<FieldInfo> GetUniforms()
        {
            foreach (var field in GetType().GetFields(flags))
            {
                var uniform = field.GetCustomAttributes(typeof(uniformAttribute), true);
                if (uniform != null && uniform.Length > 0)
                    yield return field;
            }
        }

        internal IEnumerable<FieldInfo> GetInputs()
        {
            foreach (var field in GetType().GetFields(flags))
            {
                var input = field.GetCustomAttributes(typeof(inputAttribute), true);
                if (input != null && input.Length > 0)
                    yield return field;
            }
        }

        internal IEnumerable<FieldInfo> GetOutputs()
        {
            foreach (var field in GetType().GetFields(flags))
            {
                var output = field.GetCustomAttributes(typeof(outputAttribute), true);
                if (output != null && output.Length > 0)
                    yield return field;
            }
        }

        internal IEnumerable<Type> GetStructures()
        {
            foreach (var type in GetType().GetNestedTypes(flags))
            {
                yield return type;
            }
        }

        internal IEnumerable<MethodInfo> GetMethods()
        {
            foreach (var method in GetType().GetMethods(flags))
            {
                yield return method;
            }
        }
    }

    public abstract class FragmentShader : Shader
    {
        protected static vec4 texture(sampler1d sampler, float coords)
        {
            throw new NotImplementedException();
        }

        protected static vec4 texture(sampler2d sampler, vec2 coords)
        {
            throw new NotImplementedException();
        }

        protected static vec4 texture(sampler3d sampler, vec3 coords)
        {
            throw new NotImplementedException();
        }

        protected static vec4 texture(samplerCube sampler, vec3 coords)
        {
            throw new NotImplementedException();
        }

        protected static float texture(sampler1dShadow sampler, vec2 coords)
        {
            throw new NotImplementedException();
        }

        protected static float texture(sampler2dShadow sampler, vec3 coords)
        {
            throw new NotImplementedException();
        }
    }
}
