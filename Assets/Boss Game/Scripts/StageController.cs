using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BeeNice
{
    public class StageController : MonoBehaviour
    {
        [HideInInspector]
        public UnityEvent gameWon;
        // Start is called before the first frame update
        protected virtual void Start()
        {
            if(gameWon == null)
            {
                gameWon = new UnityEvent();
            }
        }

        public virtual void LoseGame()
        {
            BossGameManager.Instance.bossGame.gameWin = false;
            BossGameManager.Instance.bossGame.gameOver = true;
        }
    }
}
