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
    public class EvilSpaceship : StaticActor
    {
        public EvilSpaceship() { 
        
            Layer = ELayer.Front;
            Sprite = new Sprite(new Texture("Data/Textures/enemy/TIE-Sized.png"));
            //Position = new SFML.System.Vector2f(Engine.Get.Window.Size.X / 2, Engine.Get.Window.Size.Y / 2 + 100);
            Speed = 80;
            Center();
            Forward = new Vector2f(0, 1);

        }

    }
}
