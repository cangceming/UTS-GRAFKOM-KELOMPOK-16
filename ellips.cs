using LearnOpenTK.Common;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OpenTK.Graphics.OpenGL4;

namespace ProjectGrafkom
{
    class ellips : Mesh
    {
        public ellips()
        {
        }

        public override void createvertices(float radiusX, float radiusY, float radiusZ, float _x, float _y, float _z)
        {
            float _X = radiusX;
            float _Y = radiusY;
            float _Z = radiusZ;

            float _RadiusX = _x;
            float _RadiusY = _y;
            float _RadiusZ = _z;
            Vector3 temp_vector = new Vector3();
            float pi = (float)Math.PI;
            int count = 300;
            int temp_index = -1;
            float increament = 2 * pi / count;

            for (float u = -pi; u <= pi + increament; u += increament)
            {
                for (float v = -pi / 2; v <= pi / 2 + increament; v += increament)
                {
                    temp_index++;
                    temp_vector.X = _X + _RadiusX * (float)Math.Cos(v) * (float)Math.Cos(u);
                    temp_vector.Y = _Y + _RadiusY * (float)Math.Cos(v) * (float)Math.Sin(u);
                    temp_vector.Z = _Z + _RadiusZ * (float)Math.Sin(v);
                    vertices.Add(temp_vector);
                    if (u != -pi)
                    {
                        if ((temp_index % count) + 1 < count)
                        {
                            vertexIndices.Add(Convert.ToUInt32(temp_index));
                            vertexIndices.Add(Convert.ToUInt32(temp_index - count));
                            vertexIndices.Add(Convert.ToUInt32(temp_index - count + 1));
                        }
                        if (temp_index % count > 0)
                        {
                            vertexIndices.Add(Convert.ToUInt32(temp_index));
                            vertexIndices.Add(Convert.ToUInt32(temp_index - count));
                            vertexIndices.Add(Convert.ToUInt32(temp_index - 1));
                        }
                    }
                }
                if (u == -pi)
                {
                    count = vertices.Count;
                    Console.WriteLine(count);
                }
            }

        }
    }
}
