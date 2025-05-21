using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using TcGame;

namespace App.Source.Game
{
    internal class Meteor : StaticActor
    {
        public Meteor()
        {
            Sprite = new Sprite(new Texture("Data/Textures/meteorites/meteorite2.png"));
            Sprite.Color = Color.Red;
            Random r = new Random();
            Position = new Vector2f(r.Next(0, 1024), r.Next(0, 768));
            Forward = new Vector2f(r.Next(0, 1024), r.Next(0, 768)).Normal();
            Speed = 300;
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
                Scale *= 1.1f;
            }
            if (Position.Y < 0+wSprite || Position.Y > 768-wSprite)
            {
                Forward = new Vector2f(Forward.X, Forward.Y * -1);
                Scale *= 1.1f;
            }
            

        }
    }
}
