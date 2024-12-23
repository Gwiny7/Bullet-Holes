using System;
using UnityEngine;

namespace BulletHoles
{
    public abstract class Plane : MonoBehaviour{
        [SerializeField] int maxHealth;
        [SerializeField] DamageFlash _damageFlash;
        int health;

        protected virtual void Awake() => health = maxHealth;

        public void SetMaxHealth(int amount) => maxHealth = amount;

        public void TakeDamage(int amount){
            health -= amount;
            if(health <= 0){
                Die(maxHealth);
            }
            else{
                _damageFlash.CallDamageFlash();
            }
        }

        public void AddHealth(int amount){
            health += amount;
            if(health > maxHealth){
                health = maxHealth;
            }
        }

        public float GetHealthNormalized() => health /(float) maxHealth;
        protected abstract void Die(int health);
    }
}
