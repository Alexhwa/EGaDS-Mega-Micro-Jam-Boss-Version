using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeeNice
{
    public class Stage1 : StageController
    {
        public static StageController instance;
        public Spawner spawner;
        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
            instance = this;
            gameWon.AddListener(WipeScene);
        }

        private void WipeScene()
        {
            spawner.StopSpawning();
        }
    }
}
