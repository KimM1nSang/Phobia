using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class PC_UI : MonoBehaviour
{
    [SerializeField] Text subtitle_txt = null;

    private RectTransform subtitleBoxRect;
    private RectTransform subtitleRect;

    private bool isPlaying = false;

    [SerializeField] private GameObject questBox = null;
    [SerializeField] private Text questList_txt = null;

    [SerializeField] private List<Quest> questLib = new List<Quest>();
    private List<Quest> quests = new List<Quest>();
    public List<string> questIds = new List<string>();

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
        subtitleBoxRect = subtitle_txt.transform.parent.GetComponent<RectTransform>();
        subtitleRect = subtitle_txt.GetComponent<RectTransform>();

        questBox.GetComponent<RectTransform>().anchoredPosition = new Vector2(250, -300);

        ClearSubtitle();
        
        ClearQuestList();
        RefreshQuestList();
    }

    #region 자막

    /// <summary>
    /// 자막 설정
    /// </summary>
    /// <param name="subtitle">자막 내용</param>
    /// <param name="delay">자막 없어지기 까지의 딜레이</param>
    public void SetSubtitle(string subtitle,float delay)
    {
        subtitle_txt.text = subtitle;

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
        subtitle_txt.text = "";
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

        Font myFont = subtitle_txt.font;  //chatText is my Text component
        //CharacterInfo characterInfo = new CharacterInfo();

        char[] arr = message.ToCharArray();

        foreach (char c in arr)
        {
            myFont.RequestCharactersInTexture(c.ToString(), subtitle_txt.fontSize, subtitle_txt.fontStyle);
            myFont.GetCharacterInfo(c, out CharacterInfo characterInfo, subtitle_txt.fontSize);
            totalLength += characterInfo.advance;
        }
        return totalLength;
    }
    #endregion

    #region 퀘스트

    public void RefreshQuestList()
    {
        questList_txt.text = "";
        foreach (var quest in questLib)
        {
            foreach (var filter in questIds)
            {
                if(quest.id == filter)
                {
                    quests.Add(quest);
                }
            }
        }
        foreach (var quest in quests)
        {
            if (!quest.isDone)
            {
                questList_txt.text += "- " + quest.content + "\n";
            }
        }
    }
    public void ClearQuestList()
    {
        quests.Clear();
    }
    public void AddQuestId(string questId)
    {
        questIds.Add(questId);
        RefreshQuestList();
    }

    /// <summary>
    /// 퀘스트 박스 나오기
    /// </summary>
    /// <param name="isPopDown">나왔다 다시 들어가나요?</param>
    public void PopUpQuestBox(bool isPopDown)
    {
        questBox.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-250,-300), popUpSpeed);
        if(isPopDown)
        {
            StartCoroutine(PopUpAfterSeconds());
        }
    }

    private IEnumerator PopUpAfterSeconds()
    {
        yield return new WaitForSeconds(popUpSpeed + boxMaintainTime);
        PopDownQuestBox();
    }
    /// <summary>
    /// 퀘스트 박스 들어가기
    /// </summary>
    public void PopDownQuestBox()
    {
        questBox.GetComponent<RectTransform>().DOAnchorPos(new Vector2(250, -300), popUpSpeed * 2);
    }
    #endregion
}
