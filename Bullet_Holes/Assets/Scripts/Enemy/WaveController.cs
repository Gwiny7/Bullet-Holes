using UnityEngine;

namespace BulletHoles
{
    public class WaveController : MonoBehaviour {
        [SerializeField] GameObject nextWave;
        [SerializeField] float timeToNext = 5.0f;
        [SerializeField] bool isLast = false;

        bool waveOver = false;

        //Repensar como fazer isso de forma mais bonitinha
        [SerializeField] bool isTutorial = true;
        [SerializeField] bool isInfinite = false;
        [SerializeField] GameObject screen;
        int enemies = 0;

        void Update(){
            if(!isInfinite){
                if(waveOver){
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
        }

        public void AddEnemy(){
            enemies++;
        }

        public void EnemyDied(){
            enemies--;

            if(enemies <= 0){
                waveOver = true;
            }
        }
    }
}
