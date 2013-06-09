using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML;
using SFML.Graphics;
using SFML.Window;

namespace ROG.ScreenManager
{
    class Manager
    {
        #region Class Variables
        private Menu mainMenu;
        private Menu optionsMenu;
        private Font menuFont;

        private enum MenuState { MAIN, OPTIONS, CREDITS };
        MenuState menuState;
        #endregion

        #region Constructor
        public Manager(RenderWindow window)
        {
            menuFont = new Font("Fonts/visitor1.ttf");

            menuState = MenuState.MAIN;

            setupMainMenu(window);
            setupOptionsMenu(window);
        }
        #endregion

        #region Methods
        #region Public
        public void update(int value)
        {
            switch (menuState)
            {
                case MenuState.MAIN:
                    mainMenu.update(value);
                    break;
            }
        }

        public void draw(RenderWindow window)
        {
            switch (menuState)
            {
                case MenuState.MAIN:
                    mainMenu.draw(window, false);
                    break;
            }
        }
        #endregion
        #region Private
        private void setupMainMenu(RenderWindow window)
        {
            mainMenu = new Menu(menuFont, 1, window);

            mainMenu.addMenuItem("New Game");
            mainMenu.addMenuItem("Options");
            mainMenu.addMenuItem("Exit Game");
            mainMenu.positionText();
        }

        private void setupOptionsMenu(RenderWindow window)
        {
            optionsMenu = new Menu(menuFont, 2, window);

            optionsMenu.addMenuItem("Derp");
            optionsMenu.addMenuItem("Herp");
            optionsMenu.addMenuItem("Serp");
            optionsMenu.positionText();
        }
        #endregion
        #endregion
    }
}
