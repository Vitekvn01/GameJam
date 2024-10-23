using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    private void Update()
    {
        SetDirection();

        Movement();

        Rotation();
    }

    private void SetDirection()
    {
        _normalizeRotX = Input.GetAxis("Mouse X");
        _normalizeDirZ = Input.GetAxisRaw("Vertical");
        _normalizeDirX = Input.GetAxisRaw("Horizontal");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
