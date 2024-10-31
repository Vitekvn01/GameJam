using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePlace : MonoBehaviour, IHide
{
    [SerializeField] private GameObject cameraHide;
    [SerializeField] private Transform cameraPosition;

    private GameObject HideCam;

    private bool inHide = false;

    private GameObject playerObject;

    private float timer;

    public void Hide(GameObject mainObject)
    {
        playerObject = mainObject;
        
        if (playerObject != null)
        {
            playerObject.SetActive(false);
            inHide = true;
        }

        HideCam = Instantiate(cameraHide, cameraPosition);
    }

    private void Update()
    {
        if(inHide)
        {
            timer += 0.1f;

            if (Input.GetKeyDown(KeyCode.E) && (timer > 0.1f))
            {
                ExitHide();
                timer = 0;
            }
        }
    }

    private void ExitHide()
    {
        Destroy(HideCam);
        if (playerObject != null)
        {
            playerObject.SetActive(true);
        }
        
        inHide = false;
    }
}
