using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace BulletHoles
{
    public class GameManager : MonoBehaviour{

        [SerializeField] string NextLevel = "MainMenu";
        [SerializeField] GameObject gameOverUI;
        [SerializeField] bool bossLevel = false;
        [SerializeField] int maxMayhem = 100;
        [SerializeField] Image mayhemBar;
        int mayhem;
        public static GameManager instance { get; private set; }
        public Player Player => player;

        Player player;
        Boss boss;
        int score;
        float restartTimer = 3f;

        public bool IsPlayerDead() => player.GetHealthNormalized() <= 0;

        public bool IsGameOver() => GetMayhemNormalized() <= 0;

        public bool IsBossOver() => boss.GetHealthNormalized() <= 0;

        void Awake() {
            instance = this;
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            if(bossLevel){
                boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
            }
            else{
                mayhem = maxMayhem;
            }
        }

        void Update(){
            if(IsPlayerDead()){
                if(IsBossOver()){
                    restartTimer -= Time.deltaTime;
                    if(gameOverUI.activeSelf == false){
                        gameOverUI.SetActive(true);
                    }

                    if(restartTimer <= 0){
                        Loader.Load("MainMenu");
                    }
                }
            }

            if(bossLevel){
                if(IsBossOver()){
                    restartTimer -= Time.deltaTime;
                    if(gameOverUI.activeSelf == false){
                        gameOverUI.SetActive(true);
                    }

                    if(restartTimer <= 0){
                        Loader.Load(NextLevel);
                    }
                }
            }

            else{
                if(IsGameOver()){
                    restartTimer -= Time.deltaTime;
                    if(gameOverUI.activeSelf == false){
                        gameOverUI.SetActive(true);
                    }

                    if(restartTimer <= 0){
                        Loader.Load(NextLevel);
                    }
                }
            }
        }

        public void AddScore(int amount){
            score += amount;
        }

        public void IncreaseMayhem(int amount){
            mayhem -= amount;
            mayhemBar.fillAmount = GetMayhemNormalized();
        }

        public float GetMayhemNormalized() => mayhem /(float) maxMayhem;

        public int GetScore(){
            return score;
        }
    }
}
