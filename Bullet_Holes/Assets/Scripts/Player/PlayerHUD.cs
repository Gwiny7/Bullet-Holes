using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace BulletHoles
{
    public class PlayerHUD: MonoBehaviour{
        [SerializeField] Image healthBar;
        [SerializeField] TextMeshProUGUI scoreText; 

        void Update(){
            healthBar.fillAmount = GameManager.instance.Player.GetHealthNormalized();
            scoreText.text = $"score: {GameManager.instance.GetScore()}";
        }
    }
}
