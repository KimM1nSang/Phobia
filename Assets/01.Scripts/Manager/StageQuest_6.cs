using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageQuest_6 : MonoBehaviour
{
    [SerializeField] InteractableObject redBucket;
    [SerializeField] GameObject dropZone;

    public static StageQuest_6 Instance { get; set; }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        
    }
    public Action QuestCheck(int idx)
    {
		switch (idx)
		{
            case 1: return Quest1;
            case 2: return Quest2;
            case 3: return Quest3;
            case 4: return Quest4;
		}
        return null;
    }
    public void Quest1()
    {
        print("1");

    }
    public void Quest2()
    {
        print("2");
        redBucket.isInteractable = true;
        dropZone.SetActive(true);
    }
    public void Quest3()
    {
        print("3");
    }
    public void Quest4()
    {
        print("4");
    }
}
