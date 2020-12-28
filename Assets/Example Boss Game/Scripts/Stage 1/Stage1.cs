using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeeNice
{
    public class Stage1 : StageController
    {
        public static StageController instance;
        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
            instance = this;
        }

        IEnumerator EndGame()
        {
            yield return new WaitForSeconds(2);
            gameEnd.Invoke();
        }
    }
}
