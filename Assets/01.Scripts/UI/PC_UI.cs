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
    private string subName = "";

    private bool isPlaying = false;

    [SerializeField] private GameObject questBox = null;
    [SerializeField] private Text questList_txt = null;

    [SerializeField] private List<Quest> questLib = new List<Quest>();
    private List<Quest> quests = new List<Quest>();
    public List<string> questIds = new List<string>();

    private float popUpSpeed = 0.5f;
    private float boxMaintainTime = 4f;

    private bool isPressPopupQuestBoxBtn = false;

    public static PC_UI Instance { get; set; }

    public Action questPopdown;
    public Action questPopup;
    public Action onQuestDone;
    private void Awake()
    {
        if (Instance != null)
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

        ClearQuests();
        ClearQuestLib();
        RefreshQuestList();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            DOTween.Kill(questBox);
            //StopCoroutine(PopUpAfterSeconds());
            if (isPressPopupQuestBoxBtn)
            {
                PopDownQuestBox();
            }
            else
            {
                PopUpQuestBox(false);
            }
            isPressPopupQuestBoxBtn = !isPressPopupQuestBoxBtn;
        }

    }
    #region 자막

    /// <summary>
    /// 자막 설정
    /// </summary>
    /// <param name="subtitle">자막 내용</param>
    /// <param name="delay">자막 없어지기 까지의 딜레이</param>
    public void SetSubtitle(string subtitle, float delay)
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
        subtitleBoxRect.sizeDelta = new Vector2(subtitle.Length > 0 ? CalculateWidthOfMessage(MostLongSubtitle) + (subtitleRect.offsetMin.x * 2) : 0, 80 + (splitSubtitle.Length - 1) * 50);

        if (!isPlaying)
        { }
            //StartCoroutine(ClearAfterSeconds(delay));
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
        subtitleBoxRect.sizeDelta = new Vector2(0, 0);
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
        string currentMessage = message;
        subName = "";
        if (message.Contains("-"))
        {
            currentMessage = SubstringColorCommand(message);
        }

        int totalLength = 0;

        Font myFont = subtitle_txt.font;  //chatText is my Text component
        //CharacterInfo characterInfo = new CharacterInfo();

        char[] arr = currentMessage.ToCharArray();
        char[] nameArr = subName.ToCharArray();

        foreach (char c in arr)
        {
            myFont.RequestCharactersInTexture(c.ToString(), subtitle_txt.fontSize, subtitle_txt.fontStyle);
            myFont.GetCharacterInfo(c, out CharacterInfo characterInfo, subtitle_txt.fontSize);
            totalLength += characterInfo.advance;
        }
        foreach (char c in nameArr)
        {
            myFont.RequestCharactersInTexture(c.ToString(), subtitle_txt.fontSize, subtitle_txt.fontStyle);
            myFont.GetCharacterInfo(c, out CharacterInfo characterInfo, subtitle_txt.fontSize);
            totalLength += characterInfo.advance;
        }



        return totalLength;
    }

    public string SubstringColorCommand(string message)
    {
        if (!message.Contains(">"))
            return message;

        int nameLength = 0;
        string currentMessage = "";
        int idx = message.IndexOf('>');
        int idx2 = message.IndexOf('>', idx + 1);
        int idx3 = message.IndexOf('<', idx + 1);
        nameLength = idx3 - idx;

        subName = message.Substring(idx + 1, nameLength);
        currentMessage = message.Substring(idx2 + 1);
        Debug.Log(currentMessage.Length);
        Debug.Log(currentMessage);
        Debug.Log(message.Length);
        Debug.Log(message);
        return currentMessage;
    }
    #endregion

    #region 퀘스트

    public void QuestList()
    {
        quests.Clear();
        foreach (var quest in questLib)
        {
            foreach (var filter in questIds)
            {
                if (quest.id == filter)
                {
                    if (quests.Find(x => x.id == filter)==null)
                    {
                        quests.Add(quest);
                    }
                }
            }
        }
    }
    public void QuestListAdd(string id)
    {
        foreach (var quest in questLib)
        {
            if (quest.id == id)
            {
                print("A");
                quests.Add(quest);
            }
        }
    }
    public void RefreshQuestList()
    {
        questList_txt.text = "";

        string result = "";

        foreach (var quest in quests)
        {
            if (!quest.isDone)
            {
                result += "- " + quest.content;
                if (quest.necProgress != 0)
                {
                    result += string.Format("({0}/{1})", quest.progress, quest.necProgress);
                }
                result += "\n";
            }
        }
        questList_txt.text += result;
    }
    public void ClearQuestLib()
    {
        foreach (var quest in questLib)
        {
            quest.progress = 0;
        }
    }
    public void ClearQuests()
    {
        quests.Clear();
    }
    public virtual void SuccessQuest(string questId)
    {
        Quest quest = quests.Find((x) => x.id == questId);
        if (quest.necProgress <= quest.progress)
        {
            if (quest.nextQuest != null)
            {
                quest.isDone = true;
                quest.nextQuest.isDone = false;
                AddQuestId(quest.nextQuest.id);
                onQuestDone = StageQuest_6.Instance.QuestCheck(quests.Count);
                onQuestDone();
            }
        }
    }
    public void AddQuestId(string questId)
    {
        questIds.Add(questId);
        QuestList();
        RefreshQuestList();
        Quest quest = quests.Find((x) => x.id == questId);
        quest.isDone = false;
    }
    public void UpProgress(string questId)
    {
       
        Quest quest = quests.Find((x) => x.id == questId);
        if (!quest.isDone)
        {
            quest.progress++;
            RefreshQuestList();
            PC_UI.Instance.PopUpQuestBox(true);
        }
        SuccessQuest(questId);
        //퀘스트 진행도 올리는거
    }

    /// <summary>
    /// 퀘스트 박스 나오기
    /// </summary>
    /// <param name="isPopDown">나왔다 다시 들어가나요?</param>
    public void PopUpQuestBox(bool isPopDown)
    {
        questBox.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-250, -300), popUpSpeed).OnComplete(() => questPopup?.Invoke());
        if (isPopDown)
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
        questBox.GetComponent<RectTransform>().DOAnchorPos(new Vector2(250, -300), popUpSpeed * 2).OnComplete(() => questPopdown?.Invoke());
    }
    #endregion
}
