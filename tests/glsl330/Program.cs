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

using ShaderTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glsl330
{
    public class Test
    {
        class TestVS : VertexShader
        {
            struct VertexP3N3T2
            {
                public vec3 Position;
                public vec3 Normal;
                public vec2 Texture;
            }

            [input]
            VertexP3N3T2 Vertex;
            
            [uniform]
            mat4 Modelview = mat4.Identity;

            [output]
            vec2 TexCoord;

            protected override void main()
            {
                TexCoord = Vertex.Texture;
                Position = Modelview * new vec4(Vertex.Position, 0.0f);
            }
        }

        class TestFS : FragmentShader
        {
            [input]
            vec2 TexCoord;

            [uniform(layout = 0)]
            sampler2d DiffuseTexture;
            [uniform(layout = 1)]
            sampler2d NormalTexture;

            [output]
            vec4 Color;

            protected override void main()
            {
                vec4 color = texture(DiffuseTexture, TexCoord);
                vec4 bump = texture(NormalTexture, TexCoord);

                Color = color * bump;
            }
        }

        public static void Main(string[] args)
        {
            var program =
                new ShaderProgram(
                    new TestVS(),
                    new TestFS());

            var sb = new StringBuilder();
            new ShaderCompiler().Compile(new TestVS(), sb);
            Console.WriteLine(sb.ToString());
        }
    }
}
