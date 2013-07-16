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
        public void update(char dir)
        {
            switch (menuState)
            {
                case MenuState.MAIN:
                    mainMenu.update(dir);
                    break;
            }

            Console.WriteLine(dir);
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
            Vector2u windowSize = new Vector2u(window.Size.X, window.Size.Y);
            
            mainMenu = new Menu(menuFont, 1, window);
            Components.Button tmpBtn;

            // New Game button  // 0
            tmpBtn = new Components.Button(null, menuFont, textureStyles[1]);
            tmpBtn.centerButton(windowSize, true, false);
            tmpBtn.setPositionY(130.0f);
            mainMenu.addButton(tmpBtn);

            Vector2f mainBtnPos = new Vector2f(tmpBtn.getSprite().Position.X, tmpBtn.getSprite().Position.Y);
            
            // Credits button   // 1
            tmpBtn = new Components.Button(null, menuFont, textureStyles[2]);
            tmpBtn.setPosition(new Vector2f((mainBtnPos.X + textureStyles[1].Size.X), mainBtnPos.Y + 140));
            mainMenu.addButton(tmpBtn);
            
            // Options button   // 2
            tmpBtn = new Components.Button(null, menuFont, textureStyles[3]);
            tmpBtn.setPosition(new Vector2f((mainBtnPos.X - tmpBtn.getSprite().GetLocalBounds().Width), mainBtnPos.Y + 140));
            mainMenu.addButton(tmpBtn);

            // Quit button      // 3
            tmpBtn = new Components.Button(null, menuFont, textureStyles[4]);
            tmpBtn.centerButton(windowSize, true, false);
            tmpBtn.setPositionY(mainBtnPos.Y + textureStyles[1].Size.Y);
            mainMenu.addButton(tmpBtn);

            // Setup selectRect
            mainMenu.setSelectRectSize(new Vector2f(mainMenu.buttonList[0].getSprite().GetLocalBounds().Width, mainMenu.buttonList[0].getSprite().GetLocalBounds().Height));
            mainMenu.setSelectRectPos(mainMenu.buttonList[0].getSprite().Position);
        }
        #endregion
        #endregion
    }
}
