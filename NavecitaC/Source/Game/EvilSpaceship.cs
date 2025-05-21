using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcGame;

namespace NavecitaC.Source.Game
{
    public class EvilSpaceship : StaticActor
    {
        private float shootTimer = 0f;
        private float shootInterval = 2f;


        public EvilSpaceship() { 
        
            Layer = ELayer.Front;
            Sprite = new Sprite(new Texture("Data/Textures/enemy/TIE-Sized.png"));
            //Position = new SFML.System.Vector2f(Engine.Get.Window.Size.X / 2, Engine.Get.Window.Size.Y / 2 + 100);
            Speed = 80;
            Forward = new Vector2f(0, 1);
            Center();
            
        }

        public override void Update(float dt)
        {
            base.Update(dt);
            shootTimer += dt;
            if (shootTimer >= shootInterval)
            {
                shootTimer = 0f;
                Shoot();
            }
        }

        private void Shoot()
        {
            var laser = Engine.Get.Scene.Create<Laser>();
            float halfH = Sprite.GetLocalBounds().Height / 2;
            laser.Position = Position + new Vector2f(0, halfH);
            laser.Forward = new Vector2f(0, 1);
            laser.Sprite.Color = new Color(255, 100, 100);
            laser.Speed = 300f;
        }
    }
}
