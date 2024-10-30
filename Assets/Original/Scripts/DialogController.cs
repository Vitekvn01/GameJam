using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    private bool dialog = false;

    public bool GetDialog()
    {
        return dialog;
    }


    public void setDialog(bool value)
    {
        dialog = value;
    }
}
