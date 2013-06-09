using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SFML;
using SFML.Graphics;
using SFML.Window;

namespace ROG
{
    class Rog
    {
        public RenderWindow window;
        public VideoMode defaultResolution;
        public String gameName;
        public ScreenManager.Manager screenManager;

        public Rog()
        {
            defaultResolution = new VideoMode(1280, 720);
            gameName = "ROG for C#";

            // Set up window
            window = new RenderWindow(defaultResolution, gameName);
            window.SetFramerateLimit(60);

            screenManager = new ScreenManager.Manager(window);
        }

        public void runRog()
        {
            window.SetVisible(true);

            // Setup event handlers
            window.Closed += new EventHandler(OnClose);
            window.KeyPressed += new EventHandler<KeyEventArgs>(OnKeyPressed);

            while (window.IsOpen())
            {
                window.DispatchEvents();

                window.Clear();

                screenManager.draw(window);

                window.Display();
            }
        }

        #region EVENTLISTENERS
        // OnClose listener
        public void OnClose(object sender, EventArgs e)
        {
            // Close the window when OnClose event is received
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

        // KeyPressed listener
        public void OnKeyPressed(object sender, KeyEventArgs e)
        {
            Window window = (Window)sender;
            if (e.Code == Keyboard.Key.Escape)
                window.Close();

            if (e.Code == Keyboard.Key.Up)
                screenManager.update(-1);

            if (e.Code == Keyboard.Key.Down)
                screenManager.update(1);
        }
        #endregion
    }
}
