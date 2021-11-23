using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Audio Object",menuName = "Asset/New Audio Object")]
public class AudioObject : ScriptableObject
{
    public AudioClip clip;
    [TextArea]
    public string subtitle;
}
