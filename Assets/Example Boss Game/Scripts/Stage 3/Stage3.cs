using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeeNice
{
    public class Stage3 : StageController
    {
        public static StageController instance;
        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
            instance = this;
        }
    }
}
