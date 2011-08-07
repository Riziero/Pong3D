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
    class Quad
    {
        public Vector3 Origin;
        public Vector3 UpperLeft;
        public Vector3 LowerLeft;
        public Vector3 UpperRight;
        public Vector3 LowerRight;
        public Vector3 Normal;
        public Vector3 Up;
        public Vector3 Left;

        public VertexPositionColor[] Vertices;
        public int[] Indices;

        public Quad(Vector3 origin, Vector3 normal, Vector3 up, float width, float height)
        {
            Vertices = new VertexPositionColor[4];
            Indices = new int[8];
            Origin = origin;
            Normal = normal;
            Up = up;

            // Calculate the quad corners
            Left = Vector3.Cross(normal, Up);
            Vector3 uppercenter = (Up * height / 2) + origin;
            UpperLeft = uppercenter + (Left * width / 2);
            UpperRight = uppercenter - (Left * width / 2);
            LowerLeft = UpperLeft - (Up * height);
            LowerRight = UpperRight - (Up * height);

            FillVertices();
        }

        private void FillVertices()
        {
            // Fill in texture coordinates to display full texture
            // on quad
            //Vector2 textureUpperLeft = new Vector2(0.0f, 0.0f);
            //Vector2 textureUpperRight = new Vector2(1.0f, 0.0f);
            //Vector2 textureLowerLeft = new Vector2(0.0f, 1.0f);
            //Vector2 textureLowerRight = new Vector2(1.0f, 1.0f);

            //// Provide a normal for each vertex
            //for (int i = 0; i < Vertices.Length; i++)
            //{
            //    Vertices[i].Normal = Normal;
            //}

            // Set the position and texture coordinate for each
            // vertex
            Color color = Color.YellowGreen;
            Vertices[0].Position = LowerLeft;
            Vertices[0].Color = color;
            Vertices[1].Position = UpperLeft;
            Vertices[1].Color = color;
            Vertices[2].Position = LowerRight;
            Vertices[2].Color = color;
            Vertices[3].Position = UpperRight;
            Vertices[3].Color = color;

            // Set the index buffer for each vertex, using
            // clockwise winding
            Indices[0] = 0;
            Indices[1] = 1;
            Indices[2] = 1;
            Indices[3] = 3;
            Indices[4] = 3;
            Indices[5] = 2;
            Indices[6] = 2;
            Indices[7] = 0;
            
        }

        
        }
    
}
