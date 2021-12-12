using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Quest Object", menuName = "Asset/New Quest Object")]
public class Quest : ScriptableObject
{
    public Quest nextQuest;
    public string id = "";

    [TextArea]
    public string content = "";

    public bool isDone = false;

    public int necProgress = 0;
    public int progress = 0;

}
