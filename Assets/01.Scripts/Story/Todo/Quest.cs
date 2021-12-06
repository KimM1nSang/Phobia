using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Quest Object", menuName = "Asset/New Quest Object")]
public class Quest : ScriptableObject
{
    public string id = "";

    public string content = "";

    public bool isDone = false;
}
