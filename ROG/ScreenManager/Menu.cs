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
        private List<Text> menuItems;
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

            menuItems = new List<Text>();

            windowSize = new Vector2u(window.Size.X, window.Size.Y);

            white = new Color(Color.White);
            yellow = new Color(Color.Yellow);

        }
        #endregion

        #region Methods
        #region Public
        public void addMenuItem(String text)
        {
            Text tempText = new Text(text, textFont, 30);

            menuItems.Add(tempText);
        }

        public void positionText()
        {
            IndexSelected = 0;

            float textHeight = 0;
            float totalTextHeight = 0;
            float margin = 15;

            // Add total height of items. All items are the same height
            textHeight = menuItems[0].GetLocalBounds().Height;
            totalTextHeight = (textHeight * menuItems.Count()) + (margin * menuItems.Count());

            float textPos = (windowSize.Y / 2) - totalTextHeight;

            // Position items accordingly
            for (int j = 0; j < menuItems.Count(); j++)
            {
                menuItems[j].Position = new Vector2f(0, textPos);

                textPos += (textHeight + margin);
            }
            setTextColor();
        }

        public void update(int value)
        {
            IndexSelected += value;

            setTextColor();
        }

        public void draw(RenderWindow window, bool controller)
        {
            for (int i = 0; i < menuItems.Count(); i++)
            {
                window.Draw(menuItems[i]);
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

        private void setTextColor()
        {
            for (int i = 0; i < menuItems.Count(); i++)
            {
                menuItems[i].Color = white;

                Console.WriteLine(IndexSelected);

                if (IndexSelected == i)
                {
                    menuItems[i].Color = yellow;
                    Console.WriteLine("DERP");
                }
            }
        }
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

                if (this.indexSelected >= menuItems.Count())
                    this.indexSelected = menuItems.Count() - 1;
            }
        }
        #endregion
    }
}
