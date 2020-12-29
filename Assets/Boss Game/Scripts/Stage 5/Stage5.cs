using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeeNice
{
    public class Stage5 : StageController
    {
        public static StageController instance;
        public float stageLength;
        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
            instance = this;
            StartCoroutine(EndStage(stageLength));
        }
        private IEnumerator EndStage(float delay)
        {
            yield return new WaitForSeconds(stageLength);
            gameWon.Invoke();
        }
    }
}
