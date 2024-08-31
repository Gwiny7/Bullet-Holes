using UnityEngine;
using Utilities;

namespace BulletHoles
{
    [CreateAssetMenu(fileName = "PlayerTrackingShot", menuName = "BulletHoles/WeaponStrategy/PlayerTrackingShot")]
    public class TrackingShot : WeaponStrategy{
        [SerializeField]float trackingSpeed = 1f;

        Transform target;

        public override void Initialize()
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        public override void Fire(Transform firePoint, LayerMask layer)
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            projectile.transform.SetParent(firePoint);
            projectile.layer = layer;

            Projectile projectileComponent = projectile.GetComponent<Projectile>();
            projectileComponent.SetSpeed(projectileSpeed);
            projectile.GetComponent<Projectile>().Callback = () => {
                //get direction to target with Z as firepoint
                Vector3 direction = (target.position - projectile.transform.position).With(firePoint.position.z).normalized;

                //rotate forward, with Z as the UP direction (i.e 0,0,1 aka Vector3.forward)
                Quaternion rotation = Quaternion.LookRotation(direction, Vector3.forward);
                projectile.transform.rotation = Quaternion.Slerp(projectile.transform.rotation, rotation, trackingSpeed * Time.deltaTime);
            };

            Destroy(projectile, projectileLifetime);
        }
    }
}
