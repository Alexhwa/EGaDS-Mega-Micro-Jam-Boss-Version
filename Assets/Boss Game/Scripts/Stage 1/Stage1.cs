using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BeeNice
{
    public class Stage1 : StageController
    {
        public static StageController instance;
        public Spawner spawner;
        public float stageLength;
        public Slider timer;
        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
            instance = this;
            gameWon.AddListener(WipeScene);
        }

        private void WipeScene()
        {
            //spawner.StopSpawning();
        }
        private void FixedUpdate()
        {
            timer.value -= Time.deltaTime;
            if(timer.value < 0)
            {
                LoseGame();
            }
        }
    }
}
