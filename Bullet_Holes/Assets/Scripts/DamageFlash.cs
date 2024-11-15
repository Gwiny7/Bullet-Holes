using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BulletHoles
{
    public class DamageFlash : MonoBehaviour
    {
        [SerializeField] private Color _flashColor = Color.white;
        [SerializeField] private float _flashTime = 0.25f;
        private Coroutine _damageFlashCoroutine;

        private SpriteRenderer renderer;
        private Material material;

        private void Awake(){
            renderer = GetComponentInChildren<SpriteRenderer>();
            material = renderer.material;
        }

        public void CallDamageFlash(){
            _damageFlashCoroutine = StartCoroutine(DamageFlasher());
        }

        private IEnumerator DamageFlasher(){
            //Set the Color
            SetColor();

            //Lerp the Flash Amount
            float currentFlashAmount = 0.0f;
            float elapsedTime = 0.0f;
            while(elapsedTime < _flashTime){
                elapsedTime += Time.deltaTime;

                currentFlashAmount = Mathf.Lerp(1f, 0f, (elapsedTime/_flashTime));
                SetAmount(currentFlashAmount);

                yield return null;
            }
        }

        private void SetColor(){
            material.SetColor("_FlashColor", _flashColor);
        }

        private void SetAmount(float amount){
            material.SetFloat("_FlashAmount", amount);
        }
    }
}
