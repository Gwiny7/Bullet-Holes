using UnityEngine;

namespace BulletHoles
{
    public class Portal : MonoBehaviour{
        [SerializeField] GameObject firePoint;
        [SerializeField] int life = 3;
        [SerializeField] SpriteRenderer sprite;
        int maxLife;
        Portal otherPortal;
        Transform cam;

        void Start(){
            maxLife = life;
        }

        public void SetCamera(Transform camera){
            cam = camera;
        }

        void OnCollisionEnter(Collision collision){
            Projectile projectile = collision.gameObject.GetComponent<Projectile>();
            if(projectile != null && otherPortal != null){
                otherPortal.Fire(firePoint.layer, projectile.GetPrefab(), projectile.GetSpeed(), projectile.GetDuration());
                life--;
                if(life <= 0){
                    DeletePortal();
                }
                
                else if(life <= (maxLife / 3)){
                    sprite.color = Color.red;
                }

                else if(life <= (maxLife / 1.5f)){
                    sprite.color = Color.yellow;
                }
            }
        }

        public void Fire(LayerMask layer, GameObject projectilePrefab, float speed, float duration){
            GameObject projectile = Instantiate(projectilePrefab, firePoint.transform.position, firePoint.transform.rotation, cam);
            projectile.layer = layer;

            Projectile projectileComponent = projectile.GetComponent<Projectile>();
            projectileComponent.SetSpeed(speed);

            Destroy(projectile, duration);
        }

        public void SetOther(Portal other){
            otherPortal = other;
        }

        public void DeletePortal(){
            //otherPortal.SetOther(null);
            Destroy(gameObject);
        }
    }
}
