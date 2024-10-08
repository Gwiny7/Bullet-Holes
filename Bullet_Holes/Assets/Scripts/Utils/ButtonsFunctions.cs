using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BulletHoles
{
    public class ButtonFunctions : MonoBehaviour
    {
        public static void Pause(bool pause){
            if(pause){
                Time.timeScale = 0;
            }

            else{
                Time.timeScale = 1;
            }
        }

        public static void LoadScene(string name){
            Loader.Load(name);
        }

        public static void QuitGame(){
            Application.Quit();
        }
    }
}
