using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanokCreateSystem : MonoBehaviour
{
    public static HanokCreateSystem Instance;
    const int hanokNum = 7;
    const int hanokTrmNum = 4;
    [SerializeField] private GameObject[] loopHanok_Prefabs = new GameObject[hanokNum];
    private List<GameObject> loopedHanok = new List<GameObject>();
    private HanokCreateSystemHelper[] HCSHs = new HanokCreateSystemHelper[hanokNum];

    [SerializeField] private Transform[] hanokTrms = new Transform[hanokTrmNum];

    public Action OnPlayerChangeHanokIdx;

    private void Start()
    {
        if(Instance != null)
        {
            Debug.LogError("ÇÏ³ª ´õ ÀÖÀÝ½¿~");
        }
        Instance = this;

        int hanokIdx = 0;
        for (int i = 0; i < loopHanok_Prefabs.Length; i++)
        {
            GameObject hanok = Instantiate(loopHanok_Prefabs[i],hanokTrms[hanokIdx++]);
            if (hanokIdx > 3)
            {
                hanokIdx = 0;
            }
            HCSHs[i] = hanok.GetComponent<HanokCreateSystemHelper>();
            HCSHs[i].hanokIndex = i;

            hanok.SetActive(i == 0 ? true: false);
            loopedHanok.Add(hanok);
        }
        OnPlayerChangeHanokIdx += CallOnPlayerChangeHanokIdx;
    }

    public void CallOnPlayerChangeHanokIdx()
    {
        for (int i = 0; i < HCSHs.Length -1; i++)
        {
            if (HCSHs[i].isPlayerStay)
            {
                //loopedHanok[i].SetActive(true);
                if (i < loopedHanok.Count)
                {
                    loopedHanok[i + 1].SetActive(true);
                    if(i>1)
                    {
                        loopedHanok[i - 2].SetActive(false);
                    }
                }
                else if (i > 0)
                {
                    loopedHanok[i - 1].SetActive(true);
                }
            }
        }
    }
    private void Update()
    {
       
      
        /*for (int i = 0; i < HCSHs.Length; i++)
        {
            HCSHs[i].isPlayerStay = loopedHanoks[i].isPlayerStay = loopedHanoks[i+4].isPlayerStay;
        }*/
    }
}