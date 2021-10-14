using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace AtraparElBoomeran
{
    class perro
    {
        private Texture2D[] imagenes;
        public Rectangle RECperro;
        private int caminar;
        public int ssX;
        public int ssY;
        private int contasaltos = 0;
        private int contasaltos2 = 0;
       

        private int contatiempo = 0;
        private int TIEMPO = 0;

        //nuevo codigo de salto

        

        Game1 ruta;

        public perro(Game1 laruta)
        {
            ruta = laruta;
            imagenes = new Texture2D[8];
            ssX = 50;
            ssY = 200;
            caminar = 0;
            RECperro = new Rectangle(50, 200, 75, 150);
            this.LoadContent();
        }

        private void LoadContent()
        {
            for (int i = 0; i < 8; i++)
            {
                imagenes[i] = this.ruta.Content.Load<Texture2D>("perro" + (i + 1));
            }
 
        }

        public void Update(GameTime gameTime)
        {
            var kState = Keyboard.GetState();

            RECperro.X = ssX;
            RECperro.Y = ssY;

            contatiempo++;
            if (kState.IsKeyDown(Keys.Up))//arriba
            {
                if (ssY > 10)
                {
                    caminar += 1;//todrau
                    ssY -= 10;
                    ssX += 3;

                    if (caminar > 7)
                    {
                        caminar = 4;
                    }
                }
            }

            if (kState.IsKeyDown(Keys.Down))//abajo
            {
                if (ssY < 740)
                {
                    caminar += 1;//todrau
                    ssY += 10;
                    ssX += 3;


                    if (caminar > 7)
                    {
                        caminar = 4;
                    }
                }


            }
            if (kState.IsKeyDown(Keys.Right))//derecha
            {

                if (ssX < 1000)
                {
                    caminar += 1;//todrau
                    ssX += 10;

                    if (caminar > 7)
                    {
                        caminar = 5;
                    }
                }
            }
            if (kState.IsKeyDown(Keys.Left))//izquierda
            {

                if (ssX > 5)
                {
                    caminar += 1;//todrau
                    ssX -= 10;

                    if (caminar > 4)
                    {
                        caminar = 0;
                    }

                }

            }
 

            if (kState.IsKeyDown(Keys.Space) == true)
            {
                TIEMPO += 1;

            }
            if (TIEMPO >= 40 && TIEMPO < 60)
            {
                
                caminar = 4;
                ssY -= 200;
                contasaltos2 = 1;
                TIEMPO = 0;
            }
            if (contasaltos2 == 1)
            {

                if (contatiempo % 50 == 0)
                {

                    if (ssY > 10)
                    {

                        caminar += 1;//todrau

                        ssY += 200;
                        contasaltos2 = 0;

                        if (caminar > 7)
                        {
                            caminar = 5;
                        }
                    }
                }
            }
            if (TIEMPO > 3 && TIEMPO < 20)
            {
                caminar = 4;
                ssY -= 50;
                contasaltos = 1;
                TIEMPO = 0;

            }

            if (contasaltos == 1)
            {
                if (contatiempo % 50 == 0)
                {

                    if (ssY > 10)
                    {

                        caminar += 1;//todrau

                        ssY += 75;
                        contasaltos = 0;

                        if (caminar > 7)
                        {
                            caminar = 5;
                        }
                    }
                }
            }

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Color _COLOR)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(imagenes[caminar], RECperro, Color.White);
            spriteBatch.End();

        }
    }
}
