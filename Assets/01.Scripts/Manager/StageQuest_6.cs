using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class StageQuest_6 : MonoBehaviour
{
    [SerializeField] Light sun;
    [SerializeField] InteractableObject redBucket;
    [SerializeField] GameObject dropZone;
    [SerializeField] VolumeSc originVolume;
    [SerializeField] VolumeSc darkZone;
    [SerializeField] GameObject[] playGround;
    [SerializeField] GameObject[] storyLight;
    [SerializeField] GameObject cabinet;
    public string questId;
    public string repetitionQuestId;

    [SerializeField]
    private AudioObject[] bucketBring = null;
    [SerializeField]
    private AudioObject[] afterDropObjects = null;
    [SerializeField]
    private AudioObject[] endObjects = null;


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
            case 5: return Quest5;
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
        Vocals.Instance.Processing(bucketBring);
        redBucket.isInteractable = true;
        dropZone.SetActive(true);
    }
    public void Quest3()
    {
        print("3");
        for (int i = 0; i < playGround.Length; i++)
        {
            playGround[i].SetActive(false);
        }
        StartCoroutine(darkZone.VolumeFade());
        StartCoroutine(originVolume.VolumeFade(1f,false));
        sun.intensity = 15f;

        Vocals.Instance.endOfEnd += UpProgress;
        Vocals.Instance.Processing(afterDropObjects);
    }
    public void Quest4()
    {
        print("4");


        for (int i = 0; i < 10; i++)
		{
            PC_UI.Instance.AddQuestId(repetitionQuestId);
        }
        PC_UI.Instance.RefreshQuestList();
        Vocals.Instance.Processing(endObjects);
        StartCoroutine(LightOn());  
    }
    public void Quest5()
    {
        print("5");
    }
    public void UpProgress()
    {
        PC_UI.Instance.UpProgress(questId);
    }
    IEnumerator LightOn()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < storyLight.Length; i++)
		{
            yield return new WaitForSeconds(0.5f);
            storyLight[i].SetActive(true);

        }
        cabinet.SetActive(true);
    }
}
