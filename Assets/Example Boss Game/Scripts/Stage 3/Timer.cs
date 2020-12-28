using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeeNice
{
    public class Timer : MonoBehaviour
    {
        public Animator needleAnim;
        private float animLength;
        public Sprite[] cakeSprites;
        // Start is called before the first frame update
        void Start()
        {
            animLength = needleAnim.GetCurrentAnimatorStateInfo(0).length;
            Stage3.instance.LoseGame();
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}
