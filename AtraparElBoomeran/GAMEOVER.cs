using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace AtraparElBoomeran
{
    class GAMEOVER : SPRITE
    {
        Game1 ruta;

        public GAMEOVER(Game1 Laruta, Point laposicion) : base(laposicion, new Point(1600, 700))//LLAMDA DEL CONTRUCTOR ANTERIOR
        {
            this.ruta = Laruta;
            this.imagen1 = "GAMEOVER";

            this.LoadContent();
        }
        public void LoadContent()
        {
            imagen = this.ruta.Content.Load<Texture2D>(imagen1);
        }
    }
}
