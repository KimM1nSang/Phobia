using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PC_UI : MonoBehaviour
{
    [SerializeField] Text subtitleText = null;

    private RectTransform subtitleBoxRect;
    private RectTransform subtitleRect;

    private bool isPlaying = false;

    [SerializeField] GameObject todoBox = null;

    private float popUpSpeed = 0.5f;
    private float boxMaintainTime = 4f;

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

        todoBox.GetComponent<RectTransform>().anchoredPosition = new Vector2(250, -300);

        ClearSubtitle();
    }

    #region �ڸ�

    /// <summary>
    /// �ڸ� ����
    /// </summary>
    /// <param name="subtitle">�ڸ� ����</param>
    /// <param name="delay">�ڸ� �������� ������ ������</param>
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
    /// �ڸ� �����
    /// </summary>
    public void ClearSubtitle()
    {
        subtitleText.text = "";
        ClearSubtitleBox();
    }
    /// <summary>
    /// �ڸ� �ڽ� �����
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
    /// ĵ���� �� �޼����� ���� ���ϱ�
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

    #region ���� ���
    /// <summary>
    /// ���� �ڽ� �˾�
    /// </summary>
    public void PopUpToDoBox()
    {
        todoBox.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-250,-300), popUpSpeed);
        StartCoroutine(PopUpAfterSeconds());
    }

    private IEnumerator PopUpAfterSeconds()
    {
        yield return new WaitForSeconds(popUpSpeed + boxMaintainTime);
        PopDownToDoBox();
    }
    /// <summary>
    /// ���� �ڽ� ����
    /// </summary>
    public void PopDownToDoBox()
    {
        todoBox.GetComponent<RectTransform>().DOAnchorPos(new Vector2(250, -300), popUpSpeed * 2);
    }
    #endregion
}
