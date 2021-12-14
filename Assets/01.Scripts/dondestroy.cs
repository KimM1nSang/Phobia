using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dondestroy : MonoBehaviour
{
    public int idx;
    public static dondestroy Instance { get; set; }
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
}
