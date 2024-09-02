using UnityEngine;

namespace BulletHoles
{
    [CreateAssetMenu(fileName = "AngledShotEven", menuName = "BulletHoles/WeaponStrategy/AngledShotEven")]
    public class AngledShotEven : WeaponStrategy{
        [SerializeField] float spreadAngle = 15f;
        [SerializeField] int numberShot = 3;
        public override void Fire(Transform firePoint, LayerMask layer)
        {
            for(int i = 0; i <= numberShot; i++){
                if((i - (numberShot/2)) != 0){
                    GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
                    projectile.transform.SetParent(firePoint);
                    projectile.transform.Rotate(0f, 0f, spreadAngle * (i - numberShot/2));
                    projectile.layer = layer;

                    Projectile projectileComponent = projectile.GetComponent<Projectile>();
                    projectileComponent.SetSpeed(projectileSpeed);

                    Destroy(projectile, projectileLifetime);
                }
            }
        }
    }
}
