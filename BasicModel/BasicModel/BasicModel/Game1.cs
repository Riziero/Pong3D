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
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        CameraComponent myCamera = null;
        Tunnel tunnel;
        Input input;
        DepthStencilState dpsLockDepthWrite;
        DepthStencilState dpsUnLockDepthWrite;

        Bat backBat;
        Bat frontBat;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }



        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            input = new Input();
            GraphicsDevice.BlendState = BlendState.AlphaBlend;
            dpsLockDepthWrite = new DepthStencilState();
            dpsLockDepthWrite.DepthBufferWriteEnable = false;
            DepthStencilState dpsUnLockDepthWrite = new DepthStencilState();
            dpsUnLockDepthWrite.DepthBufferWriteEnable = true;
            
            //graphics.PreferredBackBufferWidth = 1280;
            //graphics.PreferredBackBufferHeight = 720;
            //b = new Bat(-11f, Vector3.UnitZ, Vector3.Up, 0.9f, 0.9f, 0.9f, Color.Gray, graphics);
            
            myCamera = new CameraComponent(graphics);
            
            
           
            //model = new GameModel(this, Content, myCamera, Matrix.Identity, e, "box");
            //Components.Add(model);
            float width = 2.0f;
            float height = 1.2f;
            tunnel = new Tunnel(this, graphics, myCamera, Content, 1, 15, Vector3.Zero, Vector3.Backward, Vector3.Up, width, height);

            
            frontBat = new Bat(-2.0f, Vector3.Backward, Vector3.Up, .2f, .2f, Color.Red, myCamera, graphics, width, height);
            backBat = new Bat(-15.0f, Vector3.Backward, Vector3.Up, .2f, .2f, Color.Green, myCamera, graphics, width, height);
            Components.Add(tunnel);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            //initAxis();
            base.LoadContent();
            // TODO: use this.Content to load your game content here
        }


        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (input.right)
                frontBat.moveRight();
            if (input.left)
                frontBat.moveLeft();
            if (input.up)
                frontBat.moveUp();
            if (input.down)
                frontBat.moveDown();
            // TODO: Add your update logic here
            input.update();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            
            base.Draw(gameTime);
            GraphicsDevice.DepthStencilState = dpsLockDepthWrite;
            backBat.draw();
            frontBat.draw();
            //GraphicsDevice.DepthStencilState = dpsUnLockDepthWrite;
            
            
           
           
            
        }
    }
}
