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
    public class Tunnel : Microsoft.Xna.Framework.DrawableGameComponent
    {
        Vector3 _origin, _normal, _up;
        float _width, _height;
        int _near, _far;
        GraphicsDeviceManager _graphics;
        ContentManager _content;
        BasicEffect quadEffect;
        CameraComponent _camera;
        List<Quad> _quads;
        string _texname;
        public Tunnel(Game game, GraphicsDeviceManager gdm, CameraComponent camera, ContentManager cm, int near, int far, Vector3 origin, Vector3 normal, Vector3 up, float width, float height)
            : base(game)
        {
            // TODO: Construct any child components here
            _origin = origin;
            _normal = normal;
            _up = up;
            _width = width;
            _height = height;
            _graphics = gdm;
            _content = cm;
            _camera = camera;
            _near = near;
            _far = far;
            
        }
        protected override void LoadContent()
        {
            
            
            quadEffect = new BasicEffect(_graphics.GraphicsDevice);
            
            quadEffect.World = Matrix.Identity;
            quadEffect.View = _camera.View;
            quadEffect.Projection = _camera.Proj;            
            quadEffect.VertexColorEnabled = true;
            

            base.LoadContent();
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            _quads = new List<Quad>();
            for (int i = _far; i > _near; i--)
            {
                _quads.Add(new Quad(new Vector3(0,0,(float)i*(-1)), _normal, _up, _width, _height));
            }
                base.Initialize();
        }


        private void DrawQuad(Quad quad)
        {
             

             
                 foreach (EffectPass pass in quadEffect.CurrentTechnique.Passes)
                 {
                     pass.Apply();

                     _graphics.GraphicsDevice.DrawUserIndexedPrimitives
                         <VertexPositionColor>(
                         PrimitiveType.LineList,
                         quad.Vertices, 0, 4,
                         quad.Indices, 0, 4);
                 }
                     
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (Quad quad in _quads)
            {
                DrawQuad(quad);
            }

            Quad mostNearQuad = _quads[_quads.Count - 1];
            Quad mostFarQuad = _quads[1];

            VertexPositionColor[] vpc = new VertexPositionColor[8];
            vpc[0] = new VertexPositionColor(mostNearQuad.UpperLeft, Color.YellowGreen);
            vpc[1] = new VertexPositionColor(mostFarQuad.UpperLeft, Color.YellowGreen);
            vpc[2] = new VertexPositionColor(mostNearQuad.UpperRight, Color.YellowGreen);
            vpc[3] = new VertexPositionColor(mostFarQuad.UpperRight, Color.YellowGreen);
            vpc[4] = new VertexPositionColor(mostNearQuad.LowerRight, Color.YellowGreen);
            vpc[5] = new VertexPositionColor(mostFarQuad.LowerRight, Color.YellowGreen);
            vpc[6] = new VertexPositionColor(mostNearQuad.LowerLeft, Color.YellowGreen);
            vpc[7] = new VertexPositionColor(mostFarQuad.LowerLeft, Color.YellowGreen);

            short[] indexes = new short[8];
            indexes[0] = 0;
            indexes[1] = 1;
            indexes[2] = 2;
            indexes[3] = 3;
            indexes[4] = 4;
            indexes[5] = 5;
            indexes[6] = 6;
            indexes[7] = 7;

            _graphics.GraphicsDevice.DrawUserIndexedPrimitives<VertexPositionColor>(PrimitiveType.LineList, vpc, 0, vpc.Length, indexes, 0, 4);

            base.Draw(gameTime);
        }
        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            base.Update(gameTime);
        }
    }
}
