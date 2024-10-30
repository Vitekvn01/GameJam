
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SubtitlesController : SingletonBase<SubtitlesController>
{
    [SerializeField] private bool _isPlaySubtitles;
    private bool _isActivated;

    [SerializeField] private GameObject _panelSubtitles;

    [SerializeField] private List<SubtitlesString> _currentSubtitlesContainer = new List<SubtitlesString>();

    /*    [SerializeField] private List<AudioClip> audioClip = new List<AudioClip>();*/
    /*    private AudioSource audioSource;*/
    /*    [SerializeField] private AudioMixer audioMixerMusic;*/
    /*    [SerializeField] private Image Image;*/

    [SerializeField] private TextMeshProUGUI _textSubtitles;
    [SerializeField] private TextMeshProUGUI _nameSubtitles;

    [SerializeField] private float _endTime;

    [SerializeField] public UnityEvent OnEndSubtitles = new UnityEvent();

    private GameObject workWhitObject; // !!!!!!!!
    private bool state;

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
            OnEndSubtitles.Invoke();
            _panelSubtitles.SetActive(false);

            //!!!!
            if(workWhitObject != null)
            {
                workWhitObject.TryGetComponent<InteractionObject>(out InteractionObject interObject);
                
                if(interObject != null)
                {
                    if(state == true)
                    {
                        interObject.ChangeState(false);
                    }
                    else
                    {
                        interObject.ChangeState(true);
                    }
                }
               
            }
        }
    }

    //public void StartPrologue(List<SubtitlesString> subtitlesContainer)
    public void StartPrologue(List<SubtitlesString> subtitlesContainer, bool stateContainer, GameObject gameThing)
    {
        // Проверка на то, запущен ли уже диалог.
        if(_panelSubtitles == true)
        {
            
            if(workWhitObject != null)
            {

                workWhitObject.TryGetComponent<InteractionObject>(out InteractionObject interObject);

                if (interObject != null)
                {
                    if (state == true)
                    {
                        interObject.ChangeState(false);
                    }
                    else
                    {
                        interObject.ChangeState(true);
                    }
                }
            }
            
            
        }

        workWhitObject = gameThing; //!!!!
        state = stateContainer;

        _isPlaySubtitles = true;
        _currentSubtitlesContainer = subtitlesContainer;
        index = 0;
        _panelSubtitles.SetActive(true);
        DrawText();
    }

}
