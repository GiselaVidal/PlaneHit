using SFML.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcGame;

namespace NavecitaC.Source.Game
{
    internal class SoundLaser : Actor
    {
        float timer = 0;
        public SoundLaser() 
        {
            SoundBuffer soundLaser = new SoundBuffer("Data/sounds/laser.ogg");
            Sound s = new Sound(soundLaser);
            s.Loop = false  ;
        }
        public override void Update(float dt) 
        {
            base.Update(dt);
            timer++;
            
            {
                
            }
            if (timer > 1)
            {
                Destroy();
            }
        }
    }
}
