using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BulletHoles
{
    public class Boss : MonoBehaviour
    {
        [SerializeField] float maxHealth = 100f;
        [SerializeField] GameObject explosionPrefab;
        float health;

        Collider bossCollider;

        public List<BossStage> Stages;
        int currentStage = 0;

        public event Action OnHealthChanged;
        
        void Awake(){
            bossCollider = GetComponent<Collider>();
        }

        void Start(){
            health = maxHealth;
            bossCollider.enabled = true;

            foreach (var system in Stages.SelectMany(stage => stage.enemySystems)){
                system.OnSystemDestroyed.AddListener(CheckStageComplete);
            }

            InitializeStage();
        }

        public float GetHealthNormalized() => health / maxHealth;

        void CheckStageComplete(){
            if(Stages[currentStage].IsStageComplete()){
                AdvanceToNextStage();
            }
        }

        void AdvanceToNextStage() {
            currentStage++;
            bossCollider.enabled = true;

            if(currentStage < Stages.Count){
                InitializeStage();
            }
        }

        void InitializeStage(){
            Stages[currentStage].InitializeStage();

            /*foreach(var stage in Stages){
                foreach(var system in stage.enemySystems){
                    system.OnSystemDestroyed.AddListener(CheckStageComplete);
                }
            }*/

            bossCollider.enabled = !Stages[currentStage].IsBossInvulnerable;
        }

        void OnCollisionEnter(Collision other){
            health -= 10f;
            OnHealthChanged?.Invoke();
            if(health <= 0f){
                BossDefeated();
            }
        }

        void BossDefeated(){
            Debug.Log("Boss Defeated");
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
    }
}
