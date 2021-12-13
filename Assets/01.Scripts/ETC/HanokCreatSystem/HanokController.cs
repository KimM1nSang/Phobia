using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanokController : MonoBehaviour
{
    public int currentIndex = 0;
    public int maxIndex = 0;
    public AnimationClip[] animClips;
    private Animation anim;
    public GameObject[] eventObjects;
    private EventColliderObject[] eventCollObjs;
    private void Start()
    {
        maxIndex = eventObjects.Length;
        for (int i = 0; i < eventObjects.Length; i++)
        {
            eventCollObjs[i] = eventObjects[i].GetComponent<EventColliderObject>();
            eventCollObjs[i].OnEnter += CallOnEnter;
        }
    }
    public void CallOnEnter()
    {
        anim.clip = animClips[currentIndex++];
        anim.Play();
    }
}
