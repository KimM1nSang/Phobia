using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool canMove = false;
    public bool canLook = false;

    private void Awake()
    {
        instance = this;
    }
}
