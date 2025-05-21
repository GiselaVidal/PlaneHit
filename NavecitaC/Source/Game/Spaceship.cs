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

            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {

                Forward = new Vector2f(0, -1);
                Position += Forward * Speed * dt;

            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {

                Forward = new Vector2f(-1, 0);
                Position += Forward * Speed * dt;

            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {

                Forward = new Vector2f(0, 1);
                Position += Forward * Speed * dt;

            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {

                Forward = new Vector2f(1, 0);
                Position += Forward * Speed * dt;
            }

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
            b.Position = new Vector2f(Position.X - 40, Position.Y - 130);
            b.Forward = new Vector2f(0, -1);

        }

    }
}
