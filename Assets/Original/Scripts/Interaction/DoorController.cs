using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour,IDoorController
{
    [SerializeField] private bool doLock;


    [SerializeField] private Animator animDoor;

    [SerializeField] private bool QuestComplete;

    private bool isLock;

    public void useDoor(GameObject gameObject)
    {
        if (QuestComplete)
        {
            animDoor.enabled = true;

            if (animDoor.GetBool("Open") == false)
            {
                animDoor.SetBool("Open", true);
            }
            else if (animDoor.GetBool("Open") == true)
            {
                animDoor.SetBool("Open", false);
            }
        }
        else
        {
            if (gameObject.TryGetComponent(out SubtitlesContainer Subtitles))
            {
                Subtitles.PlaySubtitlesContainer();
            }
        }
    }
}
