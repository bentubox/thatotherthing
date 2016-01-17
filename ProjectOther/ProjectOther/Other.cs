using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyDataTypes;
using ProjectOther.States;
using ProjectOther.Util;
using System.Collections.Generic;

namespace ProjectOther
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Other : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Game settings.
        Configuration config;

        //Keyboard states used to track keyboard button press
        KeyboardState currentKeyboardState;
        KeyboardState lastKeyboardState;

        //Mouse states used to track Mouse button press
        MouseState currentMouseState;
        MouseState previousMouseState;

        //Variables used to count and display FPS.
        SpriteFont font;
        bool showFPS;
        int totalFrames = 0;
        float elapsedTime = 0.0f;
        int fps = 0;

        StateManager stateManager;

        public Other()
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
            currentKeyboardState = Keyboard.GetState();
            lastKeyboardState = Keyboard.GetState();

            currentMouseState = Mouse.GetState();
            previousMouseState = Mouse.GetState();

            this.stateManager = new StateManager();
            showFPS = false;
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Load content.
            //Push initial loading screen state onto game state stack.
            SlideShowState loadSeq = new SlideShowState(new Queue<Texture2D>(), false, -1);
            loadSeq.addSlide(this.Content.Load<Texture2D>("Screens/other"));
            stateManager.push(loadSeq);

           config = Utils.loadConfig();

            this.IsFixedTimeStep = true;
            this.graphics.SynchronizeWithVerticalRetrace = true;
            this.TargetElapsedTime = new System.TimeSpan(0, 0, 0, 0, 1000 / config.fps);

            switch (config.resolutionLevel)
            {
                case 1:
                    graphics.PreferredBackBufferWidth = 1600;  // set this value to the desired width of your window
                    graphics.PreferredBackBufferHeight = 1200;   // set this value to the desired height of your window
                    break;
                case 2:
                    graphics.PreferredBackBufferWidth = 1024;  // set this value to the desired width of your window
                    graphics.PreferredBackBufferHeight = 768;   // set this value to the desired height of your window
                    break;
                default:
                    graphics.PreferredBackBufferWidth = 800;  // set this value to the desired width of your window
                    graphics.PreferredBackBufferHeight = 600;   // set this value to the desired height of your window
                    break;
            }

            graphics.ApplyChanges();
            this.Window.Position = new Point((System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - graphics.PreferredBackBufferWidth) / 2, 0);

            font = Content.Load<SpriteFont>("Fonts/Orator");

            //After loading content, push Title Screen State.
            //stateManager.pop();
            //stateManager.push(new TitleState());
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here

        }

        /// <summary>
        /// Update current game state.
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// Tells the current game state to update itself.
        /// <summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Check state of input.
            currentKeyboardState = Keyboard.GetState();

            //Tell current game state to update given current state of input.
            if (lastKeyboardState.GetPressedKeys().Length > 0)
            {
                if (currentKeyboardState.IsKeyDown((Keys)System.Enum.Parse(typeof(Keys), config.fpsToggle)))
                {
                    showFPS = !showFPS;
                }
            }
            stateManager.update(currentKeyboardState);

            lastKeyboardState = currentKeyboardState;
           
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if(elapsedTime >= 1000.0f)
            {
                fps = totalFrames;
                totalFrames = 0;
                elapsedTime = 0;
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            stateManager.draw(spriteBatch, graphics);
            if (showFPS)
            {
                spriteBatch.DrawString(font, string.Format("FPS : {0}", fps),
                new Vector2(10.0f, 20.0f), Color.White);
            }
            spriteBatch.End();
            totalFrames++;
            base.Draw(gameTime);
        }
    }
}
