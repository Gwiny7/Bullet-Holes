using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class MenuController : MonoBehaviour
{
    public Slider volumeSlider;
    public Dropdown resolutionDropdown;
    private List<Resolution> resolutions = new List<Resolution>();

    private void Start()
    {
        volumeSlider.onValueChanged.AddListener(SetVolume);

        PopulateResolutionDropdown();
    }

    public void SetVolume(float volume) //Volume
    {
        AudioListener.volume = volume;
    }

    void PopulateResolutionDropdown()   //Resolução da tela
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        foreach (Resolution resolution in Screen.resolutions)
        {
            resolutions.Add(resolution);
            string option = resolution.width + " x " + resolution.height;
            options.Add(option);

            if (resolution.width == Screen.currentResolution.width && resolution.height == Screen.currentResolution.height)
            {
                currentResolutionIndex = resolutions.Count - 1;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        resolutionDropdown.onValueChanged.AddListener(delegate { SetResolution(resolutionDropdown.value); });
    }

    public void SetResolution(int resolutionIndex)  //Resolução da tela
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }    
}
