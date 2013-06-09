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
        private List<Texture> textureStyles;
        private Text text;
        private int style;
        #endregion

        #region Constructor
        public Button(int style,String text)
        {
            setupTextureStyleList();

            Style = style;

            texture = textureStyles[Style];
        }
        #endregion

        #region Methods
        private void setupTextureStyleList()
        {
            textureStyles = new List<Texture>();

            textureStyles.Add(new Texture("Textures/Buttons/btn_01.png"));
        }

        private void setupText(String text)
        {
            this.text = new Text()
        }
        #endregion

        #region Accessors
        private int Style
        {
            get { return this.style; }
            set
            {
                this.style = value;
                
                //Clamping
                if (this.style < 0)
                    this.style = 0;
                if (this.style > textureStyles.Count())
                    this.style = textureStyles.Count() - 1;
            }
        }
        #endregion
    }
}
