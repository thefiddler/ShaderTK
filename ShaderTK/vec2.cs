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
        protected partial struct vec2
        {
            public float x, y;

            public vec2(float x, float y)
            {
                this.x = x;
                this.y = y;
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
                        default:
                            throw new ArgumentOutOfRangeException();
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
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }

            public static vec2 operator +(vec2 l, vec2 r)
            {
                throw new NotImplementedException();
            }
        }
    }
}
