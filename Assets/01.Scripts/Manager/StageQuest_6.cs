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
    [SerializeField] GameObject[] ChatZone;
    public string questId;
    public string repetitionQuestId;

    [SerializeField]
    private AudioObject[] bucketBring = null;
    [SerializeField]
    private AudioObject[] afterDropObjects = null;
    [SerializeField]
    private AudioObject[] endObjects = null;

    public GameObject[] humansList;
    private Dictionary<string, GameObject> humansDic = new Dictionary<string, GameObject>();


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
		for (int i = 0; i < humansList.Length; i++)
		{
            humansDic.Add(humansList[i].name, humansList[i].gameObject);

        }
		foreach (var item in humansDic)
		{
            print(item.Key);
		}
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
            case 6: return Quest6;
        }
        return null;
    }
    public void Quest1()
    {
        print("1");

    }
    public void Quest2()
    {
        StartCoroutine(Wait(quest2));
    }
    public void quest2()
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
        PC_UI.Instance.RefreshQuestList();
        Vocals.Instance.Processing(endObjects);
        PC_UI.Instance.UpProgress(repetitionQuestId);
		foreach (var item in ChatZone)
		{
            item.SetActive(true);
		}
        StartCoroutine(LightOn());  
    }
    public void Quest5()
    {
        print("5");
    }
    public void Quest6()
    {
        print("6");
        StartCoroutine(Wait(() => LoadSceneManager.LoadScene("Room_Scene"),10f));

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
    public IEnumerator HumanOn(string objectName,float waitTime = 1f)
    {
        if (objectName == "Stand")
        {
            print("A");
			foreach (var item in humansDic)
			{
                if(item.Key!="Stand")
                item.Value.SetActive(false);
			}
        }
        if (humansDic[objectName] != null)
        {
            print(objectName+"»ý¼º");
            yield return new WaitForSeconds(2f);

            for (int i = 0; i < humansDic[objectName].transform.childCount; i++)
            {
                yield return new WaitForSeconds(waitTime);
                humansDic[objectName].transform.GetChild(i).transform.gameObject.SetActive(true);
            }
        }
    }

    public IEnumerator Wait(Action action,float waitTime = 2f)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }

}
