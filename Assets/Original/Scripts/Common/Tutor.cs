using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutor : MonoBehaviour
{
    [SerializeField] private GameObject _uICanvas;

    [SerializeField] private float _timeStart;

    [SerializeField] private float _timeShow;

    private float _timer = 0;

    private bool _isActive = false;

    private void Update()
    {

        if (_isActive == true)
        {
            _timer += Time.deltaTime;

            if (_timer > _timeShow)
            {
                SetDisactive();
            }
        }
        else
        {
            _timer += Time.deltaTime;

            if (_timer > _timeStart)
            {
                SetActive();
            }
        }


    }


    public void SetActive()
    {
        _timer = 0;
        _uICanvas.SetActive(true);
        _isActive = true;

    }

    public void SetDisactive()
    {
        _uICanvas.SetActive(false);
        Destroy(this.gameObject);
    }


}
