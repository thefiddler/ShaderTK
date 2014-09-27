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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTK
{
    partial class Shader
    {
        protected partial struct vec4
        {
            public float x, y, z, w;

            public vec4(vec3 v)
            {
                throw new NotImplementedException();
            }

            public vec4(vec3 v, float w)
            {
                throw new NotImplementedException();
            }

            public float this[int index]
            {
                get
                {
                    switch (index)
                    {
                        case 0:
                            return x;
                        case 1:
                            return y;
                        case 2:
                            return z;
                        case 3:
                            return w;
                        default:
                            throw new IndexOutOfRangeException();
                    }
                }
                set
                {
                    switch (index)
                    {
                        case 0:
                            x = value;
                            return;
                        case 1:
                            y = value;
                            return;
                        case 2:
                            z = value;
                            return;
                        case 3:
                            w = value;
                            return;
                        default:
                            throw new IndexOutOfRangeException();
                    }
                }
            }

            public static vec4 operator *(vec4 l, vec4 r)
            {
                throw new NotImplementedException();
            }
        }
    }
}
