using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PC_UI : MonoBehaviour
{
    [SerializeField] Text subtitleText = null;

    public static PC_UI Instance { get; set; }

    public void SetSubtitle(string subtitle,float delay)
    {
        subtitleText.text = subtitle;

        StartCoroutine(ClearAfterSeconds(delay));
    }

    public void ClearSubtitle()
    {
        subtitleText.text = "";
    }
    private IEnumerator ClearAfterSeconds(float delay)
    {
        yield return new WaitForSeconds(delay);
        ClearSubtitle();
    }
}
