using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct SubtitlesString
{
    [SerializeField] public string Name;

    [SerializeField] public string Text;

}

public class SubtitlesContainer : MonoBehaviour
{
    [SerializeField] private List<SubtitlesString> SubtitlesList = new List<SubtitlesString>();

    public void SetSubtitlesContainer()
    {

    }
}
