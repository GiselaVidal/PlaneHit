using SFML.Graphics;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;

namespace TcGame
{
    public class Hud : Actor
    {
        public float meteorHits { get; private set; } = 0;
        private Text text1;
        public Hud()
        {
            Layer = ELayer.Hud;
            Font font = new Font("Data/Fonts/georgia.ttf");

            text1 = new Text("Points achieved", font, 20);
            text1.Position = new SFML.System.Vector2f(0, 0);
            text1.FillColor = Color.Yellow;
          
        }
        public override void Draw(RenderTarget target, RenderStates states)
        {
            text1.DisplayedString = "Points achieved: " + meteorHits;
            base.Draw(target, states);
            target.Draw(text1);

        }

    
        public void ShotDown()
        {
            meteorHits++;
        }
    }
}

