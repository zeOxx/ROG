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
        private List<Components.Button> buttonList;
        private Text[] lowerButtons;
        private Font textFont;
        private Vector2u windowSize;
        private int indexSelected;
        private Color white;
        private Color yellow;
        #endregion

        #region Constructor
        public Menu(Font font, int bottomBtns, RenderWindow window)
        {
            textFont = font;

            setupLowerBtns(bottomBtns);

            windowSize = new Vector2u(window.Size.X, window.Size.Y);

            white = new Color(Color.White);
            yellow = new Color(Color.Yellow);

            buttonList = new List<Components.Button>();
        }
        #endregion

        #region Methods
        #region Public
        public void addButton(Texture texture, String text)
        {
            Components.Button tmpBtn = new Components.Button(text, textFont, texture);

            buttonList.Add(tmpBtn);
        }

        public void positionButtons(int index, Vector2f position)
        {
            buttonList[index].setPosition(position);
        }

        public void positionButtons(int index, String position, bool hori, bool vert)
        {
            if (position == "center")
            {
                buttonList[index].centerButton(windowSize, hori, vert);
            }
            else
            {
                Console.WriteLine("Position not recognized!");
            }
        }

        public void update(int value)
        {
            IndexSelected += value;

            //setTextColor();
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

        #region Getters/Setters
        private int IndexSelected
        {
            get { return this.indexSelected; }
            // Prevent indexSelected from going out of bounds and allows for looping
            set 
            { 
                this.indexSelected = value;

                if (this.indexSelected < 0)
                    this.indexSelected = 0;

                if (this.indexSelected >= buttonList.Count())
                    this.indexSelected = buttonList.Count() - 1;
            }
        }
        #endregion
    }
}
