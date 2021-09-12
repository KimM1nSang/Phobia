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
            Debug.LogError("이미 게임매니저가 존재합니다");
        }
        instance = this;
    }
}
