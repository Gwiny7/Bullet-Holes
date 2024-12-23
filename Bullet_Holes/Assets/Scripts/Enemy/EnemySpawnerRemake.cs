using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

namespace BulletHoles
{
    public class EnemySpawnerRemake : MonoBehaviour {
        [SerializeField] List<EnemyType> enemyTypes;
        [SerializeField] int maxEnemies = 10;
        [SerializeField] float spawnInterval = 2f;

        List<SplineContainer> splines;
        EnemyFactoryRemake enemyFactory;

        float spawnTimer;
        int enemiesSpawned;

        void OnValidate(){
            splines = new List<SplineContainer>(GetComponentsInChildren<SplineContainer>());
        }

        void Start(){
            enemyFactory = new EnemyFactoryRemake();
        }

        void Update(){
            spawnTimer += Time.deltaTime;

            if(enemiesSpawned < maxEnemies && spawnTimer >= spawnInterval){
                SpawnEnemy();
                spawnTimer = 0f;
            }
        }

        void SpawnEnemy(){
            EnemyType enemyType = enemyTypes[UnityEngine.Random.Range(0, enemyTypes.Count)];
            SplineContainer spline = splines[UnityEngine.Random.Range(0, splines.Count)];
            
            enemyFactory.CreateEnemy(enemyType, spline);
            enemiesSpawned++;
        }
    }
}