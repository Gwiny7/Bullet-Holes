using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Splines;

public enum Movement
{
    Down,
    Up
}

namespace BulletHoles
{
    public class Enemy : Plane{
        [SerializeField] GameObject explosionPrefab;
        [SerializeField] float speed = 0.5f;
        [SerializeField] float timeChangeMove = 0;
        float changeMove;
        SplineAnimate spline;
        EnemySpawner spawner;
        Movement move = Movement.Down;

        void Start(){
            spawner = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemySpawner>();
            spline = gameObject.GetComponent<SplineAnimate>();
            changeMove = timeChangeMove;
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
            spawner.EnemyDied();
            OnSystemDestroyed?.Invoke();
            Destroy(gameObject);
        }

        public UnityEvent OnSystemDestroyed;
    }
}
