using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject player { get; private set; }

    public bool canMove = true;
    public bool canLook = true;

    public bool canInteract = true;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("이미 게임매니저가 존재합니다");
        }
        instance = this;
        if (GameObject.Find("PC_Player") != null)
            player = GameObject.Find("PC_Player");
    }
}
