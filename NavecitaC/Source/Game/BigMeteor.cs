using System;
using System.Collections.Generic;
using NavecitaC.Source.Game;
using SFML.Graphics;
using SFML.System;
using TcGame;

namespace TcGame
{
    internal class BigMeteor : StaticActor
    {
        public BigMeteor()
        {
            Sprite = new Sprite(new Texture("Data/Textures/meteorites/meteorite1.png"));
            Sprite.Color = Color.Red;
            Random r = new Random();
     
            Spaceship ship = Engine.Get.Scene.GetFirst<Spaceship>();
            Vector2f shipPos = new Vector2f(512, 384);

            if (ship != null)
                shipPos = ship.Position;
            Vector2f spawnPos;
            float mindist = 150f;
            do
            {
                float x = r.Next(0, 1024);
                float y = r.Next(0, 768);
                spawnPos = new Vector2f(x, y);
            }while(Distance(spawnPos,shipPos) < mindist);

            Position = spawnPos;
            Forward = new Vector2f(r.Next(0, 1024), r.Next(0, 768)).Normal();
            Speed = 250;
            Center();
        }
        float timer = 0;
        public override void Update(float dt)
        {
            base.Update(dt);
            timer += dt;
            float wSprite = GetLocalBounds().Width / 2;
            Rotation = 30f * dt;

            if (Position.X < 0 + wSprite || Position.X > 1024 - wSprite)
            {
                Forward = new Vector2f(Forward.X * -1, Forward.Y);
                if (timer > 2)
                {
                    Scale *= 1.1f;
                }
                
            }
            if (Position.Y < 0+wSprite || Position.Y > 768-wSprite)
            {
                Forward = new Vector2f(Forward.X, Forward.Y * -1);
                if (timer > 2)
                {
                    Scale *= 1.1f;
                }
            }
            if (timer > 2)
            {
                CheckCollision();
            }
            
        }
        private float Distance(Vector2f a,Vector2f b)
        {
            float distX = a.X - b.X;
            float distY = a.Y - b.Y;
            return (float)Math.Sqrt(distX * distX + distY * distY);
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
