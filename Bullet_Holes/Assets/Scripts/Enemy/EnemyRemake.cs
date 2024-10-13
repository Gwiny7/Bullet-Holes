using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Splines;

namespace BulletHoles
{
    public class EnemyRemake : Plane {
        [SerializeField] GameObject explosionPrefab;
        [SerializeField] float speed = 0.5f;
        [SerializeField] float timeChangeMove = 0;
        [SerializeField] WaveController wave;

        SplineAnimate spline;
        float changeMove;
        Movement move = Movement.Down;

        void Awake(){
            spline = gameObject.GetComponent<SplineAnimate>();
            spline.Container = gameObject.GetComponentInParent<SplineContainer>();

            wave.AddEnemy();
        }

        void Update(){
                if(!spline.IsPlaying){
                    changeMove -= Time.deltaTime;

                    if(move == Movement.Down){
                        transform.position += Vector3.down * (speed * Time.deltaTime);
                        if(changeMove <= 0){
                            move = Movement.Up;
                            changeMove = timeChangeMove * 2;
                        }
                    }
                    else{
                        transform.position += Vector3.up * (speed * Time.deltaTime);
                        if(changeMove <= 0){
                            move = Movement.Down;
                            changeMove = timeChangeMove * 2;
                        }
                    }
                }
        }

        protected override void Die(int health)
        {
            GameManager.instance.AddScore(10);
            GameManager.instance.IncreaseMayhem(health);
            //Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            wave.EnemyDied();
            OnSystemDestroyed?.Invoke();
            Destroy(gameObject);
        }

        public UnityEvent OnSystemDestroyed;
    }
}
