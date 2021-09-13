using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput instance;

    public string frontAxisName = "Vertical";
    public string rightAxisName = "Horizontal";
    public KeyCode interactKey = KeyCode.E;
    public KeyCode dropKey = KeyCode.F;

    public float frontMove { get; private set; }
    public float rightMove { get; private set; }
    public bool interact { get; private set; }
    public bool interactUp { get; private set; }
    public bool objectDrop { get; private set; }
    public float mouseX { get; private set; }
    public float mouseY { get; private set; }

    public float mouseSensitivity { get; set; } = 100;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("이미 플레이어 인풋이 존재합니다");
        }
        instance = this;
    }

    void Update()
    {
        frontMove = Input.GetAxis(frontAxisName);
        rightMove = Input.GetAxis(rightAxisName);
        interact = Input.GetKeyDown(interactKey);
        interactUp = Input.GetKeyUp(interactKey);
        objectDrop = Input.GetKeyDown(dropKey);
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
    }
}
