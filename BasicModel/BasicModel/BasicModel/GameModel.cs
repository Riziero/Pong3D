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
    public class GameModel : Microsoft.Xna.Framework.DrawableGameComponent
    {
        Model _model;
        string _modelname;
        ContentManager _cm;
        float radius;
        CameraComponent _camera;
        Matrix _world;
        Matrix[] transforms;
        Effect _needeffect;
        List<Effect> effetcs = new List<Effect>();
        

       

        public GameModel(Game game, ContentManager cm, CameraComponent myCamera, Matrix world, Effect effect, string modelName)
            : base(game)
        {
            // TODO: Construct any child components here
            _modelname = modelName;
            _cm = cm;
            _camera = myCamera;
            _world = world;
            _needeffect = effect;
            
        }
         public void addEffect(Effect e)
        {
            effetcs.Add(e);
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

           

            base.Initialize();
        }
        protected override void LoadContent()
        {
            _model = _cm.Load<Model>(_modelname);
            radius = getMaxMeshRadius();            
            transforms = new Matrix[_model.Bones.Count];
            _model.CopyAbsoluteBoneTransformsTo(transforms);

            if (_needeffect == null)
            {
                BasicEffect be = new BasicEffect(GraphicsDevice);
                //default effect
                effetcs.Add(be);
            }
            else
                effetcs.Add(_needeffect);

            base.LoadContent();
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

        private void drawModel(Matrix view, Matrix proj)
        {
            _model.Draw(_world * Matrix.CreateScale(1.0f / radius), view, proj);
        }

        
        public override void Draw(GameTime gameTime)
        {
            foreach (ModelMesh mm in _model.Meshes)
            {   
                
                foreach (ModelMeshPart mmp in mm.MeshParts)
                {
                    foreach (Effect e in effetcs)
                    {
                        BasicEffect be = e as BasicEffect;
                        if (be != null)
                        {
                            be.World = transforms[mm.ParentBone.Index] * _world;
                            be.View = _camera.View;
                            be.Projection = _camera.Proj;
                            GraphicsDevice.SetVertexBuffer(mmp.VertexBuffer, mmp.VertexOffset);
                            GraphicsDevice.Indices = mmp.IndexBuffer;
                            be.CurrentTechnique.Passes[0].Apply();
                            GraphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, mmp.NumVertices, mmp.StartIndex, mmp.PrimitiveCount);
                        }
                    }
 
                }
            }
            //drawModel(_camera.View, _camera.Proj);

            base.Draw(gameTime);
        }

        private float getMaxMeshRadius()
        {
            float radius = -1.0f;
            foreach (ModelMesh mm in _model.Meshes)
            {
                if (mm.BoundingSphere.Radius > radius)
                    radius = mm.BoundingSphere.Radius;
            }
            if (radius != -1.0f)
                return radius;
            throw new Exception("No radius");
        }
    }
}
