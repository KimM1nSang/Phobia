using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool canMove = true;
    public bool canLook = true;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("�̹� ���ӸŴ����� �����մϴ�");
        }
        instance = this;
    }
}
