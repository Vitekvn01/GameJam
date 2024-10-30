using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewUICompass : MonoBehaviour
{
    [SerializeField] private GameObject _icon;
    private Color _originalColor; // Для хранения исходного цвета
    private void Awake()
    {
        // Сохраняем исходный цвет Image
        if (_icon.TryGetComponent(out Image iconImage))
        {
            _originalColor = iconImage.color;
        }
        else
        {
            Debug.LogWarning("Image component not found on _Icon.");
        }
    }

    // Метод для установки серого и полупрозрачного цвета
    public void SetGray()
    {
        if (_icon.TryGetComponent(out Image iconImage))
        {
            iconImage.color = new Color(0.3f, 0.3f, 0.3f, 1f); // Серый и полупрозрачный
        }
    }

    // Метод для возврата цвета к исходному, убирая свечение
    public void ResetColor()
    {
        if (_icon.TryGetComponent(out Image iconImage))
        {
            iconImage.color = _originalColor;
        }
    }

    public void Show()
    {
        _icon.SetActive(true);
    }
    public void Hide()
    {
        _icon.SetActive(false);
    }

}
