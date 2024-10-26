using UnityEngine;

namespace BulletHoles
{
    public class HealthItem : Item {
        void OnTriggerEnter(Collider other){
            Player player = other.GetComponent<Player>();
            if(player != null){
                other.GetComponent<Player>().AddHealth((int) amount);
                Destroy(gameObject);
            }
        }
    }
}
