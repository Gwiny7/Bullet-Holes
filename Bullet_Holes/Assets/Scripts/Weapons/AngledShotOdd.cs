using UnityEngine;

namespace BulletHoles
{
    [CreateAssetMenu(fileName = "AngledShotOdd", menuName = "BulletHoles/WeaponStrategy/AngledShotOdd")]
    public class AngledShotOdd : WeaponStrategy{
        [SerializeField] float spreadAngle = 15f;
        [SerializeField] int numberShot = 3;
        public override void Fire(Transform firePoint, LayerMask layer)
        {
            for(int i = 0; i < numberShot; i++){
                GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
                projectile.transform.SetParent(firePoint);
                projectile.transform.Rotate(0f, 0f, spreadAngle * (i - numberShot/2));
                projectile.layer = layer;

                Projectile projectileComponent = projectile.GetComponent<Projectile>();
                projectileComponent.SetSpeed(projectileSpeed);
                projectileComponent.SetDuration(projectileLifetime);

                Destroy(projectile, projectileLifetime);
            }
        }
    }
}
