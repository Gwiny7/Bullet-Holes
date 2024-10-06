using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

namespace BulletHoles
{
    public class FixedSpawner : MonoBehaviour{
        [SerializeField] List<EnemyType> enemyTypes;
        [SerializeField] GameObject nextWave;
        [SerializeField] float timeToNext = 5.0f;
        [SerializeField] bool isLast = false;

        //Repensar como fazer isso de forma mais bonitinha
        [SerializeField] bool isTutorial = true;
        [SerializeField] GameObject screen;

        List<SplineContainer> splines;
        EnemyFactory enemyFactory;
        int enemiesSpawned = 0;

        void OnValidate(){
            splines = new List<SplineContainer>(GetComponentsInChildren<SplineContainer>());
        }

        void Start(){
            enemyFactory = new EnemyFactory();
            SpawnEnemies();
        }

        void Update(){
            if(enemiesSpawned <= 0){
                timeToNext -= Time.deltaTime;
                if(timeToNext <= 0.0f){
                    if(!isLast){
                        if(isTutorial){
                            screen.SetActive(true);
                            Time.timeScale = 0;
                        }
                        nextWave.SetActive(true);
                        Destroy(gameObject);
                    }
                }
            }
        }

        void SpawnEnemies(){
            EnemyType enemyType = enemyTypes[UnityEngine.Random.Range(0, enemyTypes.Count)];
            for(int x = 0; x < splines.Count; x++){
                Debug.Log(splines.Count);
                SplineContainer spline = splines[x];
                enemyFactory.CreateEnemy(enemyType, spline, gameObject.GetComponent<FixedSpawner>());
            }
            enemiesSpawned = splines.Count;
        }

        public void EnemyDied(){
            enemiesSpawned--;
        }
    }
}
