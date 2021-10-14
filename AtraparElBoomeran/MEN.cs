using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework.Media;

namespace AtraparElBoomeran
{
    class MEN : SPRITE
    {

        private Random rnd;

        private int SSY = 900;
        private int TIEMPO2 = 0;
        private int TIEMPO = 0;
        public int contaM = 0;
        private int VISIBLE = 0;
        protected Rectangle rec;
        private Texture2D hombreTIRA;
        Game1 ruta;
        private Point tamanio = new Point(155, 405);

        //CODIGO DEL BOOMERAN

        public Rectangle RECboomeran;
        private Texture2D[] boomeran2;
        private int girar = 0;

        public int ssy = 400;//
        public int ssx = 1400;//14000  100

        private int velocidadBoomeran = 5;

        Song sonidoboomeran;

        //viads atrpadas

        public int SEGUNDOS = 60;
        private SpriteFont letra;

        public int TiempoLimite = 18000;

        //llamdo de la clse gameover
        GAMEOVER gameover;
        public MEN(Game1 Laruta, Point laposicion) : base(laposicion, new Point(150, 400))
        {
            this.ruta = Laruta;
            Posicion = laposicion;

            imagen1 = "hombre";

            rec = new Rectangle(Posicion, tamanio);
            RECboomeran = new Rectangle(1500, 500, 50, 80);


            //gameover

            gameover = new GAMEOVER(ruta, new Point(100, 100));

            rnd = new Random();
            //codigo de boomeran

            boomeran2 = new Texture2D[4];
            this.LoadContent();
        }

        private void LoadContent()
        {
            imagen = this.ruta.Content.Load<Texture2D>(imagen1);
            hombreTIRA = this.ruta.Content.Load<Texture2D>("tirarBomeran");


            for (int i = 0; i < 4; i++)
            {
                boomeran2[i] = this.ruta.Content.Load<Texture2D>("Boomeran" + (i + 1));
            }
            //codigo de bbomeran
            letra = this.ruta.Content.Load<SpriteFont>("File");
            sonidoboomeran = this.ruta.Content.Load<Song>("BOOMERANsonido");
        }

        public void tiro2()// boomeran
        {
            if (ssx > -1 && ssx < 1331)
            {
                girar += 1;
                ssx += 10 + velocidadBoomeran;
                if (ssx < 700)
                {
                    ssy -= (3 + velocidadBoomeran);
                }
                else if (ssx >= 700)
                {
                    ssy += 3 + velocidadBoomeran;
                }
                if (girar > 3)
                {
                    girar = 0;
                }
            }

        }
        public void tiro1()//por abajo
        {

            if (ssx < 1800 && ssx > 0)
            {
                girar += 1;
                ssx -= (10 + velocidadBoomeran);
                if (ssx > 700)
                {
                    ssy += 3 + velocidadBoomeran;
                }
                else if (ssx <= 700)
                {
                    ssy -= (3 + velocidadBoomeran);
                }
                if (girar > 3)
                {
                    girar = 0;
                }

            }


        }


        public void Update(GameTime gameTime)
        {

            RECboomeran.X = ssx;
            RECboomeran.Y = ssy;
            //codigo de boomeran
            if (VISIBLE != 1)
            {
                if (ssy >= 400)
                {
                    tiro1();
                }
                if (ssy < 400)
                {
                    tiro2();

                }


            }


            //codigo de hombre
            if (TIEMPO % 760 == 0)
            {
                velocidadBoomeran += 1;

            }


            TIEMPO += 1;

            if (TIEMPO % 200 == 0)
            {
                Posicion = new Point(1500, rnd.Next(SSY));
                contaM += 1;

            }
            if (VISIBLE == 1 && TIEMPO2 % 50 == 0)
            {
                VISIBLE = 0;
                contaM = 0;

            }
            //codigo vidas

            TiempoLimite -= 1;
            if (TiempoLimite % 60 == 0)
            {
                SEGUNDOS -= 1;
            }
        }

        public new void Draw(GameTime gameTime, SpriteBatch spriteBatch, Color _COLOR)
        {
            spriteBatch.Begin();

            if (VISIBLE != 1)
            {

                spriteBatch.Draw(boomeran2[girar], RECboomeran, Color.Black);
                spriteBatch.Draw(imagen, rectangulo, _COLOR);


            }


            if (contaM == 1)
            {
                spriteBatch.Draw(hombreTIRA, rec, Color.White);
                VISIBLE = 1;
                TIEMPO2 += 1;
                //MediaPlayer.Play(sonidoboomeran);
                ssx = 1300;
                ssy = 400;

            }



            spriteBatch.DrawString(letra, " tiempo LIMITE 60 segundos.  Tiempo que llevas: " + SEGUNDOS + " segundos", new Vector2(300, 10), Color.Red);


            spriteBatch.End();
            if (SEGUNDOS <= 0)
            {
                gameover.Draw(gameTime, spriteBatch, Color.White);
            }

        }

    }
}
