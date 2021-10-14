using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace AtraparElBoomeran
{
    class CLASEBOOMERAN
    {
        public Point Posicion { get; set; }
        private Point size { get; set; }



        private Point velocidad = new Point(0, 20);

        private const string imagen1 = "Boomeran1";
        Texture2D imagen;
        Rectangle rectangulo;

        Game1 ruta;

        public CLASEBOOMERAN(Point inicioposicion, Game1 laruta)
        {
            Posicion = inicioposicion;
            size = new Point(300);
            rectangulo = new Rectangle(Posicion, size);
            ruta = laruta;
            this.LoadContent();
        }
        private void Mover()
        {
            Posicion -= velocidad;

        }
        private void LoadContent()
        {
            imagen = this.ruta.Content.Load<Texture2D>(imagen1);
           
        }
        public void Update(GameTime game)
        {
            Mover();
            rectangulo.Location = Posicion;


        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {


            spriteBatch.Draw(imagen, rectangulo, Color.White);


        }
    }
}
