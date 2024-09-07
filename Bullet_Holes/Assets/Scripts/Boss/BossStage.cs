using System.Collections.Generic;
using UnityEngine;

namespace BulletHoles
{
    public class BossStage : MonoBehaviour{
        public List<Enemy> enemySystems;
        public bool IsBossInvulnerable = true;

        void Awake(){
            foreach(var system in enemySystems){
                system.gameObject.SetActive(false);
            }
        }

        public void InitializeStage(){
            foreach(var system in enemySystems){
                system.gameObject.SetActive(true);
            }
        }

        public bool IsStageComplete(){
            foreach(var system in enemySystems){
                if(system != null && system.GetHealthNormalized() > 0){
                    return false;
                }
            }

            return true;
        }
    }
}
