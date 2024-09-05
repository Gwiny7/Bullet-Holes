using UnityEngine;

namespace BulletHoles
{
    public class GameManager : MonoBehaviour{
        public static GameManager instance { get; private set; }
        Player player;
        int score;

        public bool IsGameOver() => player.GetHealthNormalized() <= 0;

        void Awake() {
            if(instance == null){
                instance = this;
                DontDestroyOnLoad(gameObject);
            }

            else{
                Destroy(gameObject);
            }

            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }

        public void AddScore(int amount){
            score += amount;
        }

        public int GetScore(){
            return score;
        }
    }
}
