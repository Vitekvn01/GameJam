using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanelPrefab;
    private PausePanel _pausePanel;

    private void Start()
    {
        _pausePanel = Instantiate(_pausePanelPrefab).GetComponent<PausePanel>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowPausePanel();
        }
    }

    public void ShowPausePanel()
    {
        _pausePanel.ShowPanel();
    }
}
