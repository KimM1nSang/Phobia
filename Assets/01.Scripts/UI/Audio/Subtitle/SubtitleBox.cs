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
        rect.sizeDelta = new Vector2(subtitle.text.Length > 0 ? CalculateWidthOfMessage(subtitle.text) + 30 : 0, subtitleText.Length > 1 ? 150 : 100);
    }

    public int CalculateWidthOfMessage(string message)
    {
        int totalLength = 0;

        Font myFont = subtitle.font;  //chatText is my Text component
        //CharacterInfo characterInfo = new CharacterInfo();

        char[] arr = message.ToCharArray();

        foreach (char c in arr)
        {
            myFont.RequestCharactersInTexture(c.ToString(), subtitle.fontSize, subtitle.fontStyle);
            myFont.GetCharacterInfo(c, out CharacterInfo characterInfo, subtitle.fontSize);
            totalLength += characterInfo.advance;
        }
        return totalLength;
    }
}
