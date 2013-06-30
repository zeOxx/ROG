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

        private List<Texture> textureStyles;

        private enum MenuState { MAIN, OPTIONS, CREDITS };
        MenuState menuState;
        #endregion

        #region Constructor
        public Manager(RenderWindow window)
        {
            setupTextureStyleList();

            menuFont = new Font("Fonts/visitor1.ttf");

            menuState = MenuState.MAIN;

            setupMainMenu(window);
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

        private void setupTextureStyleList()
        {
            textureStyles = new List<Texture>();

            textureStyles.Add(new Texture("Textures/Buttons/btn_01.png"));          // 0
            textureStyles.Add(new Texture("Textures/Buttons/new_game.png"));        // 1
            textureStyles.Add(new Texture("Textures/Buttons/credits.png"));         // 2
            textureStyles.Add(new Texture("Textures/Buttons/options.png"));         // 3
            textureStyles.Add(new Texture("Textures/Buttons/quit.png"));            // 4
        }
        #endregion
        #region Private
        private void setupMainMenu(RenderWindow window)
        {
            mainMenu = new Menu(menuFont, 1, window);

            mainMenu.addButton(textureStyles[1], null);
            mainMenu.positionButtons(0, new Vector2f(100.0f, 100.0f));
        }
        #endregion
        #endregion
    }
}
