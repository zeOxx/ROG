using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SFML;
using SFML.Graphics;
using SFML.Window;

namespace ROG.ScreenManager
{
    class Menu
    {
        #region Class Variables
        public List<Components.Button> buttonList;
        
        private RectangleShape selectRect;
        private Text[] lowerButtons;
        private Font textFont;
        private Vector2u windowSize;
        private Color white;
        private Color yellow;

        private enum Selected { CREDITS, NEW, OPTIONS, QUIT };
        Selected selected;
        #endregion

        #region Constructor
        public Menu(Font font, int bottomBtns, RenderWindow window)
        {
            textFont = font;

            setupLowerBtns(bottomBtns);

            selected = Selected.NEW;
            selectRect = new RectangleShape();
            selectRect.FillColor = new Color(255, 255, 255, 32);
            selectRect.OutlineColor = new Color(128, 128, 128);
            selectRect.OutlineThickness = 5;

            windowSize = new Vector2u(window.Size.X, window.Size.Y);

            white = new Color(Color.White);
            yellow = new Color(Color.Yellow);

            buttonList = new List<Components.Button>();
        }
        #endregion

        #region Methods
        #region Public
        public void addButton(Components.Button tmpBtn)
        {
            buttonList.Add(tmpBtn);
        }

        public void update(char key)
        {
            if (key == 'u')
            {
                if (selected == Selected.QUIT)
                {
                    selected = Selected.NEW;
                    setSelectRectSize(new Vector2f(buttonList[0].getSprite().GetLocalBounds().Width, buttonList[0].getSprite().GetLocalBounds().Height));
                    setSelectRectPos(buttonList[0].getSprite().Position);
                }
            }

            if (key == 'd')
            {
                if (selected != Selected.QUIT)
                {
                    selected = Selected.QUIT;
                    setSelectRectSize(new Vector2f(buttonList[3].getSprite().GetLocalBounds().Width, buttonList[3].getSprite().GetLocalBounds().Height));
                    setSelectRectPos(buttonList[3].getSprite().Position);
                }
            }

            if (key == 'r')
            {
                if (selected == Selected.NEW)
                {
                    selected = Selected.CREDITS;
                    setSelectRectSize(new Vector2f(buttonList[1].getSprite().GetLocalBounds().Width, buttonList[1].getSprite().GetLocalBounds().Height));
                    setSelectRectPos(buttonList[1].getSprite().Position);
                }

                if (selected == Selected.OPTIONS)
                {
                    selected = Selected.NEW;
                    setSelectRectSize(new Vector2f(buttonList[0].getSprite().GetLocalBounds().Width, buttonList[0].getSprite().GetLocalBounds().Height));
                    setSelectRectPos(buttonList[0].getSprite().Position);
                }
            }

            if (key == 'l')
            {
                if (selected == Selected.NEW)
                {
                    selected = Selected.OPTIONS;
                    setSelectRectSize(new Vector2f(buttonList[2].getSprite().GetLocalBounds().Width, buttonList[2].getSprite().GetLocalBounds().Height));
                    setSelectRectPos(buttonList[2].getSprite().Position);
                }

                if (selected == Selected.CREDITS)
                {
                    selected = Selected.NEW;
                    setSelectRectSize(new Vector2f(buttonList[0].getSprite().GetLocalBounds().Width, buttonList[0].getSprite().GetLocalBounds().Height));
                    setSelectRectPos(buttonList[0].getSprite().Position);
                }
            }

            Console.WriteLine(selected);
        }

        public void draw(RenderWindow window, bool controller)
        {
            for (int i = 0; i < buttonList.Count(); i++)
            {
                buttonList[i].draw(window);
            }

            if (controller)
            {
                for (int j = 0; j < lowerButtons.Length; j++)
                {
                    window.Draw(lowerButtons[j]);
                }
            }

            window.Draw(selectRect);
        }
        #endregion
        #region Private
        private void setupLowerBtns(int amount)
        {
            lowerButtons = new Text[amount];

            Text okText = new Text("Ok", textFont, 20);

            if (amount > 1)
            {
                Text cancelText = new Text("Cancel", textFont, 20);


                lowerButtons[1] = cancelText;
            }

            lowerButtons[0] = okText;
        }

        public void setSelectRectSize(Vector2f size)
        {
            selectRect.Size = size;
        }

        public void setSelectRectPos(Vector2f pos)
        {
            selectRect.Position = pos;
        }

        //private void setTextColor()
        //{
        //    for (int i = 0; i < menuItems.Count(); i++)
        //    {
        //        menuItems[i].Color = white;

        //        if (IndexSelected == i)
        //        {
        //            menuItems[i].Color = yellow;
        //        }
        //    }
        //}
        #endregion
        #endregion
    }
}
