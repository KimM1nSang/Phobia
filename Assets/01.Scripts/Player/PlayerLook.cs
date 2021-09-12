using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    //���콺�� ȭ�� �����̰� ���ִ� ��ũ��Ʈ

    public Transform playerBody;
    private PlayerInput input;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        input = PlayerInput.instance;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.canLook) return;

        xRotation -= input.mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * input.mouseX);
    }
}
