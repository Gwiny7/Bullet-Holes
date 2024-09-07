using UnityEngine.UI;
using UnityEngine;

namespace BulletHoles
{
    public class BossHealthBar : MonoBehaviour {
        [SerializeField] Boss boss;
        [SerializeField] Image healthBar;

        void Awake() {
            boss.OnHealthChanged += OnHealthChanged;
        }

        void OnHealthChanged(){
            healthBar.fillAmount = boss.GetHealthNormalized();
        }
    }
}
