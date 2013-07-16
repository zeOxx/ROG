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

        public void setPositionX(float x)
        {
            sprite.Position = new Vector2f(x, sprite.Position.Y);
        }

        public void setPositionY(float y)
        {
            sprite.Position = new Vector2f(sprite.Position.X, y);
        }

        public void centerButton(Vector2u windowSize, bool hori, bool vert)
        {
            if (hori && !vert)
            {
                sprite.Position = new Vector2f((windowSize.X / 2) - (sprite.GetLocalBounds().Width / 2), sprite.Position.Y);
            }
            if (vert && !hori)
            {
                sprite.Position = new Vector2f(sprite.Position.X, (windowSize.Y / 2) - (sprite.GetLocalBounds().Height / 2));
            }
            if (hori && vert)
            {
                sprite.Position = new Vector2f((windowSize.X / 2) - (sprite.GetLocalBounds().Width / 2), (windowSize.Y / 2) - (sprite.GetLocalBounds().Height / 2));
            }
        }

        public void draw(RenderWindow window)
        {
            window.Draw(sprite);

            if (hasText)
                window.Draw(text);
        }

        public Sprite getSprite()
        {
            return sprite;
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
