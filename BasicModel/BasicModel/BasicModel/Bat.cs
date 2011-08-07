using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace BasicModel
{
    class Bat
    {

        private VertexPositionColor[] _vertices;
        int[] _indexes;
        Vector3 _speed = Vector3.One * 0.01f;

        BasicEffect be;
         
        public Vector3 _upperLeft;
        public Vector3 _lowerLeft;
        public Vector3 _upperRight;
        public Vector3 _lowerRight;
        public Vector3 _left;
        CameraComponent _camera;

        GraphicsDeviceManager _gdm;

        float _thik;

        public void draw()
        {
            be.Techniques[0].Passes[0].Apply();
            _gdm.GraphicsDevice.DrawUserIndexedPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, _vertices, 0, _vertices.Length, _indexes, 0, 2);
            
        }

        private void fillVertices()
        {
            _vertices[2] = new VertexPositionColor(_lowerLeft, _color);
            _vertices[0] = new VertexPositionColor(_upperLeft, _color);
            _vertices[3] = new VertexPositionColor(_lowerRight, _color);
            _vertices[1] = new VertexPositionColor(_upperRight, _color);
            
            
            
            _indexes[0] = 0;
            _indexes[1] = 1;
            _indexes[2] = 2;
            _indexes[3] = 1;
            _indexes[4] = 3;
            _indexes[5] = 2;

        }

        Color _color;
        float boundW, boundH;
        public Bat(float zeta, Vector3 normal, Vector3 up, float width, float height, Color color, CameraComponent camera, GraphicsDeviceManager gdm, float boundWidth, float boundHeight)
        {
            boundW = boundWidth;
            boundH = boundHeight;
            _camera = camera;
            _color = color;
            _gdm = gdm;
            
            _left = Vector3.Cross(normal, up) * width / 2 + Vector3.UnitZ * zeta;
            _upperLeft = _left + Vector3.UnitY * height/2;
            _upperRight = _upperLeft + Vector3.UnitX * width;
            _lowerLeft = _upperLeft - Vector3.UnitY * height;
            _lowerRight = _lowerLeft + Vector3.UnitX * width;




            _vertices = new VertexPositionColor[4];
            _indexes = new int[6];
            fillVertices();
            be = new BasicEffect(gdm.GraphicsDevice);
            
            be.World = Matrix.Identity;
            be.View = camera.View;
            be.Projection = camera.Proj;
            be.Alpha = 0.5f;
            be.VertexColorEnabled = true;
            
        }

        public void moveRight()
        {
            float x = _upperRight.X;
            if (x + _speed.X > boundW/2)
                return;
            _upperLeft.X += _speed.X;
            _upperRight.X += _speed.X;
            _lowerLeft.X += _speed.X;
            _lowerRight.X += _speed.X;
            updateVertexBuffer();
        }
        public void moveLeft()
        {
            float x = _upperLeft.X;
            if (x - _speed.X < -boundW / 2)
                return;
            _upperLeft.X += -_speed.X;
            _upperRight.X += -_speed.X;
            _lowerLeft.X += -_speed.X;
            _lowerRight.X += -_speed.X;
            updateVertexBuffer();
        }
        public void moveDown()
        {
            float y = _lowerRight.Y;
            if (y - _speed.Y < -boundH / 2)
                return;
            _upperLeft.Y += -_speed.Y;
            _upperRight.Y += -_speed.Y;
            _lowerLeft.Y += -_speed.Y;
            _lowerRight.Y += -_speed.Y;
            updateVertexBuffer();
        }
        public void moveUp()
        {
            float y = _upperRight.Y;
            if (y + _speed.Y > boundH / 2)
                return;
            _upperLeft.Y += _speed.Y;
            _upperRight.Y += _speed.Y;
            _lowerLeft.Y += _speed.Y;
            _lowerRight.Y += _speed.Y;
            updateVertexBuffer();
        }

        private void updateVertexBuffer()
        {
            _vertices[0] = new VertexPositionColor(_lowerLeft, _color);
            _vertices[1] = new VertexPositionColor(_upperLeft, _color);
            _vertices[2] = new VertexPositionColor(_lowerRight, _color);
            _vertices[3] = new VertexPositionColor(_upperRight, _color);
        }

    }
}
