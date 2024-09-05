using UnityEngine;

namespace BulletHoles
{
    public class GameManager : MonoBehaviour{

        [SerializeField] string mainMenuName = "MainMenu";
        [SerializeField] GameObject gameOverUI;
        public static GameManager instance { get; private set; }
        public Player Player => player;

        Player player;
        int score;
        float restartTimer = 3f;

        public bool IsGameOver() => player.GetHealthNormalized() <= 0;

        void Awake() {
            instance = this;
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }

        void Update(){
            if(IsGameOver()){
                restartTimer -= Time.deltaTime;
                if(gameOverUI.activeSelf == false){
                    gameOverUI.SetActive(true);
                }

                if(restartTimer <= 0){
                    Loader.Load(mainMenuName);
                }
            }
        }

        public void AddScore(int amount){
            score += amount;
        }

        public int GetScore(){
            return score;
        }
    }
}
