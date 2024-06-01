using System;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Saga.Assets;
using Saga.Debug;
using Saga.Display;
using Saga.Input;
using Saga.Util.Core;
using Saga.Util.Event;
using Saga.Util.Timer;

namespace Saga
{
    /// <summary>
    /// The basic game class for a Saga project
    /// </summary>
    public class Core : Game
    {
        /// <summary>
        /// Provides internal access to the single Core instance
        /// </summary>
        internal static Core _instance;

        /// <summary>
        /// Provides global access to the single Core instance
        /// </summary>
        public static Core Instance => _instance;

        /// <summary>
        /// Provides global access to the GraphicsDevice
        /// </summary>
        public new static GraphicsDevice GraphicsDevice;

        /// <summary>
        /// Provides access to the GraphicsDeviceManager
        /// </summary>
        public static GraphicsDeviceManager GraphicsDeviceManager;

        /// <summary>
        /// Configures default behaviour for Saga.Core
        /// </summary>
        internal CoreConfig Config;

        /// <summary>
        /// Manages Timer creation, update and removal
        /// </summary>
        internal TimerManager TimerManager;

        /// <summary>
        /// Manages CoreEvents emitted by the application
        /// </summary>
        internal EventManager<CoreEvent> EventManager;

        /// <summary>
        /// Manages input events for the application
        /// </summary>
        internal InputManager InputManager;

        /// <summary>
        /// Manages loading and unloading of assets
        /// </summary>
        public AssetManager AssetManager;

        public Screen Screen;

        public Core() 
        {
            _instance             = this;
            GraphicsDeviceManager = new GraphicsDeviceManager(this);
            Config                = new CoreConfig();
            TimerManager          = new TimerManager();
            EventManager          = new EventManager<CoreEvent>();
            InputManager          = new InputManager();
            AssetManager          = new AssetManager();
            Screen                = new Screen();

            Content.RootDirectory = "Content";
            IsMouseVisible        = true;
        }

        public void CoreKeyLogic(Keys key)
        {
            Term.Debug($"YOU PRESED: {key}");
        }

        protected override void Initialize()
        {
            GraphicsDevice = base.GraphicsDevice;

            // Initialize components
            Screen.Initialize(this, GraphicsDeviceManager, 1280, 1020, true, true);

            // Configure component logic
            InputManager.AddEventListener(Input.Keyboard.KeyboardEvent.KEY_RELEASED, Screen.ScreenKeyLogic);

            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            TimerManager.Update();
            EventManager.Update();
            InputManager.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
