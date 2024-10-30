using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    [SerializeField] private bool checkState = true;

    public bool CheckState()
    {
        return checkState;
    }

    public void ChangeState(bool state)
    {
        checkState = state;
    }
}
