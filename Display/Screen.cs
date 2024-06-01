using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using System;
using System.Xml.Linq;

namespace Saga.Display
{
    public class Screen
    {
        internal static GameWindow _window;
        internal static GraphicsDeviceManager _graphicsDeviceManager;
        internal static BoxingViewportAdapter _boxingViewportAdapter;
        internal static OrthographicCamera _orthographicCamera;

        public static BoxingViewportAdapter ViewportAdapter => _boxingViewportAdapter;
        public static OrthographicCamera Camera2D => _orthographicCamera;

        /// <summary>
        /// The current width of the GraphicsDevice back buffer
        /// </summary>
        public static int Width
        {
            get => _graphicsDeviceManager.GraphicsDevice.PresentationParameters.BackBufferWidth;
            set => _graphicsDeviceManager.GraphicsDevice.PresentationParameters.BackBufferWidth = value;
        }

        /// <summary>
        /// The current height of the GraphicsDevice back buffer
        /// </summary>
        public static int Height
        {
            get => _graphicsDeviceManager.GraphicsDevice.PresentationParameters.BackBufferHeight;
            set => _graphicsDeviceManager.GraphicsDevice.PresentationParameters.BackBufferHeight = value;
        }

        /// <summary>
        /// The size of the current backbuffer as a Vector2
        /// </summary>
        public static Vector2 Size => new Vector2(Width, Height);

        /// <summary>
        /// Obtains the centre of the current screen.
        /// </summary>
        public static Vector2 Center => new Vector2(Width / 2, Height / 2);

        /// <summary>
        /// Set or return the preferred width of the GraphicsDevice back buffer
        /// </summary>
        public static int PreferredBackBufferWidth
        {
            get => _graphicsDeviceManager.PreferredBackBufferWidth;
            set => _graphicsDeviceManager.PreferredBackBufferWidth = value;
        }

        /// <summary>
        /// Set or returns the preferred height of the GraphicsDevice back buffer
        /// </summary>
        public static int PreferredBackBufferHeight
        {
            get => _graphicsDeviceManager.PreferredBackBufferHeight;
            set => _graphicsDeviceManager.PreferredBackBufferHeight = value;
        }

        /// <summary>
        /// Returns the current display mode width
        /// </summary>
        public static int MonitorWidth => GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;

        /// <summary>
        /// Returns the current display mode height
        /// </summary>
        public static int MonitorHeight => GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

        /// <summary>
        /// Enables Vsync if true
        /// </summary>
        public static bool Vsync
        {
            get => _graphicsDeviceManager.SynchronizeWithVerticalRetrace;
            set
            {
                _graphicsDeviceManager.SynchronizeWithVerticalRetrace = value;
            }
        }

        /// <summary>
        /// Enables Fullscreen if true
        /// </summary>
        public static bool Fullscreen 
        {
            get => _graphicsDeviceManager.IsFullScreen;
            set
            {
                _graphicsDeviceManager.IsFullScreen = value;
            }
        }

        /// <summary>
        /// Enables MutiSampling if true
        /// </summary>
        public static bool Msaa
        {
            get => _graphicsDeviceManager.PreferMultiSampling;
            set
            {
                _graphicsDeviceManager.PreferMultiSampling = value;
            }
        }

        public static bool HardwareMode
        {
            get => _graphicsDeviceManager.HardwareModeSwitch;
            set 
            { 
                _graphicsDeviceManager.HardwareModeSwitch = value;
            }
        }

        internal static int _lastWidth;
        internal static int _lastHeight;

        /// <summary>
        /// Initializes the Screen
        /// </summary>
        /// <param name="graphicsDeviceManager">Requires a reference to the applications GraphicsDeviceManager</param>
        public static void Initialize(Game game, GraphicsDeviceManager graphicsDeviceManager, int width, int height, bool msaa = true, bool vsync = true)
        {
            // Initialize core variables
            _window                   = game.Window;
            _graphicsDeviceManager    = graphicsDeviceManager;
            _boxingViewportAdapter    = new BoxingViewportAdapter(_window, game.GraphicsDevice, width, height);
            _orthographicCamera       = new OrthographicCamera(_boxingViewportAdapter);
            _window.AllowUserResizing = true;

            // Configure our Screen
            PreferredBackBufferWidth  = width;
            PreferredBackBufferHeight = height;
          
            Fullscreen = false;
            Msaa       = msaa;
            Vsync      = vsync;

            Apply();

            _window.ClientSizeChanged += HandleWindowResize;
        }

        /// <summary>
        /// Set the size of the current Screen
        /// </summary>
        /// <param name="width">Screen width</param>
        /// <param name="height">Screen height</param>
        public static void SetSize(int width, int height)
        {
            PreferredBackBufferWidth  = width;
            PreferredBackBufferHeight = height;
            HardwareMode = false;
            Fullscreen = false;
            Apply();
        }

        public static void ScreenKeyLogic(Keys key)
        {
            switch(key)
            {
                case Keys.F2:
                    ToggleFullScreen();
                    break;
            }
        }

        public static void HandleWindowResize(object sender, EventArgs e)
        {
            if (!Fullscreen)
            {
                // Handle resizing of the main window
                PreferredBackBufferWidth  = _window.ClientBounds.Width;
                PreferredBackBufferHeight = _window.ClientBounds.Height;
                Apply();
            }
        }

        /// <summary>
        /// Toggles Fullscreen mode
        /// </summary>
        public static void ToggleFullScreen() {
            if(Fullscreen)
            {
                PreferredBackBufferWidth  = _lastWidth;
                PreferredBackBufferHeight = _lastHeight;
                Screen.Fullscreen         = false;
                Screen.HardwareMode       = false;
            }
            else
            {
                _lastWidth                = _window.ClientBounds.Width;
                _lastHeight               = _window.ClientBounds.Height;
                PreferredBackBufferWidth  = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
                PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
                Screen.Fullscreen         = true;
                Screen.HardwareMode       = false;
            }
            Apply();
        }


        /// <summary>
        /// Apply changes made
        /// </summary>
        public static void Apply()
        {
            _graphicsDeviceManager.ApplyChanges();
            _boxingViewportAdapter.Reset();
        } 

    }
}
