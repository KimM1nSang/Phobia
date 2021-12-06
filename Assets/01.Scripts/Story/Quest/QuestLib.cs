using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLib : MonoBehaviour
{
    public static QuestLib Instance;

    [SerializeField] private List<Quest> quests = new List<Quest>();

    public List<Quest> questLib
    {
        get { return quests; }
        set { quests = value; }
    }

    private void Awake()
    {
        Instance = this;
    }

}
