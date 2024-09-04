using System;
using System.Collections;
using System.Collections.Generic;
using MEC;
using UnityEngine.SceneManagement;

namespace BulletHoles
{
    public static class Loader
    {
        static String targetScene;

        public static void Load(String scene){
            targetScene = scene;
            SceneManager.LoadScene("LoadingScreen");
            Timing.RunCoroutine(LoadTargetScene());
        }

        static IEnumerator<float> LoadTargetScene()
        {
            yield return Timing.WaitForOneFrame;
            SceneManager.LoadScene(targetScene);
        }
    }
}
