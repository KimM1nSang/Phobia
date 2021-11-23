using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PC_UI : MonoBehaviour
{
    [SerializeField] Text subtitleText = null;

    private RectTransform subtitleBoxRect;
    private RectTransform subtitleRect;

    public static PC_UI Instance { get; set; }

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        subtitleBoxRect = subtitleText.transform.parent.GetComponent<RectTransform>();
        subtitleRect = subtitleText.GetComponent<RectTransform>();
        ClearSubtitle();
    }

    public void SetSubtitle(string subtitle,float delay)
    {
        subtitleText.text = subtitle;

        string[] splitSubtitle = subtitle.Split('\n');
        string MostLongSubtitle = "";
        foreach (var sub in splitSubtitle)
        {
            if (MostLongSubtitle.Length < sub.Length)
            {
                MostLongSubtitle = sub;
            }
        }
        subtitleBoxRect.sizeDelta = new Vector2(subtitle.Length > 0 ? CalculateWidthOfMessage(MostLongSubtitle) + (subtitleRect.offsetMin.x * 2) : 0, 100 + (splitSubtitle.Length - 1) * 50);

        StartCoroutine(ClearAfterSeconds(delay));
    }

    public void ClearSubtitle()
    {
        subtitleText.text = "";
        ClearSubtitleBox();
    }
    public void ClearSubtitleBox()
    {
        subtitleBoxRect.sizeDelta = new Vector2(0,0);
    }
    private IEnumerator ClearAfterSeconds(float delay)
    {
        yield return new WaitForSeconds(delay);
        ClearSubtitle();
    }
    public int CalculateWidthOfMessage(string message)
    {
        int totalLength = 0;

        Font myFont = subtitleText.font;  //chatText is my Text component
        //CharacterInfo characterInfo = new CharacterInfo();

        char[] arr = message.ToCharArray();

        foreach (char c in arr)
        {
            myFont.RequestCharactersInTexture(c.ToString(), subtitleText.fontSize, subtitleText.fontStyle);
            myFont.GetCharacterInfo(c, out CharacterInfo characterInfo, subtitleText.fontSize);
            totalLength += characterInfo.advance;
        }
        return totalLength;
    }
}
