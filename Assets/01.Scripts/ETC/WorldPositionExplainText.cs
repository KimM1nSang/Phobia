using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class WorldPositionExplainText : MonoBehaviour
{
    private bool isEnter = false;
    public string txt = "";
    public float txtSpeed = 0.5f;
    private Text thisTxt;
    private void Start()
    {
        thisTxt = GetComponent<Text>();
        txt = thisTxt.text;
        thisTxt.text = "";
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !isEnter)
        {
            isEnter = true;
            thisTxt.DOText(txt, txtSpeed);
        }
    }
}
