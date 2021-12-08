using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDropPoint_2 : ObjectDropPoint
{
    [SerializeField]
    private GameObject cameraPoint = null;

    private bool isDropObj = false;

    [SerializeField]
    private AudioObject afterDropObject = null;
    protected override void Start()
    {
        base.Start();
        cameraPoint.SetActive(false);
        PC_UI.Instance.questPopdown += ActiveCamPointObj;
    }
    public override void OnDropObject()
    {
        base.OnDropObject();
        isDropObj = true;
        Destroy(gameObject);
    }
    public void ActiveCamPointObj()
    {
        if (!isDropObj) return;
        cameraPoint.SetActive(true);
        Vocals.Instance.Say(afterDropObject);
    }
}
