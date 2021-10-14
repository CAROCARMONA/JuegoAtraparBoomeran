using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AtraparElBoomeran
{
    class BOOMERAN
    {
        Game1 ruta;
        private Texture2D[] imagenes;
        private int caminar = 0;
        private int ssX = 750;
        private int ssY = 450;
        Rectangle[] rectangulo;
        protected Point Posicion { get; set; }
        public Point size { get; set; }
        private Point velocidadX = new Point(10, 0);
        private Point velocidadY = new Point(0, 20);



        public BOOMERAN(Game1 laruta, Point _POSICION, Point _SIZE)
        {
            Posicion = _POSICION;
            ruta = laruta;
            size = _SIZE;
            for (int i = 0; i < 4; i++)
            {
                rectangulo[i] = new Rectangle(Posicion, size);
            }
            this.LoadContent();
        }
        private void LoadContent()
        {
            for (int i = 0; i < 4; i++)
            {
                imagenes[i] = this.ruta.Content.Load<Texture2D>("boomeran" + (i + 1));
            }
        }
        private void arriba()
        {
            Posicion += velocidadX;
            Posicion -= velocidadY;
        }
        private void abajo()
        {
            Posicion += velocidadX;
            Posicion += velocidadY;
        }
        private void ESPEJOdearriba()
        {
            Posicion -= velocidadX;
            Posicion += velocidadY;
        }
        private void ESPEJOdeabajo()
        {
            Posicion -= velocidadX;
            Posicion -= velocidadY;
        }

        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < 4; i++)
            {
                rectangulo[i].Location = Posicion;
            }
            for (int i = 0; i < 4; i++)
            {
                if (rectangulo[i].X <= ssX && rectangulo[i].Y > ssY)
                {
                    caminar += 1;
                    arriba();
                    if (caminar > 4)
                    {
                        caminar = 0;
                    }

                }
                else if (rectangulo[i].X >= ssX && rectangulo[i].Y > ssY)
                {
                    abajo();
                    if (caminar > 4)
                    {
                        caminar = 0;
                    }
                }
                else if (rectangulo[i].X >= ssX && rectangulo[i].Y < ssY)
                {
                    caminar += 1;
                    ESPEJOdeabajo();
                    if (caminar > 4)
                    {
                        caminar = 0;
                    }
                }
                else if (rectangulo[i].X <= ssX && rectangulo[i].Y < ssY)
                {
                    caminar += 1;
                    ESPEJOdearriba();
                    if (caminar > 4)
                    {
                        caminar = 0;
                    }
                }
            }



        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Color _COLOR)
        {
            spriteBatch.Draw(imagenes[caminar], rectangulo[caminar], Color.White);


        }
    }

}
