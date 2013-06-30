using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SFML;
using SFML.Graphics;
using SFML.Window;

namespace ROG.ScreenManager.Components
{
    class Button
    {
        #region Class Variables
        private Texture texture;
        private Sprite sprite;
        private Text text;
        private Font font;
        private bool hasText;
        #endregion

        #region Constructor
        public Button(String text, Font font, Texture texture)
        {
            if (text != null) {
                hasText = true;
                this.font = font;
                setupText(text);
            }
            else
                hasText = false;

            this.texture = texture;

            sprite = new Sprite(this.texture);
        }
        #endregion

        #region Methods
        #region Public
        public void setPosition(Vector2f position)
        {
            sprite.Position = position;

            if (hasText) {
                Vector2f btnCenter = new Vector2f(sprite.GetLocalBounds().Width / 2, sprite.GetLocalBounds().Height / 2);
                Vector2f textCenter = new Vector2f(text.GetLocalBounds().Width / 2, text.GetLocalBounds().Height / 2);

                text.Position = new Vector2f((sprite.Position.X + btnCenter.X) - textCenter.X, sprite.Position.Y);

                Console.WriteLine(text.GetLocalBounds().Top);
            }
        }

        public void centerButton(Vector2u windowSize, bool hori, bool vert)
        {

        }

        public void draw(RenderWindow window)
        {
            window.Draw(sprite);

            if (hasText)
                window.Draw(text);
        }
        #endregion
        #region Private
        private void setupText(String text)
        {
            this.text = new Text(text, this.font, 30);
        }
        #endregion
        #endregion
    }
}
