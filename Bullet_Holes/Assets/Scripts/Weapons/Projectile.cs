using System;
using UnityEngine;
namespace BulletHoles
{
    public class Projectile : MonoBehaviour{
        [SerializeField] float speed;
        [SerializeField] float duration;
        [SerializeField] GameObject muzzlePrefab;
        [SerializeField] GameObject hitPrefab;
        [SerializeField] GameObject projectilePrefab;
        [SerializeField] bool portal;

        Transform parent;

        public void SetSpeed(float speed){
            this.speed = speed;
        }

        public void SetParent(Transform parent){
            this.parent = parent;
        }

        public void SetDuration(float duration){
            this.duration = duration;
        }

        public Action Callback;

        void Start(){
            if(muzzlePrefab != null){
                //instantiate muzzle flash
                if(!portal){
                    GameObject muzzleVFX = Instantiate(muzzlePrefab, transform.position, Quaternion.identity);
                    muzzleVFX.transform.forward = gameObject.transform.forward;
                    muzzleVFX.transform.SetParent(parent);

                    DestroyParticleSystem(muzzleVFX);
                }
            }
        }

        void Update(){
            if(!portal){
                transform.SetParent(null);
            }
            transform.position += transform.up * (speed * Time.deltaTime);

            Callback?.Invoke();
        }

        void OnCollisionEnter(Collision collision){
            if(hitPrefab != null){
                ContactPoint contact = collision.contacts[0];
                if(collision.gameObject.GetComponent<Portal>() == null){
                    GameObject hitVFX = Instantiate(hitPrefab, contact.point, Quaternion.identity);
                    DestroyParticleSystem(hitVFX);
                }
            }

            Plane plane = collision.gameObject.GetComponent<Plane>();
            if(plane != null){
                plane.TakeDamage(10);
            }

            Destroy(gameObject);
        }

        public GameObject GetPrefab(){
            return projectilePrefab;
        }

        public float GetSpeed(){
            return speed;
        }

        public float GetDuration(){
            return duration;
        } 

        void DestroyParticleSystem(GameObject vfx){
            var ps = vfx.GetComponent<ParticleSystem>();
            if(ps == null){
                ps = vfx.GetComponentInChildren<ParticleSystem>();
            }
            Destroy(vfx, ps.main.duration);
        }

    }
}
