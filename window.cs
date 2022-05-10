using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL4;
using LearnOpenTK.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;
using ProjectGrafkom;

namespace ProjectGrafkom
{

    internal class window : GameWindow
    {
        protected List<Vector3d> mouth = new List<Vector3d>();
        protected List<Vector3d> mouth2 = new List<Vector3d>();

        string shader_vert = "../../../Shaders/shader.vert";
        string shader_frag = "../../../Shaders/shader.frag";

        Camera _camera;
        bool _firstMove = true;
        Vector2 _lastPos;

        List<Mesh> asset = new List<Mesh>();
        List<Curve> asset_curve = new List<Curve>();
        List<Mesh> Stuff3d = new List<Mesh>();
        List<Curve> Stuff3d_Curve = new List<Curve>();
        List<Curve> stuff_kurva = new List<Curve>();
        List<Mesh> A3d = new List<Mesh>();
        List<Mesh> alas = new List<Mesh>();
        List<Mesh> Batang = new List<Mesh>();
        List<Mesh> Daun = new List<Mesh>();
        List<Mesh> KakiKiri = new List<Mesh>();
        List<Mesh> KakiKanan = new List<Mesh>();
        List<Mesh> Payung = new List<Mesh>();
        List<Mesh> Matahari = new List<Mesh>();
        List<Mesh> Awan = new List<Mesh>();
        Mesh temp;
        int temp_count = 0;

        private int count = 0;

        public window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {

        }

        protected override void OnLoad()
        {
            _camera = new Camera(Vector3.UnitZ * 3, Size.X / (float)Size.Y);
            CursorGrabbed = true;

            //Untuk background
            GL.ClearColor(0.5f, 0.8f, 0.8f, 0);
            {
            }
            {
                //Enviroment tanah
                temp = new Mesh();
                temp.createEllips(0.15f, 0.65f, 0.0f, 10f, 0.1f, 10f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.8f, 0.9f, 0f);
                alas.Add(temp);

                //Matahari
                temp = new Mesh();
                //kanan kiri(-kiri +kanan), atas bawah(-bawah +atas), depan belakang (-belakang +depan)
                temp.createEllips(-10.0f, 9.0f, -17.0f, 1.0f, 0.9f, 1.0f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(1.0f, 1.0f, 0.7f);
                Matahari.Add(temp);

                //AWAN
                //kanan kiri(-kiri +kanan), atas bawah(-bawah +atas), depan belakang (-belakang +depan)
                //Awan 1
                temp = new Mesh();
                temp.createEllips(-18.0f, 7.5f, -15.5f, 0.6f, 0.4f, 0.6f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(1.0f, 1.0f, 0.9f);
                Awan.Add(temp);
                //2
                temp = new Mesh();
                temp.createEllips(-17.3f, 7.5f, -15.5f, 0.7f, 0.6f, 0.7f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(1.0f, 1.0f, 0.9f);
                Awan.Add(temp);
                //3
                temp = new Mesh();
                temp.createEllips(-16.6f, 7.5f, -15.5f, 0.6f, 0.4f, 0.6f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(1.0f, 1.0f, 0.9f);
                Awan.Add(temp);
                //kanan kiri(-kiri +kanan), atas bawah(-bawah +atas), depan belakang (-belakang +depan)
                //1.2
                temp = new Mesh();
                temp.createEllips(16.0f, 7.0f, -15.5f, 0.6f, 0.4f, 0.6f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(1.0f, 1.0f, 0.9f);
                Awan.Add(temp);
                //2.2
                temp = new Mesh();
                temp.createEllips(15.3f, 7.0f, -15.5f, 0.7f, 0.6f, 0.7f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(1.0f, 1.0f, 0.9f);
                Awan.Add(temp);
                //3.2
                temp = new Mesh();
                temp.createEllips(14.6f, 7.0f, -15.5f, 0.6f, 0.4f, 0.6f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(1.0f, 1.0f, 0.9f);
                Awan.Add(temp);
                //kanan kiri(-kiri +kanan), atas bawah(-bawah +atas), depan belakang (-belakang +depan)
                //1.3
                temp = new Mesh();
                temp.createEllips(5.0f, 11.0f, -15.5f, 0.6f, 0.4f, 0.6f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(1.0f, 1.0f, 0.9f);
                Awan.Add(temp);
                //2.3
                temp = new Mesh();
                temp.createEllips(4.3f, 11.0f, -15.5f, 0.7f, 0.6f, 0.7f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(1.0f, 1.0f, 0.9f);
                Awan.Add(temp);
                //3.3
                temp = new Mesh();
                temp.createEllips(3.6f, 11.0f, -15.5f, 0.6f, 0.4f, 0.6f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(1.0f, 1.0f, 0.9f);
                Awan.Add(temp);

                //1.4
                temp = new Mesh();
                temp.createEllips(-3.0f, 5.6f, -15.5f, 0.6f, 0.4f, 0.6f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(1.0f, 1.0f, 0.9f);
                Awan.Add(temp);
                //2.4
                temp = new Mesh();
                temp.createEllips(-2.3f, 5.6f, -15.5f, 0.7f, 0.6f, 0.7f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(1.0f, 1.0f, 0.9f);
                Awan.Add(temp);
                //3.4
                temp = new Mesh();
                temp.createEllips(-1.6f, 5.6f, -15.5f, 0.6f, 0.4f, 0.6f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(1.0f, 1.0f, 0.9f);
                Awan.Add(temp);

                //kanan kiri(-kiri +kanan), atas bawah(-bawah +atas), depan belakang (-belakang +depan)
                //1.5
                temp = new Mesh();
                temp.createEllips(-22.0f, 4.5f, -10.5f, 0.6f, 0.4f, 0.6f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(1.0f, 1.0f, 0.9f);
                Awan.Add(temp);
                //2.5
                temp = new Mesh();
                temp.createEllips(-21.3f, 4.5f, -10.5f, 0.7f, 0.6f, 0.7f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(1.0f, 1.0f, 0.9f);
                Awan.Add(temp);
                //3.5
                temp = new Mesh();
                temp.createEllips(-20.6f, 4.5f, -10.5f, 0.6f, 0.4f, 0.6f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(1.0f, 1.0f, 0.9f);
                Awan.Add(temp);

                //Enviroment Pohon
                //Pohon 1
                temp = new Mesh();
                temp.createBalok(-7.0f, -0.15f, 0.0f, 1.5f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.6f, 0.3f, 0f);
                Batang.Add(temp);

                temp = new Mesh(); //lAPISAN 1
                temp.createCone(0.0f, 0.0f, 0.50f, 0.85f, 0.85f, 0.90f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0f, 0.9f, 0f);
                temp.rotate(90f, -30f, 25f);
                temp.translate(-7.25f, -3.45f, 0.25f);
                Daun.Add(temp);

                temp = new Mesh(); //lAPISAN 2
                temp.createCone(0.0f, 0.0f, 0.50f, 0.85f, 0.85f, 0.90f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0f, 0.7f, 0.2f);
                temp.rotate(90f, -30f, 25f);
                temp.translate(-7.25f, -3.95f, 0.25f);
                Daun.Add(temp);

                temp = new Mesh(); //lAPISAN 3
                temp.createCone(0.0f, 0.0f, 0.50f, 0.85f, 0.85f, 0.90f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0f, 0.4f, 0.1f);
                temp.rotate(90f, -30f, 25f);
                temp.translate(-7.25f, -4.35f, 0.25f);
                Daun.Add(temp);

                //Pohon 2
                temp = new Mesh();
                temp.createBalok(-0.0f, -0.15f, 6.45f, 1.5f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.6f, 0.3f, 0f);
                Batang.Add(temp);

                temp = new Mesh(); //lAPISAN 1
                temp.createCone(0.0f, 0.0f, 0.0f, 0.85f, 0.85f, 0.90f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0f, 0.9f, 0f);
                temp.rotate(90f, -30f, 25f);
                temp.translate(-0.30f, -4.0f, 6.65f);
                Daun.Add(temp);

                temp = new Mesh(); //lAPISAN 2
                temp.createCone(0.0f, 0.0f, 0.50f, 0.85f, 0.85f, 0.90f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0f, 0.7f, 0.2f);
                temp.rotate(90f, -30f, 25f);
                temp.translate(-0.30f, -4.0f, 6.65f);
                Daun.Add(temp);

                temp = new Mesh(); //lAPISAN 3
                temp.createCone(0.0f, 0.0f, 0.50f, 0.85f, 0.85f, 0.90f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0f, 0.4f, 0.1f);
                temp.rotate(90f, -30f, 25f);
                temp.translate(-0.30f, -4.50f, 6.65f);
                Daun.Add(temp);

                //pohon 3
                temp = new Mesh();
                temp.createBalok(-5f, -0.15f, 4.0f, 1.5f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.6f, 0.3f, 0f);
                Batang.Add(temp);

                temp = new Mesh(); //lAPISAN 1
                temp.createCone(0.0f, 0.0f, 0.0f, 0.85f, 0.85f, 0.90f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0f, 0.9f, 0f);
                temp.rotate(90f, -30f, 25f);
                temp.translate(-5.25f, -4.0f, 4.25f);
                Daun.Add(temp);

                temp = new Mesh(); //lAPISAN 2
                temp.createCone(0.0f, 0.0f, 0.50f, 0.85f, 0.85f, 0.90f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0f, 0.7f, 0.2f);
                temp.rotate(90f, -30f, 25f);
                temp.translate(-5.25f, -4.0f, 4.25f);
                Daun.Add(temp);

                temp = new Mesh(); //lAPISAN 3
                temp.createCone(0.0f, 0.0f, 0.50f, 0.85f, 0.85f, 0.90f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0f, 0.4f, 0.1f);
                temp.rotate(90f, -30f, 25f);
                temp.translate(-5.25f, -4.50f, 4.25f);
                Daun.Add(temp);

                //pohon 4
                temp = new Mesh();
                temp.createBalok(9f, -0.15f, 2.0f, 1.5f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.6f, 0.3f, 0f);
                Batang.Add(temp);

                temp = new Mesh(); //lAPISAN 1
                temp.createCone(0.0f, 0.0f, 0.0f, 0.85f, 0.85f, 0.90f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0f, 0.9f, 0f);
                temp.rotate(90f, -30f, 25f);
                temp.translate(8.75f, -4.0f, 2.25f);
                Daun.Add(temp);

                temp = new Mesh(); //lAPISAN 2
                temp.createCone(0.0f, 0.0f, 0.50f, 0.85f, 0.85f, 0.90f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0f, 0.7f, 0.2f);
                temp.rotate(90f, -30f, 25f);
                temp.translate(8.75f, -4.0f, 2.25f);
                Daun.Add(temp);

                temp = new Mesh(); //lAPISAN 3
                temp.createCone(0.0f, 0.0f, 0.50f, 0.85f, 0.85f, 0.90f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0f, 0.4f, 0.1f);
                temp.rotate(90f, -30f, 25f);
                temp.translate(8.75f, -4.50f, 2.25f);
                Daun.Add(temp);

                //Pohon 5
                temp = new Mesh();
                temp.createBalok(7f, 0.50f, 4.0f, 1.5f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.6f, 0.3f, 0f);
                Batang.Add(temp);

                temp = new Mesh(); //lAPISAN 1
                temp.createCone(0.0f, 0.0f, 0.0f, 0.85f, 0.85f, 0.90f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0f, 0.9f, 0f);
                temp.rotate(90f, -30f, 25f);
                temp.translate(6.70f, -3.25f, 4.25f);
                Daun.Add(temp);

                temp = new Mesh(); //lAPISAN 2
                temp.createCone(0.0f, 0.0f, 0.50f, 0.85f, 0.85f, 0.90f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0f, 0.7f, 0.2f);
                temp.rotate(90f, -30f, 25f);
                temp.translate(6.70f, -3.25f, 4.25f);
                Daun.Add(temp);

                temp = new Mesh(); //lAPISAN 3
                temp.createCone(0.0f, 0.0f, 0.50f, 0.85f, 0.85f, 0.90f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0f, 0.4f, 0.1f);
                temp.rotate(90f, -30f, 25f);
                temp.translate(6.70f, -3.75f, 4.25f);
                Daun.Add(temp);

                //Pohon 6
                temp = new Mesh();
                temp.createBalok(-3.75f, 0.50f, 7.0f, 1.5f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.6f, 0.3f, 0f);
                Batang.Add(temp);

                temp = new Mesh(); //lAPISAN 1
                temp.createCone(0.0f, 0.0f, 0.0f, 0.85f, 0.85f, 0.90f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0f, 0.9f, 0f);
                temp.rotate(90f, -30f, 25f);
                temp.translate(-4.0f, -3.25f, 7.25f);
                Daun.Add(temp);

                temp = new Mesh(); //lAPISAN 2
                temp.createCone(0.0f, 0.0f, 0.50f, 0.85f, 0.85f, 0.90f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0f, 0.7f, 0.2f);
                temp.rotate(90f, -30f, 25f);
                temp.translate(-4.0f, -3.25f, 7.25f);
                Daun.Add(temp);

                temp = new Mesh(); //lAPISAN 3
                temp.createCone(0.0f, 0.0f, 0.50f, 0.85f, 0.85f, 0.90f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0f, 0.4f, 0.1f);
                temp.rotate(90f, -30f, 25f);
                temp.translate(-4.0f, -3.75f, 7.25f);
                Daun.Add(temp);

                //Pohon 7
                temp = new Mesh();
                temp.createBalok(3.75f, 0.95f, 6.50f, 1.5f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.6f, 0.3f, 0f);
                Batang.Add(temp);

                temp = new Mesh(); //lAPISAN 1
                temp.createCone(0.0f, 0.0f, 0.0f, 0.85f, 0.85f, 0.90f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0f, 0.9f, 0f);
                temp.rotate(90f, -30f, 25f);
                temp.translate(3.45f, -3.15f, 6.75f);
                Daun.Add(temp);

                temp = new Mesh(); //lAPISAN 2
                temp.createCone(0.0f, 0.0f, 0.50f, 0.85f, 0.85f, 0.90f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0f, 0.7f, 0.2f);
                temp.rotate(90f, -30f, 25f);
                temp.translate(3.45f, -3.15f, 6.75f);
                Daun.Add(temp);

                temp = new Mesh(); //lAPISAN 3
                temp.createCone(0.0f, 0.0f, 0.50f, 0.85f, 0.85f, 0.90f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0f, 0.4f, 0.1f);
                temp.rotate(90f, -30f, 25f);
                temp.translate(3.45f, -3.65f, 6.75f);
                Daun.Add(temp);

                //Pohon 8
                temp = new Mesh();
                temp.createBalok(-7.90f, 0.95f, 3.25f, 1.5f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.6f, 0.3f, 0f);
                Batang.Add(temp);

                temp = new Mesh(); //lAPISAN 1
                temp.createCone(0.0f, 0.0f, 0.0f, 0.85f, 0.85f, 0.90f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0f, 0.9f, 0f);
                temp.rotate(90f, -30f, 25f);
                temp.translate(-8.25f, -3.15f, 3.50f);
                Daun.Add(temp);

                temp = new Mesh(); //lAPISAN 2
                temp.createCone(0.0f, 0.0f, 0.50f, 0.85f, 0.85f, 0.90f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0f, 0.7f, 0.2f);
                temp.rotate(90f, -30f, 25f);
                temp.translate(-8.25f, -3.15f, 3.50f);
                Daun.Add(temp);

                temp = new Mesh(); //lAPISAN 3
                temp.createCone(0.0f, 0.0f, 0.50f, 0.85f, 0.85f, 0.90f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0f, 0.4f, 0.1f);
                temp.rotate(90f, -30f, 25f);
                temp.translate(-8.25f, -3.55f, 3.50f);
                Daun.Add(temp);

                //Kepala
                temp = new Mesh();
                temp.createCone(0.15f, 0.0f, 0.55f, 0.5f, 0.4f, 0.5f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.9f, 0.5f, 0.1f);
                temp.rotate(90f, 0.0f, 0.0f);
                asset.Add(temp);

                //Badan
                temp = new Mesh();
                temp.createBox(0.0f, 0.8f, 0.0f, 1.2f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.9f, 0.5f, 0.1f);
                asset.Add(temp);

                //Hidung
                temp = new Mesh();
                temp.createEllips(0.0f, -0.25f, -0.45f, 0.07f, 0.07f, 0.07f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(1.0f, 0.5f, 0.8f);
                temp.rotate(0.0f, 90f, -25f);
                asset.Add(temp);

                //Mata
                temp = new Mesh();
                temp.createEllips(-0.15f, 0.15f, -0.35f, 0.15f, 0.15f, 0.15f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(1.0f, 1.0f, 1.0f);
                temp.rotate(0.05f, 90f, 50f);
                asset.Add(temp);
                temp = new Mesh();
                temp.createEllips(0.15f, 0.15f, -0.35f, 0.15f, 0.15f, 0.15f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(1.0f, 1.0f, 1.0f);
                temp.rotate(0.05f, 90f, 50f);
                asset.Add(temp);

                //Retina
                temp = new Mesh();
                temp.createEllips(-0.225f, 0.225f, -0.45f, 0.08f, 0.02f, 0.02f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.0f, 0.0f, 0.0f);
                temp.rotate(90f, 35f, 50f);
                asset.Add(temp);
                temp = new Mesh();
                temp.createEllips(-0.225f, -0.225f, -0.45f, 0.08f, 0.02f, 0.02f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.0f, 0.0f, 0.0f);
                temp.rotate(90f, 35f, 50f);
                asset.Add(temp);

                //Ekor
                temp = new Mesh();
                temp.createEllips(1.2f, 1.0f, 0.0f, 0.8f, 0.175f, 0.175f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(1.0f, 1.0f, 1.0f);
                asset.Add(temp);

                //Kaki kiri
                temp = new Mesh();
                temp.createEllips(-0.35f, 1.0f, 0.0f, 0.25f, 0.8f, 0.15f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(1.0f, 1.0f, 1.0f);
                temp.rotate(0.0f, 300f, 0.0f);
                asset.Add(temp);

                //Kaki kanan
                temp = new Mesh();
                temp.createEllips(0.35f, 1.0f, 0.0f, 0.25f, 0.8f, 0.15f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(1.0f, 1.0f, 1.0f);
                temp.rotate(0.0f, 235f, 0.0f);
                asset.Add(temp);

                //Tangan kanan
                temp = new Mesh();
                temp.createEllips(0.0f, -0.2f, -0.9f, 0.2f, 0.2f, 0.8f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(1.0f, 1.0f, 1.0f);
                temp.rotate(60f, 0.0f, 0.0f);
                asset.Add(temp);

                //Tangan kiri
                temp = new Mesh();
                temp.createEllips(0.0f, -0.2f, 0.9f, 0.2f, 0.2f, 0.8f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(1.0f, 1.0f, 1.0f);
                temp.rotate(-60f, 0.0f, 0.0f);
                asset.Add(temp);

                // Telinga
                temp = new Mesh();
                temp.createCone(0.05f, 0.0f, 0.55f, 0.15f, 0.15f, 0.25f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.9f, 0.5f, 0.1f);
                temp.rotate(60f, -30f, 25f);
                asset.Add(temp);
                temp = new Mesh();
                temp.createCone(0.05f, 0.0f, 0.55f, 0.15f, 0.15f, 0.25f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.9f, 0.5f, 0.1f);
                temp.rotate(120f, -30f, 25f);
                asset.Add(temp);

                //Mulut
                mouth.Add(new Vector3d(0.07, 0.1, 0.0));
                mouth.Add(new Vector3d(0.1, -0.008, 0.0));
                mouth.Add(new Vector3d(0.0, -0.035, 0.0));
                mouth.Add(new Vector3d(-0.1, -0.008, 0.0));
                mouth.Add(new Vector3d(-0.07, 0.1, 0.0));
                Curve Kurva = new Curve();
                Kurva.createvertices(mouth);
                Kurva.setupObject(shader_vert, shader_frag);
                Kurva.setColor(1.0f, 1.0f, 1.0f);
                asset_curve.Add(Kurva);
                mouth2.Add(new Vector3d(0.07, 0.1, 0.0));
                mouth2.Add(new Vector3d(0.1, -0.008, 0.0));
                mouth2.Add(new Vector3d(0.0, -0.035, 0.0));
                mouth2.Add(new Vector3d(-0.1, -0.008, 0.0));
                mouth2.Add(new Vector3d(-0.07, 0.1, 0.0));
                Kurva = new Curve();
                Kurva.createvertices(mouth2);
                Kurva.setupObject(shader_vert, shader_frag);
                Kurva.setColor(1.0f, 1.0f, 1.0f);
                asset_curve.Add(Kurva);


                //Object Kucing 
                //Kepala 
                temp = new Mesh();
                temp.createEllips(0.0f, 0.0f, 0.0f, 0.5f, 0.4f, 0.5f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.690f, 0.611f, 0.611f);
                Stuff3d.Add(temp);

                //Badan
                temp = new Mesh();
                temp.createEllips(0.0f, 0.855f, 0.00f, 0.55f, 0.55f, 0.20f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.8f, 1f, 0.9f);
                Stuff3d.Add(temp);

                //Hidung
                temp = new Mesh();
                temp.createEllips(0.0f, -0.25f, -0.45f, 0.07f, 0.07f, 0.07f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.7f, 0.5f, 0.3f);
                temp.rotate(0.0f, 90f, -25f);
                Stuff3d.Add(temp);

                //Mata kiri
                temp = new Mesh();
                temp.createEllips(-0.15f, 0.15f, -0.35f, 0.15f, 0.15f, 0.15f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0f, 0f, 0f);
                temp.rotate(0.05f, 90f, 50f);
                Stuff3d.Add(temp);

                //Mata kanan
                temp = new Mesh();
                temp.createEllips(0.15f, 0.15f, -0.35f, 0.15f, 0.15f, 0.15f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0f, 0f, 0f);
                temp.rotate(0.05f, 90f, 50f);
                Stuff3d.Add(temp);

                //Mata putih (kiri)
                temp = new Mesh();
                temp.createEllips(-0.225f, 0.225f, -0.45f, 0.035f, 0.035f, 0.035f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.439f, 0.858f, 0.984f);
                temp.rotate(10f, 80f, 50f);
                Stuff3d.Add(temp);

                // Mata putih (kanan)
                temp = new Mesh();
                temp.createEllips(0.225f, 0.225f, -0.45f, 0.035f, 0.035f, 0.035f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.439f, 0.858f, 0.984f);
                temp.rotate(0.05f, 90f, 50f);
                Stuff3d.Add(temp);

                //Ekor
                temp = new Mesh();
                temp.createEllips(1.2f, 0.2f, -0.2f, 0.175f, 0.175f, 0.175f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.7f, 0.5f, 0.3f);
                temp.rotate(45f, 0.0f, 45f);
                Stuff3d.Add(temp);

                //Kaki kiri
                temp = new ellips();
                temp.createvertices(-0.1f, 0.9f, 0.5f, 0.25f, 0.3f, 0.15f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.7f, 0.5f, 0.3f);
                temp.rotate(0.0f, 0f, 0.0f);
                temp.translate(0.0f, 0.35f, 4.70f);
                KakiKiri.Add(temp);

                //Kaki kanan
                temp = new ellips();
                temp.createvertices(0.1f, 0.9f, 0.5f, 0.25f, 0.3f, 0.15f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.7f, 0.5f, 0.3f);
                temp.rotate(0.0f, 0f, 0.0f);
                temp.translate(-0.2f, 0.35f, 4.30f);
                KakiKanan.Add(temp);

                //Tangan kanan
                temp = new Mesh();
                temp.createEllips(0.0f, -0.0f, -0.70f, 0.2f, 0.2f, 0.2f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.7f, 0.5f, 0.3f);
                temp.rotate(60f, 0.0f, 0.0f);
                Stuff3d.Add(temp);

                //Tangan kiri
                temp = new Mesh();
                temp.createEllips(0.0f, -0.0f, 0.70f, 0.2f, 0.2f, 0.2f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.7f, 0.5f, 0.3f);
                temp.rotate(-60f, 0.0f, 0.0f);
                Stuff3d.Add(temp);

                //TELINGA KIRI
                temp = new Mesh();
                temp.createCone(0.05f, 0.0f, 0.55f, 0.15f, 0.15f, 0.15f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.7f, 0.5f, 0.3f);
                temp.rotate(60f, 0.0f, 0.0f);
                Stuff3d.Add(temp);

                //TELINGA KANAN
                temp = new Mesh();
                temp.createCone(0.05f, 0.0f, 0.55f, 0.15f, 0.15f, 0.15f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.7f, 0.5f, 0.3f);
                temp.rotate(120f, 0.0f, 0.0f);
                Stuff3d.Add(temp);

                mouth.Clear();
                mouth2.Clear();
                //Mulut kanan
                mouth.Add(new Vector3d(0.07, 0.1, 0.0));
                mouth.Add(new Vector3d(0.1, -0.008, 0.0));
                mouth.Add(new Vector3d(0.0, -0.035, 0.0));
                mouth.Add(new Vector3d(-0.1, -0.008, 0.0));
                mouth.Add(new Vector3d(-0.07, 0.1, 0.0));
                Kurva = new Curve();
                Kurva.createvertices(mouth);
                Kurva.setupObject(shader_vert, shader_frag);
                Kurva.setColor(0.5f, 0.3f, 0.3f);
                Stuff3d_Curve.Add(Kurva);

                //Mulut kiri
                mouth2.Add(new Vector3d(0.07, 0.1, 0.0));
                mouth2.Add(new Vector3d(0.1, -0.008, 0.0));
                mouth2.Add(new Vector3d(0.0, -0.035, 0.0));
                mouth2.Add(new Vector3d(-0.1, -0.008, 0.0));
                mouth2.Add(new Vector3d(-0.07, 0.1, 0.0));
                Kurva = new Curve();
                Kurva.createvertices(mouth2);
                Kurva.setupObject(shader_vert, shader_frag);
                Kurva.setColor(0.5f, 0.3f, 0.3f);
                Stuff3d_Curve.Add(Kurva);

                //Tongkat payung
                temp = new Mesh();
                //lebar belakang, lebar kesamping, panjang pendek(makin besar angkanya makin panjang)
                temp.createTube(0.03f, 0.05f, 0.57f, -0.05f, 1.0f, 0.0f, 60, 3);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.3f, 0.4f, 0.5f);
                temp.rotate(-70f, 0.0f, -10.0f);
                Payung.Add(temp);

                //Tudung payung
                temp = new Mesh();
                temp.createCone(0.0f, -0.99f, -0.040f, 0.39f, 0.39f, 0.30f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(1.0f, 0.4f, 0.4f);
                temp.rotate(90f, 0.0f, 0.0f);
                temp.translate(-0.0f, -0.4f, 0.0f);//depn blkg, atas bawah,
                Payung.Add(temp);

                //kepala 
                temp = new Mesh();
                temp.createEllips(0.0f, 0.0f, 0.0f, 0.4f, 0.3f, 0.4f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(1.0f, 0.8f, 0.8f);
                A3d.Add(temp);

                //dress kucing
                temp = new Mesh();
                temp.createCone(0.0f, -0.05f, 0.0f, 0.55f, 0.55f, 0.60f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.7f, 0.9f, 1.0f);
                temp.rotate(90f, 0.0f, 0.0f);
                A3d.Add(temp);

                //hidung
                temp = new Mesh();
                temp.createEllips(0.0f, -0.13f, -0.40f, 0.03f, 0.03f, 0.03f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.7f, 0.5f, 0.4f);
                temp.rotate(0.0f, 90f, -25f);
                A3d.Add(temp);

                //mata kiri
                temp = new Mesh();
                temp.createEllips(-0.15f, 0.15f, -0.25f, 0.10f, 0.10f, 0.10f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.7f, 0.5f, 0.4f);
                temp.rotate(0.05f, 90f, 50f);
                A3d.Add(temp);

                //mata kanan
                temp = new Mesh();
                temp.createEllips(0.15f, 0.15f, -0.25f, 0.10f, 0.10f, 0.10f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.7f, 0.5f, 0.4f);
                temp.rotate(0.05f, 90f, 50f);
                A3d.Add(temp);

                //pupil kiri
                temp = new Mesh();
                temp.createEllips(-0.225f, 0.25f, -0.30f, 0.025f, 0.025f, 0.045f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.5f, 1.0f, 1.0f);
                temp.rotate(0.05f, 90f, 50f);
                A3d.Add(temp);

                //pupil kanan
                temp = new Mesh();
                temp.createEllips(0.225f, 0.25f, -0.30f, 0.025f, 0.025f, 0.045f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.5f, 1.0f, 1.0f);
                temp.rotate(0.05f, 90f, 50f);
                A3d.Add(temp);

                //Ekor
                temp = new Mesh();
                temp.createEllips(0.9f, 0.10f, -0.01f, 0.15f, 0.15f, 0.15f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(1.0f, 0.8f, 0.8f);
                temp.rotate(45f, 0.0f, 45f);
                A3d.Add(temp);

                //Kaki kiri
                temp = new Mesh();
                temp.createEllips(-0.3f, 0.9f, 0.100f, 0.11f, 0.48f, 0.15f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(1.0f, 0.8f, 0.8f);
                temp.rotate(0.0f, 300f, 0.0f);
                A3d.Add(temp);

                //Kaki kanan
                temp = new Mesh();
                temp.createEllips(0.3f, 0.9f, 0.100f, 0.11f, 0.48f, 0.15f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(1.0f, 0.8f, 0.8f);
                temp.rotate(0.0f, 235f, 0.0f);
                A3d.Add(temp);

                //tangan bagian kanan
                temp = new Mesh();
                temp.createEllips(0.0f, -0.25f, -0.75f, 0.075f, 0.4f, 0.08f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(1.0f, 0.8f, 0.8f);
                temp.rotate(60f, 0.0f, 0.0f);
                A3d.Add(temp);

                //tangan bagian kiri
                temp = new Mesh();
                temp.createEllips(0.0f, -0.19f, 0.75f, 0.075f, 0.4f, 0.08f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(1.0f, 0.8f, 0.8f);
                temp.rotate(-60f, 0.0f, 0.0f);
                A3d.Add(temp);

                // TELINGA KIRI
                temp = new Mesh();
                temp.createCone(0.05f, 0.0f, 0.48f, 0.15f, 0.15f, 0.20f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.8f, 0.6f, 1.0f);
                temp.rotate(60f, 0.0f, 0.0f);
                A3d.Add(temp);

                // TELINGA KANAN
                temp = new Mesh();
                temp.createCone(0.05f, 0.0f, 0.48f, 0.15f, 0.15f, 0.20f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.8f, 0.6f, 1.0f);
                temp.rotate(120f, 0.0f, 0.0f);
                A3d.Add(temp);

                mouth.Clear();
                mouth2.Clear();
                //Kumis kanan 
                mouth.Add(new Vector3d(0.50, 0.55, 0.0));
                mouth.Add(new Vector3d(0.48, 0.42, 0.0));
                mouth.Add(new Vector3d(0.0, 0.35, 0.0));
                mouth.Add(new Vector3d(0.15, 0.35, 0.0));
                mouth.Add(new Vector3d(0.07, 0.35, 0.0));
                Kurva = new Curve();
                Kurva.createvertices(mouth);
                Kurva.setupObject(shader_vert, shader_frag);
                Kurva.setColor(0.5f, 0.3f, 0.3f);
                stuff_kurva.Add(Kurva);
                //Kumis kiri 
                mouth2.Add(new Vector3d(-0.50, 0.55, 0.0));
                mouth2.Add(new Vector3d(-0.48, 0.42, 0.0));
                mouth2.Add(new Vector3d(-0.0, 0.35, 0.0));
                mouth2.Add(new Vector3d(-0.15, 0.35, 0.0));
                mouth2.Add(new Vector3d(-0.07, 0.35, 0.0));
                Kurva = new Curve();
                Kurva.createvertices(mouth2);
                Kurva.setupObject(shader_vert, shader_frag);
                Kurva.setColor(0.5f, 0.3f, 0.3f);
                stuff_kurva.Add(Kurva);
            }
            for (int i = 0; i < alas.Count; i++)
            {
                alas[i].rotate(180.0f, 0.0f, 0.0f);
                alas[i].translate(0.0f, -1.0f, 0.0f);
            }
            for (int i = 0; i < Batang.Count; i++)
            {
                Batang[i].rotate(180.0f, 0.0f, 0.0f);
                Batang[i].translate(0.0f, -1.0f, 0.0f);
            }
            for (int i = 0; i < Daun.Count; i++)
            {
                Daun[i].rotate(180.0f, 0.0f, 0.0f);
                Daun[i].translate(0.0f, -1.0f, 0.0f);
            }
            for (int i = 0; i < Payung.Count; i++)
            {
                Payung[i].rotate(180.0f, -90.0f, 0.0f);
                Payung[i].translate(2.5f, 0.0f, 0.0f);
            }
            for (int i = 0; i < asset.Count; i++)
            {
                asset[i].rotate(180.0f, -90.0f, 0.0f);
                asset[i].translate(5.0f, 0.0f, 0.0f);
            }
            for (int i = 0; i < KakiKiri.Count; i++)
            {
                KakiKiri[i].rotate(180.0f, -90.0f, 0.0f);
                KakiKiri[i].translate(5.0f, 0.0f, 0.0f);
            }
            for (int i = 0; i < KakiKanan.Count; i++)
            {
                KakiKanan[i].rotate(180.0f, -90.0f, 0.0f);
                KakiKanan[i].translate(5.0f, 0.0f, 0.0f);
            }
            for (int i = 0; i < asset_curve.Count; i++)
            {
                asset_curve[0].translate(0.04f, -0.05f, 0.25f);
                asset_curve[1].translate(-0.04f, -0.05f, 0.25f);
                asset_curve[i].translate(5.0f, 0.0f, 0.0f);
            }
            for (int i = 0; i < Stuff3d.Count; i++)
            {
                Stuff3d[i].rotate(180.0f, -90.0f, 0.0f);

            }
            for (int i = 0; i < Stuff3d_Curve.Count; i++)
            {
                Stuff3d_Curve[0].translate(0.04f, -0.05f, 0.25f);
                Stuff3d_Curve[1].translate(-0.04f, -0.05f, 0.25f);
            }
            for (int i = 0; i < A3d.Count; i++)
            {
                A3d[i].rotate(180.0f, -90.0f, 0.0f);
                A3d[i].translate(2.5f, 0.0f, 0.0f);
            }
            for (int i = 0; i < stuff_kurva.Count; i++)
            {
                stuff_kurva[0].translate(-0.04f, -0.20f, 0.20f);
                stuff_kurva[1].translate(0.04f, -0.20f, 0.20f);
                stuff_kurva[i].translate(2.5f, 0.0f, 0.0f);
            }

            base.OnLoad();
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            if (temp_count < 50)
            {
                for (int i = 0; i < asset.Count; i++)
                {
                    asset[i].translate(0.0f, 0.02f, 0.0f);
                    asset[i].rotate(0.0f, -0.5f, 0.0f);
                }
                for (int i = 0; i < asset_curve.Count; i++)
                {
                    asset_curve[i].translate(0.0f, 0.02f, 0.0f);
                    asset_curve[i].rotate(0.0f, -0.5f, 0.0f);
                }
                temp_count++;
            }
            else if (temp_count >= 50)
            {
                for (int i = 0; i < asset.Count; i++)
                {
                    asset[i].translate(0.0f, -0.02f, 0.0f);
                    asset[i].rotate(0.0f, -0.5f, 0.0f);
                }
                for (int i = 0; i < asset_curve.Count; i++)
                {
                    asset_curve[i].translate(0.0f, -0.02f, 0.0f);
                    asset_curve[i].rotate(0.0f, -0.5f, 0.0f);
                }
                temp_count++;
                if (temp_count == 100)
                {
                    temp_count = 0;
                }
            }
            if (count < 200)
            {

                for (int i = 0; i < Stuff3d.Count; i++)
                {
                    Stuff3d[i].rotate(0.180f, 0.0f, 0.0f);
                    Stuff3d[i].rotate(-0.90f, 0.0f, 0.0f);
                    Stuff3d[i].translate(0.0f, 0.0f, 0.0050f);
                }
                for (int i = 0; i < A3d.Count; i++)
                {
                    A3d[i].rotate(0.0f, 0.180f, 0.0f);
                    A3d[i].rotate(0.0f, -0.90f, 0.0f);
                }
                for (int i = 0; i < KakiKiri.Count; i++)
                {
                    KakiKiri[i].rotate(0.180f, 0.0f, 0.0f);
                    KakiKiri[i].rotate(-0.90f, 0.0f, 0.0f);
                    KakiKiri[i].translate(0.0f, -0.001f, 0.0f);
                }
                for (int i = 0; i < KakiKanan.Count; i++)
                {
                    KakiKanan[i].rotate(0.180f, 0.0f, 0.0f);
                    KakiKanan[i].rotate(-0.90f, 0.0f, 0.0f);
                    KakiKanan[i].translate(0.0f, -0.001f, 0.0f);
                }
                for (int i = 0; i < Payung.Count; i++)
                {
                    Payung[i].rotate(0.0f, 0.180f, 0.0f);
                    Payung[i].rotate(0.0f, -0.90f, 0.0f);
                    Payung[i].translate(0.0f, 0.0020f, 0.0f);
                }
                for (int i = 0; i < Stuff3d_Curve.Count; i++)
                {
                    Stuff3d_Curve[i].rotate(0.180f, 0.0f, 0.0f);
                    Stuff3d_Curve[i].rotate(-0.90f, 0.0f, 0.0f);
                    Stuff3d_Curve[i].translate(0.0f, 0.0f, 0.0050f);
                }
                for (int i = 0; i < stuff_kurva.Count; i++)
                {
                    stuff_kurva[i].rotate(0.0f, 0.180f, 0.0f);
                    stuff_kurva[i].rotate(0.0f, -0.90f, 0.0f);
                }
                count++;

            }
            else if (count >= 200)
            {

                for (int i = 0; i < Stuff3d.Count; i++)
                {
                    Stuff3d[i].rotate(-0.90f, 0.0f, 0.0f);
                    Stuff3d[i].rotate(0.720f, 0.0f, 0.0f);
                    Stuff3d[i].translate(0.0f, 0.0f, -0.0050f);
                }
                for (int i = 0; i < A3d.Count; i++)
                {
                    A3d[i].rotate(0.0f, -0.90f, 0.0f);
                    A3d[i].rotate(0.0f, 0.720f, 0.0f);
                }
                for (int i = 0; i < KakiKiri.Count; i++)
                {
                    KakiKiri[i].rotate(-0.90f, 0.0f, 0.0f);
                    KakiKiri[i].rotate(0.720f, 0.0f, 0.0f);
                    KakiKiri[i].translate(0.0f, 0.001f, 0.0f);
                }
                for (int i = 0; i < KakiKanan.Count; i++)
                {
                    KakiKanan[i].rotate(-0.90f, 0.0f, 0.0f);
                    KakiKanan[i].rotate(0.720f, 0.0f, 0.0f);
                    KakiKanan[i].translate(0.0f, 0.001f, 0.0f);
                }
                for (int i = 0; i < Payung.Count; i++)
                {
                    Payung[i].rotate(0.0f, -0.90f, 0.0f);
                    Payung[i].rotate(0.0f, 0.720f, 0.0f);
                    Payung[i].translate(0.0f, -0.0020f, 0.0f);
                }
                for (int i = 0; i < Stuff3d_Curve.Count; i++)
                {
                    Stuff3d_Curve[i].rotate(-0.90f, 0.0f, 0.0f);
                    Stuff3d_Curve[i].rotate(0.720f, 0.0f, 0.0f);
                    Stuff3d_Curve[i].translate(0.0f, 0.0f, -0.0050f);
                }
                for (int i = 0; i < stuff_kurva.Count; i++)
                {
                    stuff_kurva[i].rotate(0.0f, -0.90f, 0.0f);
                    stuff_kurva[i].rotate(0.0f, 0.720f, 0.0f);
                }

                count++;
                if (count == 400)
                {
                    count = 0;
                }
            }

            for (int i = 0; i < asset.Count; i++)
            {
                asset[i].render(_camera);
                asset[i].rotate(0.0f, 0.0f, 0.0f);
            }

            for (int i = 0; i < alas.Count; i++)
            {
                alas[i].render(_camera);
            }
            for (int i = 0; i < Batang.Count; i++)
            {
                Batang[i].render(_camera);
            }
            for (int i = 0; i < Matahari.Count; i++)
            {
                Matahari[i].render(_camera);
            }
            for (int i = 0; i < Awan.Count; i++)
            {
                Awan[i].render(_camera);
            }
            for (int i = 0; i < Daun.Count; i++)
            {
                Daun[i].render(_camera);
            }
            for (int i = 0; i < KakiKiri.Count; i++)
            {
                KakiKiri[i].render(_camera);
                KakiKiri[i].rotate(0.0f, 0.0f, 0.0f);
            }
            for (int i = 0; i < KakiKanan.Count; i++)
            {
                KakiKanan[i].render(_camera);
                KakiKanan[i].rotate(0.0f, 0.0f, 0.0f);
            }
            for (int i = 0; i < Payung.Count; i++)
            {
                Payung[i].render(_camera);
                Payung[i].rotate(0.0f, 0.0f, 0.0f);
            }
            for (int i = 0; i < asset_curve.Count; i++)
            {
                asset_curve[i].render(_camera);
                asset_curve[i].rotate(0.0f, 0.0f, 0.0f);
            }
            for (int i = 0; i < Stuff3d.Count; i++)
            {
                Stuff3d[i].render(_camera);
                Stuff3d[i].rotate(0.0f, 0.0f, 0.0f);
            }
            for (int i = 0; i < Stuff3d_Curve.Count; i++)
            {
                Stuff3d_Curve[i].render(_camera);
                Stuff3d_Curve[i].rotate(0.0f, 0.0f, 0.0f);
            }
            for (int i = 0; i < A3d.Count; i++)
            {
                A3d[i].render(_camera);
                A3d[i].rotate(0.0f, 0.0f, 0.0f);
            }
            for (int i = 0; i < stuff_kurva.Count; i++)
            {
                stuff_kurva[i].render(_camera);
                stuff_kurva[i].rotate(0.0f, 0.0f, 0.0f);
            }


            SwapBuffers();
            base.OnRenderFrame(args);
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            if (!IsFocused)
            {
                return;
            }

            const float cameraSpeed = 1.5f;
            const float sensitivity = 0.2f;


            var input = KeyboardState;

            if (input.IsKeyDown(Keys.Escape))
            {
                Close();
            }

            if (input.IsKeyDown(Keys.W))
            {
                _camera.Position += _camera.Front * cameraSpeed * (float)args.Time;
            }

            if (input.IsKeyDown(Keys.S))
            {
                _camera.Position -= _camera.Front * cameraSpeed * (float)args.Time;
            }

            if (input.IsKeyDown(Keys.A))
            {
                _camera.Position -= _camera.Right * cameraSpeed * (float)args.Time;
            }

            if (input.IsKeyDown(Keys.D))
            {
                _camera.Position += _camera.Right * cameraSpeed * (float)args.Time;
            }

            if (input.IsKeyDown(Keys.Up))
            {
                _camera.Position += _camera.Up * cameraSpeed * (float)args.Time;
            }

            if (input.IsKeyDown(Keys.Down))
            {
                _camera.Position -= _camera.Up * cameraSpeed * (float)args.Time;
            }
            _camera.Debug();

            var mouse = MouseState;
            if (_firstMove)
            {
                _lastPos = new Vector2(mouse.X, mouse.Y);
                _firstMove = false;
            }
            else
            {
                var deltaX = mouse.X - _lastPos.X;
                var deltaY = mouse.Y - _lastPos.Y;
                _lastPos = new Vector2(mouse.X, mouse.Y);

                _camera.Yaw += deltaX * sensitivity;
                _camera.Pitch -= deltaY * sensitivity;
            }

            base.OnUpdateFrame(args);
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            GL.Viewport(0, 0, Size.X, Size.Y);
            base.OnResize(e);
        }
    }
}