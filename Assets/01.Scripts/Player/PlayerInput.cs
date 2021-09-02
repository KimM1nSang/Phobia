using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public string frontAxisName = "Vertical";
    public string rightAxisName = "Horizontal";

    public float frontMove { get; private set; }
    public float rightMove { get; private set; }
    public bool interact { get; private set; }
    public float mouseX { get; private set; }
    public float mouseY { get; private set; }

    public float mouseSensitivity { get; set; } = 100;

    void Update()
    {
        frontMove = Input.GetAxis(frontAxisName);
        rightMove = Input.GetAxis(rightAxisName);
        interact = Input.GetMouseButtonDown(0);
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
    }
}
