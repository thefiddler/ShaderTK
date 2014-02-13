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

namespace ShaderTK
{
    partial class Shader
    {
        internal static class GLSL330
        {
            internal static readonly Dictionary<Type, string> Types =
                new Dictionary<Type, string>()
            {
                { typeof(bool), "bool" },
                { typeof(int), "int" },
                { typeof(float), "float" },
                { typeof(double), "double" },
                { typeof(vec2), "vec2" },
                { typeof(vec3), "vec3" },
                { typeof(vec4), "vec4" },
                //{ typeof(mat3), "mat3" },
                { typeof(mat4), "mat4" },
                { typeof(void), "void" },
            };

            internal static readonly Dictionary<Type, string> Qualifiers =
                new Dictionary<Type, string>()
            {
                { typeof(inputAttribute), "in" },
                { typeof(outputAttribute), "out" },
                { typeof(uniformAttribute), "uniform" },
            };
        }
    }
}