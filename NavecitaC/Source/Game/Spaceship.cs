﻿
using NavecitaC.Source.Game;
using SFML.Audio;
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
            SoundLaser s = Engine.Get.Scene.Create<SoundLaser>();
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
            List<BigMeteor> meteors = Engine.Get.Scene.GetAll<BigMeteor>();
            List<Laser> lasers = Engine.Get.Scene.GetAll<Laser>();
            List<SmallMeteor> smallmeteor = Engine.Get.Scene.GetAll<SmallMeteor>();
            List<EvilSpaceship> evilships = Engine.Get.Scene.GetAll<EvilSpaceship>();

            foreach (BigMeteor meteor in meteors)
            {
                foreach (Laser laser in lasers)
                {
                    if (laser.GetGlobalBounds().Intersects(meteor.GetGlobalBounds()))
                    {
                        meteor.Destroy();
                        laser.Destroy();
                        Hud h = Engine.Get.Scene.GetFirst<Hud>();
                        for(int  i = 1; i < 3; i++) { h.ShotDown(); }
                            
                        
                    }
                }
                
            }
            foreach (EvilSpaceship shipevil in evilships)
            {
                foreach (Laser laser in lasers)
                {
                    if (laser.GetGlobalBounds().Intersects(shipevil.GetGlobalBounds()))
                    {
                        shipevil.Destroy();
                        laser.Destroy();
                        Hud h = Engine.Get.Scene.GetFirst<Hud>();
                        h.ShotDown();
                    }
                }
            }
            foreach (SmallMeteor small in smallmeteor)
            {
                foreach (Laser laser in lasers)
                {
                    if (laser.GetGlobalBounds().Intersects(small.GetGlobalBounds()))
                    {
                        small.Destroy();
                        laser.Destroy();
                        Hud h = Engine.Get.Scene.GetFirst<Hud>();
                        h.ShotDown();
                    }
                }
            }
        }
    }
}
