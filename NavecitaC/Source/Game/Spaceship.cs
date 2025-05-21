using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace TcGame
{
 public class Spaceship : StaticActor
  {
    private float coolDown = 0.5f;
    private float temps = 0;
   
       
    public Spaceship()
    {
      Sprite = new Sprite(new Texture("Data/Textures/Player/spaceship.png"));
      Position = (Vector2f) Engine.Get.Window.Size / 2;
      Speed = 0;
      Center();
    }

    public override void Update (float dt)
        {
            base.Update (dt);
         
        }
    private void Follow()
    {
      Forward = (Engine.Get.MousePos - Position).Normal();
      Rotation = (float) Math.Atan2(Forward.Y, Forward.X) * MathUtil.RAD2DEG + 90;
     
    }
 
    
  }
}
