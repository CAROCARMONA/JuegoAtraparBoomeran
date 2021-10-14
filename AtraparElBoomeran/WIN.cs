using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AtraparElBoomeran
{
    class WIN
    {
        private Texture2D imagen;
        public Rectangle RECwin;
        Game1 ruta;

        public WIN(Game1 laruta)
        {
            ruta = laruta;
            RECwin = new Rectangle(100, 100, 1600, 700);
            this.LoadContent();
        }
        public void LoadContent()
        {
            imagen = this.ruta.Content.Load<Texture2D>("ganoEljuego");
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Color _COLOR)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(imagen, RECwin, Color.White);
            spriteBatch.End();

        }
    }
}
