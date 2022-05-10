using LearnOpenTK.Common;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OpenTK.Graphics.OpenGL4;
using System.Globalization;

namespace ProjectGrafkom
{
    class Mesh
    {
        protected List<Vector3d> vertices = new List<Vector3d>();
        protected List<Vector3d> textureVertices = new List<Vector3d>();
        protected List<Vector3d> normals = new List<Vector3d>();
        protected List<uint> vertexIndices = new List<uint>();
        protected int _vertexBufferObject;
        protected int _elementBufferObject;
        protected int _vertexArrayObject;
        protected Shader _shader;
        protected Matrix4 _model;
        protected Matrix4 transform;
        protected int counter = 0;
        public List<Mesh> child = new List<Mesh>();
        protected Vector3 _Color;
        public List<Vector3> _euler;
        public Vector3 _centerPosition;

        public Mesh() { }
        public void setupObject(string vert, string frag)
        {
            //inisialisasi Transformasi
            _model = Matrix4.Identity;
            //inisialisasi buffer
            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);

            GL.BufferData<Vector3d>(BufferTarget.ArrayBuffer,
                vertices.Count * Vector3d.SizeInBytes,
                vertices.ToArray(),
                BufferUsageHint.StaticDraw);
            //inisialisasi array
            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Double, false, 3 * sizeof(double), 0);
            GL.EnableVertexAttribArray(0);
            //inisialisasi in
            _elementBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer,
                vertexIndices.Count * sizeof(uint),
                vertexIndices.ToArray(), BufferUsageHint.StaticDraw);

            _shader = new Shader(vert, frag);
            _shader.Use();
        }
        public virtual void createvertices(float radiusX, float radiusY, float radiusZ, float _x, float _y, float _z) { }

        public virtual void createvertices(List<Vector3d> points)
        {

        }

        public void createBox(float x, float y, float z, float length)
        {
            Vector3 temp_vector;

            temp_vector.X = x - length / 2.0f;
            temp_vector.Y = y + length / 2.0f;
            temp_vector.Z = z - length / 2.0f;
            vertices.Add(temp_vector);

            temp_vector.X = x + length / 2.0f;
            temp_vector.Y = y + length / 2.0f;
            temp_vector.Z = z - length / 2.0f;
            vertices.Add(temp_vector);

            temp_vector.X = x - length / 2.0f;
            temp_vector.Y = y - length / 2.0f;
            temp_vector.Z = z - length / 2.0f;
            vertices.Add(temp_vector);

            temp_vector.X = x + length / 2.0f;
            temp_vector.Y = y - length / 2.0f;
            temp_vector.Z = z - length / 2.0f;
            vertices.Add(temp_vector);

            temp_vector.X = x - length / 2.0f;
            temp_vector.Y = y + length / 2.0f;
            temp_vector.Z = z + length / 2.0f;
            vertices.Add(temp_vector);

            temp_vector.X = x + length / 2.0f;
            temp_vector.Y = y + length / 2.0f;
            temp_vector.Z = z + length / 2.0f;
            vertices.Add(temp_vector);

            temp_vector.X = x - length / 2.0f;
            temp_vector.Y = y - length / 2.0f;
            temp_vector.Z = z + length / 2.0f;
            vertices.Add(temp_vector);

            temp_vector.X = x + length / 2.0f;
            temp_vector.Y = y - length / 2.0f;
            temp_vector.Z = z + length / 2.0f;
            vertices.Add(temp_vector);

            vertexIndices = new List<uint>
            {
                0,1,2,
                1,2,3,
                0,4,5,
                0,1,5,
                1,3,5,
                3,5,7,
                0,2,4,
                2,4,6,
                4,5,6,
                5,6,7,
                2,3,6,
                3,6,7
            };
        }

        public void createTube(float radiusX, float radiusY, float radiusZ, float _x, float _y, float _z, int sectorCount, int stackCount)
        {
            float pi = (float)Math.PI;
            Vector3 temp_vector;
            float sectorStep = 2 * (float)Math.PI / sectorCount;
            float stackStep = (float)Math.PI / stackCount;
            float sectorAngle, StackAngle, x, y, z;

            for (int i = 0; i <= stackCount; ++i)
            {
                StackAngle = pi / 2 - i * stackStep;
                x = radiusX * (float)Math.Cos(StackAngle);
                y = radiusY * (i / 2);
                z = radiusZ * (float)Math.Cos(StackAngle);

                for (int j = 0; j <= sectorCount; ++j)
                {
                    sectorAngle = j * sectorStep;

                    temp_vector.X = _x + x * (float)Math.Cos(sectorAngle);
                    temp_vector.Y = _y + y;
                    temp_vector.Z = _z + z * (float)Math.Sin(sectorAngle);
                    vertices.Add(temp_vector);
                }
            }

            uint k1, k2;
            for (int i = 0; i < stackCount; ++i)
            {
                k1 = (uint)(i * (sectorCount + 1));
                k2 = (uint)(k1 + sectorCount + 1);
                for (int j = 0; j < sectorCount; ++j, ++k1, ++k2)
                {
                    if (i != 0)
                    {
                        vertexIndices.Add(k1);
                        vertexIndices.Add(k2);
                        vertexIndices.Add(k1 + 1);
                    }
                    if (i != (stackCount - 1))
                    {
                        vertexIndices.Add(k1 + 1);
                        vertexIndices.Add(k2);
                        vertexIndices.Add(k2 + 1);
                    }
                }
            }
        }

        public void createEllips(float radiusX, float radiusY, float radiusZ, float _x, float _y, float _z)
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

        public void createCone(float radiusX, float radiusY, float radiusZ, float _x, float _y, float _z)
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
                for (float v = -pi / 2; v <= 0; v += increament)
                {
                    temp_index++;
                    temp_vector.X = _X + _RadiusX * (float)Math.Cos(u) * v;
                    temp_vector.Y = _Y + _RadiusY * (float)Math.Sin(u) * v;
                    temp_vector.Z = _Z + _RadiusZ * v;
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
        public void createBalok(float x, float y, float z, float length)
        {
            Vector3 temp_vector;

            //TITIK 1
            temp_vector.X = x - length / 2.0f;
            temp_vector.Y = y + length / 2.0f;
            temp_vector.Z = z - length / 6.0f;
            vertices.Add(temp_vector);
            //TITIK 2
            temp_vector.X = x + length / 4.0f;
            temp_vector.Y = y + length / 2.0f;
            temp_vector.Z = z - length / 6.0f;
            vertices.Add(temp_vector);
            //TITIK 3
            temp_vector.X = x - length / 2.0f;
            temp_vector.Y = y - length * 2.0f + 0.15f;
            temp_vector.Z = z - length / 6.0f;
            vertices.Add(temp_vector);
            //TITIK 4
            temp_vector.X = x + length / 4.0f;
            temp_vector.Y = y - length * 2.0f + 0.15f;
            temp_vector.Z = z - length / 6.0f;
            vertices.Add(temp_vector);
            //TITIK 5
            temp_vector.X = x - length / 2.0f;
            temp_vector.Y = y + length / 2.0f;
            temp_vector.Z = z + length / 2.0f;
            vertices.Add(temp_vector);
            //TITIK 6
            temp_vector.X = x + length / 4.0f;
            temp_vector.Y = y + length / 2.0f;
            temp_vector.Z = z + length / 2.0f;
            vertices.Add(temp_vector);
            //TITIK 7
            temp_vector.X = x - length / 2.0f;
            temp_vector.Y = y - length * 2.0f + 0.15f;
            temp_vector.Z = z + length / 2.0f;
            vertices.Add(temp_vector);
            //TITIK 8
            temp_vector.X = x + length / 4.0f;
            temp_vector.Y = y - length * 2.0f + 0.15f;
            temp_vector.Z = z + length / 2.0f;
            vertices.Add(temp_vector);

            vertexIndices = new List<uint>
            {
                //SEGITIGA DEPAN 1
                0,1,2,
                //SEGITIGA DEPAN 2
                1,2,3,
                //SEGITIGA ATAS 1
                0,4,5,
                //SEGITIGA ATAS 2
                0,1,5,
                //SEGITIGA KANAN 1
                1,3,5,
                //SEGITIGA KANAN 2
                3,5,7,
                //SEGITIGA KIRI 1
                0,2,4,
                //SEGITIGA KIRI 2
                2,4,6,
                //SEGITIGA BELAKANG 1
                4,5,6,
                //SEGITIGA BELAKANG 2
                5,6,7,
                //SEGITIGA BAWAH 1
                2,3,6,
                //SEGITIGA BAWAH 2
                3,6,7
            };
        }
        public virtual void render(Camera _cam)
        {
            _shader.Use();
            _shader.SetVector3("Color", _Color);
            _shader.SetMatrix4("model", _model);
            _shader.SetMatrix4("view", _cam.GetViewMatrix());
            _shader.SetMatrix4("projection", _cam.GetProjectionMatrix());
            _shader.SetMatrix4("model", _model);

            GL.BindVertexArray(_vertexArrayObject);
            GL.DrawElements(PrimitiveType.Triangles,
                vertexIndices.Count,
                DrawElementsType.UnsignedInt, 0);

            foreach (var meshobj in child)
            {
                meshobj.render(_cam);
            }
        }

        public virtual void render(PrimitiveType mode = PrimitiveType.TriangleFan)
        {
            _shader.Use();
            _shader.SetMatrix4("model", _model);
            GL.BindVertexArray(_vertexArrayObject);
            GL.DrawElements(mode,
                vertexIndices.Count,
                DrawElementsType.UnsignedInt, 0);

            foreach (var meshobj in child)
            {
                meshobj.render(mode);
            }
        }

        public void setColor(float red = 0.0f, float green = 0.0f, float blue = 0.0f)
        {
            _Color = new Vector3(red, green, blue);
        }


        public void rotate(float x, float y, float z)
        {
            _model = _model * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(y));
            _model = _model * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(x));
            _model = _model * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(z));
            foreach (var meshobj in child)
            {
                meshobj.rotate(x, y, z);
            }
        }

        public void scale(float a)
        {
            _model = _model * Matrix4.CreateScale(a);
        }
        public void translate(float x, float y, float z)
        {
            _model = _model * Matrix4.CreateTranslation(x, y, z);
        }
    }
}