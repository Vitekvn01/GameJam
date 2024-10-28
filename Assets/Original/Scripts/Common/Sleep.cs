using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Sleep : MonoBehaviour
{
    [SerializeField] private UnityEvent _onFadeComplete = new UnityEvent();

    [SerializeField] private Image _blackOverlay;           // UI Image для затемнения
    [SerializeField] private float _fadeDuration = 2f;      // Длительность затемнения

    private void Start()
    {

    }

    private IEnumerator FadeToBlack()
    {
        float elapsedTime = 0f;
        Color color = _blackOverlay.color;
        color.a = 0f;  // Начальное значение альфа-канала

        while (elapsedTime < _fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(0, 1, elapsedTime / _fadeDuration); // Плавное изменение альфа
            _blackOverlay.color = color;
            yield return null;
        }

        _onFadeComplete?.Invoke();
    }



    public void StartSleep()
    {
        StartCoroutine(FadeToBlack());
    }
}
