using System;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace BulletHoles
{
    public class MainMenuUI : MonoBehaviour{
        [SerializeField] String startingLevel;
        [SerializeField] Button playButton;
        [SerializeField] Button quitButton;

        void Awake(){
            playButton.onClick.AddListener(()=> Loader.Load(startingLevel));
            quitButton.onClick.AddListener(()=> Helpers.QuitGame());
            Time.timeScale = 1f;
        }
    }
}
