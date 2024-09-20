using UnityEngine;
using UnityEngine.Events;

namespace BulletHoles
{
    public class Enemy : Plane{
        [SerializeField] GameObject explosionPrefab;
        EnemySpawner spawner;

        void Start(){
            spawner = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemySpawner>();
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
