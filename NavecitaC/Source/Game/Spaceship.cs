using App.Source.Game;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace TcGame
{
    public class Spaceship : StaticActor
    {
        private float Speed = 300f;
        private float Timer;
        private Vector2f tailOffset;


        public Spaceship()
        {

            Layer = ELayer.Front;
            Sprite = new Sprite(new Texture("Data/Textures/Player/falcon.png"));
            Position = new SFML.System.Vector2f(Engine.Get.Window.Size.X / 2, Engine.Get.Window.Size.Y / 2 + 100); 
            Center();
            
        }

        public override void Update(float dt)
        {
            base.Update(dt);

            Follow();
            Position += Forward * Speed * dt;

            if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
            {
                Timer += dt;
                if (Timer > 0.5)
                {
                    Timer = 0f;
                    Shoot();

                }

            }
        }

        public void Shoot()
        {
            float laserOffset = 40f;
            
            Laser b = Engine.Get.Scene.Create<Laser>();
            b.Position = Position+Forward * laserOffset;
            b.Forward = Forward.Normal();
            

        }
        private void Follow()
        {
            Forward = (Engine.Get.MousePos - Position).Normal();
            Rotation = (float)Math.Atan2(Forward.Y, Forward.X) *
            MathUtil.RAD2DEG + 90;
            CheckCollision();


        }

        private void CheckCollision()
        {
            List<Meteor> meteors = Engine.Get.Scene.GetAll<Meteor>();
            List<Laser> lasers = Engine.Get.Scene.GetAll<Laser>();

            foreach (Meteor meteor in meteors)
            {
                foreach (Laser laser in lasers)
                {
                    if (laser.GetGlobalBounds().Intersects(meteor.GetGlobalBounds()))
                    {
                        meteor.Destroy();
                        laser.Destroy();
                    }
                }
            }

        }
    }
}
