﻿using SFML.Graphics;
using SFML.System;
using SFML.Window;
using static SFML.Graphics.Text;

namespace TcGame
{
    public class Laser : StaticActor
    {
        private float Timer;
        public Laser()
        {
            Layer = ELayer.Front;
            Sprite = new Sprite(new Texture("Data/Textures/laser/round_laser.png"));
            Speed = 0;
            Sprite.Color = Color.Green;
        }

        public override void Update(float dt)
        {
            base.Update(dt);

            if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
            {
                Speed = 600f;
            }

            Timer += dt;
            if (Timer >= 5)
            {
                Engine.Get.Scene.Destroy(this);
            }
        }
    }
}
