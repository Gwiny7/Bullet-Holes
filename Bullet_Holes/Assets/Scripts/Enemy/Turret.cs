using UnityEngine;
using UnityEngine.Events;

namespace BulletHoles
{
    public class Turret : Plane{
        [SerializeField] GameObject explosionPrefab;

        protected override void Die(int health)
        {
            GameManager.instance.AddScore(10);
            //Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            OnSystemDestroyed?.Invoke();
            Destroy(gameObject);
        }

        public UnityEvent OnSystemDestroyed;
    }
}
