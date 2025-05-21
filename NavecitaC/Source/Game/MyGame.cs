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
            Engine.Get.Scene.Create<EvilSpaceship>();
            CreateTIEpawner();
        }

        private void CreateTIEpawner()
        {
            ActorSpawner<EvilSpaceship> spawner;
            spawner = Engine.Get.Scene.Create<ActorSpawner<EvilSpaceship>>();
            spawner.MinPosition = new Vector2f(10.0f, 0.0f);
            spawner.MaxPosition = new Vector2f(1000.0f, 0.0f);
            spawner.MinTime = 8.0f;
            spawner.MinTime = 10.0f;
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

