using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class MainMenuPanel : MonoBehaviour
{
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _buttonsPanel;

    private void Start()
    {
        _settingsPanel.SetActive(false);
    }

    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void SettingsButton()
    {
        _settingsPanel.SetActive(true);
        _buttonsPanel.SetActive(false);
    }

    public void exitButton()
    {
        Application.Quit();
    }


}
