using System;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        /// Configures default behaviour for Saga.Core
        /// </summary>
        internal CoreConfig Config = new CoreConfig();

        /// <summary>
        /// Manages Timer creation, update and removal
        /// </summary>
        internal TimerManager timerManager = new TimerManager();

        /// <summary>
        /// Manages CoreEvents emitted by the application
        /// </summary>
        internal EventManager<CoreEvent> EventManager = new EventManager<CoreEvent>();

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
