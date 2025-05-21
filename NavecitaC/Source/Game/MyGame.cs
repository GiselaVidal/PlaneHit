using NavecitaC.Source.Game;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace TcGame
{
    public class MyGame : Game
    {
        public Hud hud { private set; get; }
        public Background background { get; private set; }
        private static MyGame instance;


        public static MyGame Get
        {
            get
            {
                if (instance == null)
                {
                    instance = new MyGame();
                }

                return instance;
            }
        }
        private MyGame()
        {
        }
        public void Init()
        {
            background = Engine.Get.Scene.Create<Background>();
            Engine.Get.Scene.Create<Spaceship>();
            CreateTIEpawner();
            CreateMeteors();
        }

        private void CreateTIEpawner()
        {
            ActorSpawner<EvilSpaceship> spawner;
            spawner = Engine.Get.Scene.Create<ActorSpawner<EvilSpaceship>>();
            var win = Engine.Get.Window.Size;
            spawner.MinPosition = new Vector2f(100, 50);                      
            spawner.MaxPosition = new Vector2f(win.X - 100, win.Y - 300);
            spawner.MinTime = 1.0f;
            spawner.MaxTime = 10.0f;
            spawner.Reset();
        }

        private void CreateMeteors()
        {
            ActorSpawner<BigMeteor> spawner;
            spawner = Engine.Get.Scene.Create<ActorSpawner<BigMeteor>>();
            var win = Engine.Get.Window.Size;
            spawner.MinPosition = new Vector2f(100, 50);
            spawner.MaxPosition = new Vector2f(win.X - 100, win.Y - 300);
            spawner.MinTime = 1.0f;
            spawner.MaxTime = 10.0f;
            spawner.Reset();
        }


        public void DeInit()
        {
        }
        public void Update(float dt)
        {
            

        }
        private void DestroyAll<T>() where T : Actor
        {
            var actors = Engine.Get.Scene.GetAll<T>();
            actors.ForEach(x => x.Destroy());
        }
    }
}

