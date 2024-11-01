using System.Collections.Generic;
using MEC;
using UnityEngine;
using Utilities;

namespace BulletHoles
{
    public class WaveSpawner : MonoBehaviour{
        [SerializeField] GameObject[] itemPrefabs;
        [SerializeField] float spawnInterval = 3f;
        [SerializeField] float spawnRadius = 3f;
        [SerializeField] float distance = 1f;

        CoroutineHandle spawnCoroutine;

        void Start() => spawnCoroutine = Timing.RunCoroutine(SpawnItems());

        void OnDestroy(){
            Timing.KillCoroutines(spawnCoroutine);
        }

        IEnumerator<float> SpawnItems(){
            while (true){
                yield return Timing.WaitForSeconds(spawnInterval);
                var item = Instantiate(itemPrefabs[Random.Range(0, itemPrefabs.Length)]);
                item.transform.position = new Vector3(transform.position.x + distance, transform.position.y + (Random.Range(-1, 1) * spawnRadius), 0);
            }
        }
    }
}
