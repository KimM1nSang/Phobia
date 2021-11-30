using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PC_UI : MonoBehaviour
{
    [SerializeField] Text subtitleText = null;

    private RectTransform subtitleBoxRect;
    private RectTransform subtitleRect;

    private bool isPlaying = false;

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

    #region 자막

    /// <summary>
    /// 자막 설정
    /// </summary>
    /// <param name="subtitle">자막 내용</param>
    /// <param name="delay">자막 없어지기 까지의 딜레이</param>
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

        if (!isPlaying)
            StartCoroutine(ClearAfterSeconds(delay));
    }
    /// <summary>
    /// 자막 지우기
    /// </summary>
    public void ClearSubtitle()
    {
        subtitleText.text = "";
        ClearSubtitleBox();
    }
    /// <summary>
    /// 자막 박스 지우기
    /// </summary>
    public void ClearSubtitleBox()
    {
        subtitleBoxRect.sizeDelta = new Vector2(0,0);
    }

    private IEnumerator ClearAfterSeconds(float delay)
    {
        isPlaying = true;
        yield return new WaitForSeconds(delay);
        ClearSubtitle();
        isPlaying = false;
    }

    /// <summary>
    /// 캔버스 속 메세지의 길이 구하기
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
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
    #endregion
}
