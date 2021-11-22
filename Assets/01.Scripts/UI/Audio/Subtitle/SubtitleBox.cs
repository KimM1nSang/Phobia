using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubtitleBox : MonoBehaviour
{
    private Text subtitle;
    private RectTransform rect;
    void Start()
    {
        subtitle = GetComponentInChildren<Text>();
        rect = GetComponent<RectTransform>();
    }

    void Update()
    {
        string[] subtitleText = subtitle.text.Split('\n');
        rect.sizeDelta = new Vector2(subtitle.text.Length == 1 ? 79.9999f : subtitle.text.Length > 1 ? (79.9999f) +( (subtitle.text.Length -1 )* 49.9999f) : 0, subtitleText.Length > 1 ? 150 : 100);
    }
}
