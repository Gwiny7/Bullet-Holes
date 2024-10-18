using UnityEngine;

namespace BulletHoles
{
    public class Portal : MonoBehaviour{
        [SerializeField] GameObject firePoint;
        Portal otherPortal;

        void OnCollisionEnter(Collision collision){
            Projectile projectile = collision.gameObject.GetComponent<Projectile>();
            if(projectile != null && otherPortal != null){
                otherPortal.Fire(firePoint.layer, projectile.GetPrefab(), projectile.GetSpeed(), projectile.GetDuration());
            }
        }

        public void Fire(LayerMask layer, GameObject projectilePrefab, float speed, float duration){
            GameObject projectile = Instantiate(projectilePrefab, firePoint.transform.position, firePoint.transform.rotation);
            projectile.transform.SetParent(firePoint.transform);
            projectile.layer = layer;

            Projectile projectileComponent = projectile.GetComponent<Projectile>();
            projectileComponent.SetSpeed(speed);

            Destroy(projectile, duration);
        }

        public void SetOther(Portal other){
            otherPortal = other;
        }

        public void DeletePortal(){
            otherPortal.SetOther(null);
            Destroy(gameObject);
        }
    }
}
