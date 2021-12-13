using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    private Animator animator;
    public GameObject son;
    public Transform carAccidentTrm;

    public GameObject AccidentCarPrefab;
    public Transform AccidentCarSpawnTrm;
    public bool isAccidentDone = false;

    public AudioObject CarCommingAudioObj;

    RaycastHit hit;
    float maxDist = 1000f;
    void Start()
    {
        animator = GetComponent<Animator>();
        son.SetActive(false);
        Vocals.Instance.startOfEnd += CallStartOfEnd;
    }
    public void CarAccident()
    {
        Instantiate(AccidentCarPrefab, AccidentCarSpawnTrm);
    }
    public void BeforCarAccident()
    {

        transform.position = carAccidentTrm.position;
        GameManager.instance.canMove = false;
        GameManager.instance.canLook = false;
        GameManager.instance.canInteract = false; 
        Fade.Instance.FadeInOut(0.5f);
        GetComponent<CharacterController>().center = new Vector3(0, 1.8f, 0);
        animator.SetBool("isFalldown", true);
    }
    public void CallStartOfEnd()
    {
        son.SetActive(true);
    }
    
    private void Update()
    {
        if(son.activeSelf)
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, maxDist))
            {
                if(hit.transform.gameObject.name == son.name)
                {
                    BeforCarAccident();
                }
            }
        }
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("fallDown"))
        {
            if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5f)
            {
                GameManager.instance.canLook = true;
                if(!isAccidentDone)
                {
                    isAccidentDone = true;
                    CarAccident();

                    PC_UI.Instance.ClearSubtitle();
                    Vocals.Instance.Say(CarCommingAudioObj);
                }
            }
        }
    }
}
