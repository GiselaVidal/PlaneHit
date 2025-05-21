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
            Sprite = new Sprite(new Texture("Data/Textures/Player/spaceship.png"));
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
            Laser b = Engine.Get.Scene.Create<Laser>();
            b.Position = Position;
            b.Forward = Forward;
            Rotation = (float)Math.Atan2(Forward.Y, Forward.X) *
            MathUtil.RAD2DEG + 90;

        }
        private void Follow()
        {
            Forward = (Engine.Get.MousePos - Position).Normal();
            Rotation = (float)Math.Atan2(Forward.Y, Forward.X) *
            MathUtil.RAD2DEG + 90;
            
        }
    }
}
