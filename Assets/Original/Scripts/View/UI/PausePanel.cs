using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _buttonPanel;

    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void ContinueButton()
    {
        // продолжаем игру
        Time.timeScale = 1;
        gameObject.SetActive(false);
        PlayerController.Instance.CamLogic.CursorLocked();
    }

    public void SettingsButton()
    {
        _buttonPanel.SetActive(false);
        _settingsPanel.SetActive(true);
    }

    public void ExitButton()
    {
        // выход в главное меню
        SceneManager.LoadScene(0);
    }

    public void ShowPanel()
    {
        PlayerController.Instance.CamLogic.CursorUnlocked();
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }
}
