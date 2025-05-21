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
    internal class SmallMeteor : StaticActor
    {
        public SmallMeteor() 
        {
            Sprite = new Sprite(new Texture("Data/Textures/meteorites/meteorite3.png"));
            Sprite.Color = Color.Red;
            Random r = new Random();
            Position = Position;
            Forward = new Vector2f(r.Next(0, 1024), r.Next(0, 768)).Normal();
            Speed = 400;
            Center();
        }
        public override void Update(float dt)
        {
            base.Update(dt);
            float wSprite = GetLocalBounds().Width / 2;
            Rotation = 30f * dt;

            if (Position.X < 0 + wSprite || Position.X > 1024 - wSprite)
            {
                Forward = new Vector2f(Forward.X * -1, Forward.Y);
            }
            if (Position.Y < 0 + wSprite || Position.Y > 768 - wSprite)
            {
                Forward = new Vector2f(Forward.X, Forward.Y * -1);
            }

            CheckCollision();
        }
        private void CheckCollision()
        {
            List<Spaceship> spaceships = Engine.Get.Scene.GetAll<Spaceship>();

            foreach (Spaceship spaceship in spaceships)
            {
                if (spaceship.GetGlobalBounds().Intersects(GetGlobalBounds()))
                {
                    spaceship.Destroy();

                }
            }
        }
        
    }
}
