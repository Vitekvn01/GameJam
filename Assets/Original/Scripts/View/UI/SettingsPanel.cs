using UnityEngine;
using UnityEngine.Audio;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private GameObject ButtonPanel;

/*    [SerializeField] private GameObject checkFullScreen;*/

/*    [SerializeField] private AudioMixer am;*/

    private void Start()
    {
        gameObject.SetActive(false);
/*
        if (!Screen.fullScreen)
        {
            checkFullScreen.SetActive(false);
        }
        else
        {
            checkFullScreen.SetActive(true);
        }
*/
    }
    private void Update()
    {

    }

/*    public void fullScreen()
    {
        if (!Screen.fullScreen)
        {
            Screen.fullScreen = true;
            checkFullScreen.SetActive(true);
        }
        if (Screen.fullScreen)
        {
            Screen.fullScreen = false;
            checkFullScreen.SetActive(false);
        }
    }*/
/*    public void AudioVolume(float sliderValue)
    {
        am.SetFloat("MasterVolume", sliderValue);
    }*/
    public void closePanel()
    {
        gameObject.SetActive(false);
        ButtonPanel.SetActive(true);
    }
}
