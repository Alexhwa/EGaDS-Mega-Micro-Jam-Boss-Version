using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BeeNice
{
    public class StageController : MonoBehaviour
    {
        [HideInInspector]
        public UnityEvent gameEnd;
        // Start is called before the first frame update
        protected virtual void Start()
        {
            if(gameEnd == null)
            {
                gameEnd = new UnityEvent();
            }
        }

        public virtual void LoseGame()
        {
            BossGameManager.Instance.bossGame.gameWin = false;
            BossGameManager.Instance.bossGame.gameOver = true;
        }
    }
}
