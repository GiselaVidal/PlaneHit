using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcGame
{
    internal class Explosion : AnimatedActor
    {
        private float lifeTime;
        public Explosion() 
        {
            AnimatedSprite = new AnimatedSprite(new Texture("Data/Textures/Explosion.png"),4, 1);
            AnimatedSprite.Loop = false;
            AnimatedSprite.FrameTime = 0.2f;
            lifeTime = AnimatedSprite.FrameTime * 3.0f;
            Center();
        }
        public  void Update(float dt)
        {
            base.Update(dt);
            Position += new Vector2f(0.0f, 30.0f * dt);
            lifeTime -= dt;
            if (lifeTime < 0.0f)
            {
                Destroy();
            }
        }
    }
}
