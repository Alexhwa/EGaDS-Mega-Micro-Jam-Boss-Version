using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeeNice
{
    public class Spawner : MonoBehaviour
    {
        public Transform[] spawnPoints;
        public GameObject[] spawnItems;
        public float spawnDelay;
        // Start is called before the first frame update
        void Start()
        {
            if (spawnPoints.Length == 0)
            {
                spawnPoints = new Transform[transform.childCount];
                int index = 0;
                foreach (Transform e in transform)
                {
                    spawnPoints[index] = e;
                    index++;
                }
            }
            StartCoroutine(SpawnItem(0));
        }

        private IEnumerator SpawnItem(float delay)
        {
            yield return new WaitForSeconds(delay);
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(spawnItems[Random.Range(0, spawnItems.Length)], spawnPoint.position, spawnPoint.rotation);
            StartCoroutine(SpawnItem(spawnDelay));
        }
        public void StopSpawning()
        {
            StopAllCoroutines();
            foreach (Ingredient g in GameObject.FindObjectsOfType<Ingredient>())
            {
                Destroy(g.gameObject);
            }
        }
    }
}
