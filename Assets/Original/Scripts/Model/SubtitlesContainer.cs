using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public struct SubtitlesString
{
    [SerializeField] public string Name;

    [SerializeField] public string Text;

}

public class SubtitlesContainer : MonoBehaviour
{
    [SerializeField] bool _isActivated = false;

    [SerializeField] private List<SubtitlesString> _subtitlesList = new List<SubtitlesString>();

    [SerializeField] private UnityEvent _onEndSubtitles = new UnityEvent();

    public void PlaySubtitlesContainer()
    {
        if (_isActivated)
        {
            SubtitlesController.Instance.StartPrologue(_subtitlesList);
            SubtitlesController.Instance.OnEndSubtitles.AddListener(OnEndSubtiles);
            SubtitlesController.Instance.OnEndSubtitles.AddListener(DisactivatedSubtitlesContainer);
        }
    }

    public void ActivatedSubtitlesContainer()
    {
        _isActivated = true;
    }

    public void DisactivatedSubtitlesContainer()
    {
        _isActivated = false;
    }

    public void OnEndSubtiles()
    {
        _onEndSubtitles.Invoke();
    }

    private void OnDisable()
    {
        SubtitlesController.Instance.OnEndSubtitles.RemoveListener(DisactivatedSubtitlesContainer);
    }
}
