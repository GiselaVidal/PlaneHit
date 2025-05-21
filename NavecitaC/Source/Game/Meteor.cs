using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using TcGame;

namespace App.Source.Game
{
    internal class Meteor: StaticActor
    {
        public Meteor()
        {
            Sprite = new Sprite(new Texture("Data/Textures/meteorite.png"));
            Sprite.Color = Color.Red;
            Random r = new Random();    
            Position = new Vector2f(r.Next(0, 1024), r.Next(0, 768));
            Center();
        }

    }
}
