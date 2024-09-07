using UnityEngine;

namespace BulletHoles
{
    public class HealthItem : Item {
        void OnTriggerEnter(Collider other){
            other.GetComponent<Player>().AddHealth((int) amount);
            Destroy(gameObject);
        }
    }
}
