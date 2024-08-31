using UnityEngine;

namespace BulletHoles
{
    [CreateAssetMenu(fileName = "TripleShot", menuName = "BulletHoles/WeaponStrategy/TripleShot")]
    public class TripleShot : WeaponStrategy{
        [SerializeField] float spreadAngle = 15f;
        public override void Fire(Transform firePoint, LayerMask layer)
        {
            for(int i = 0; i < 3; i++){
                GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
                projectile.transform.SetParent(firePoint);
                projectile.transform.Rotate(0f, 0f, spreadAngle * (i - 1));
                projectile.layer = layer;

                Projectile projectileComponent = projectile.GetComponent<Projectile>();
                projectileComponent.SetSpeed(projectileSpeed);

                Destroy(projectile, projectileLifetime);
            }
        }
    }
}
