using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BulletHoles
{
    public class Pause : MonoBehaviour
    {
        BulletHolesAction playerControls;
        InputAction menu;

        [SerializeField] GameObject pauseUI;
        [SerializeField] bool isPaused;
        // Start is called before the first frame update
        void Awake()
        {
            playerControls = new BulletHolesAction();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnEnable(){
            menu = playerControls.Player.Pause;
            menu.Enable();

            menu.performed += PauseMet;
        }

        private void OnDisable(){
            menu.Disable();
        }

        private void PauseMet(InputAction.CallbackContext context){
            isPaused = !isPaused;
            if(isPaused){
                ActivateMenu();
            }
            else{
                DeactivateMenu();
            }
        }

        public void DeactivateMenu()
        {
            Time.timeScale = 1;
            pauseUI.SetActive(false);
            isPaused = false;
        }

        void ActivateMenu()
        {
            Time.timeScale = 0;
            pauseUI.SetActive(true);
        }
    }
}
