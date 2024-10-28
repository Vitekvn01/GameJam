
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SubtitlesController : MonoBehaviour
{
    [SerializeField] private bool _isPlaySubtitles;

    [SerializeField] private GameObject _panelSubtitles;

    [SerializeField] private List<SubtitlesString> _currentSubtitlesContainer = new List<SubtitlesString>();

    /*    [SerializeField] private List<AudioClip> audioClip = new List<AudioClip>();*/
    /*    private AudioSource audioSource;*/
    /*    [SerializeField] private AudioMixer audioMixerMusic;*/
    /*    [SerializeField] private Image Image;*/

    [SerializeField] private TextMeshProUGUI _textSubtitles;
    [SerializeField] private TextMeshProUGUI _nameSubtitles;

    [SerializeField] private float _endTime;

    [SerializeField] private UnityEvent _endSubtitles;


    private float timer = 0;
    private int index = 0;

    private void Start()
    {
        _panelSubtitles.SetActive(false);

        if (_isPlaySubtitles)
        {
            _panelSubtitles.SetActive(true);
            DrawText();
        }
    }

    private void Update()
    {
        if (_isPlaySubtitles)
        {
            timer += Time.deltaTime;

            if (timer >= _endTime)
            {
                NextPage();
                timer = 0;
            }
        }
    }

    private void DrawText()
    {
        _textSubtitles.text = _currentSubtitlesContainer[index].Text;
        _nameSubtitles.text = _currentSubtitlesContainer[index].Name;
    }
    private void NextPage()
    {
        index += 1;
        if (index < _currentSubtitlesContainer.Count)
        {
            DrawText();
        }
        else
        {
            _isPlaySubtitles = false;
            index = 0;
            _endSubtitles.Invoke();
            gameObject.SetActive(false);
        }
    }

    private void StartPrologue(List<SubtitlesString> subtitlesContainer)
    {
        _currentSubtitlesContainer = subtitlesContainer;
        index = 0;
        _panelSubtitles.SetActive(true);
        DrawText();
    }
}
