using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace AtraparElBoomeran
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D fondo;
        private Rectangle rectangulo;

        perro PERRO;
        MEN men;

        Song sonido1;

        private SpriteFont letra;
        private int ATRAPADAS = 0;
        //atrapadas de boomeras
        private bool NOatrapo = false;
        //win ganar
        WIN win;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = 1800;
            _graphics.PreferredBackBufferHeight = 900;
            _graphics.ApplyChanges();

            men = new MEN(this, new Point(1500, 200));
            PERRO = new perro(this);
            rectangulo = new Rectangle(1, 1, 1800, 900);

            win = new WIN(this);
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            fondo = Content.Load<Texture2D>("fondo");
            sonido1 = this.Content.Load<Song>("sonidofondo");
            letra = this.Content.Load<SpriteFont>("File");
            MediaPlayer.Play(sonido1);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            men.Update(gameTime);
            PERRO.Update(gameTime);


            if (men.RECboomeran.Intersects(PERRO.RECperro))
            {
                men.contaM = 1;
                ATRAPADAS += 1;
            }



            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            _spriteBatch.Draw(fondo, rectangulo, Color.White);
            _spriteBatch.DrawString(letra, " Boomeras atrapados " + ATRAPADAS, new Vector2(700, 50), Color.Purple);



            _spriteBatch.End();
            PERRO.Draw(gameTime, _spriteBatch, Color.White);
            men.Draw(gameTime, _spriteBatch, Color.White);

            if (ATRAPADAS == 5)
            {
                win.Draw(gameTime, _spriteBatch, Color.White);
                //men.VIDAS = +1;
            }
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
