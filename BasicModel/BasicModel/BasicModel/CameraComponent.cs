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
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class CameraComponent
    {
        public CameraComponent(GraphicsDeviceManager gdm)
        {
                        view = Matrix.CreateLookAt(new Vector3(0f, 0f, 3f), Vector3.Zero, Vector3.Up);
            proj = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(17.5f), 2.0f /1.2f, 1.0f, 20.0f);
            
        }
        protected Matrix view;
        protected Matrix proj;

        public Matrix View
        {
            get { return this.view; }
        }

        public Matrix Proj
        {
            get { return this.proj; }



        }
    }
}
