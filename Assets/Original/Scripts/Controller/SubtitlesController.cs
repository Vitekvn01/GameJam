
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

    [SerializeField] private DialogController dialog; // !!!!

    /*    [SerializeField] private List<AudioClip> audioClip = new List<AudioClip>();*/
    /*    private AudioSource audioSource;*/
    /*    [SerializeField] private AudioMixer audioMixerMusic;*/
    /*    [SerializeField] private Image Image;*/

    [SerializeField] private TextMeshProUGUI _textSubtitles;
    [SerializeField] private TextMeshProUGUI _nameSubtitles;

    [SerializeField] private float _endTime;

    public bool IsLock { get; private set; }

    [SerializeField] public UnityEvent OnEndSubtitles = new UnityEvent();

    private GameObject workWhitObject; // !!!!!!!!
    private GameObject workWhitObjectCurrent;
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
            IsLock = false;
            _panelSubtitles.SetActive(false);

            if(workWhitObjectCurrent != null)
            {
                workWhitObjectCurrent.TryGetComponent<InteractionObject>(out InteractionObject InterObject);

                if(InterObject != null)
                {
                    InterObject.ChangeState(true);
                }

            }
            
            dialog.setDialog(false);

        }
    }

    //public void StartPrologue(List<SubtitlesString> subtitlesContainer)
    public void StartPrologue(List<SubtitlesString> subtitlesContainer, bool stateContainer, GameObject gameThing)
    {
        workWhitObject = gameThing; //!!!!
        state = stateContainer;

        workWhitObject.TryGetComponent<InteractionObject>(out InteractionObject IObject);

        IObject.ChangeState(false);

        if (!IsLock)
        {
            dialog.setDialog(true);

            workWhitObjectCurrent = gameThing;
            _isPlaySubtitles = true;
            _currentSubtitlesContainer = subtitlesContainer;
            index = 0;
            _panelSubtitles.SetActive(true);
            DrawText();
            IsLock = true;
        }
        else
        {
            IObject.ChangeState(true);
        }
        
    }

}
