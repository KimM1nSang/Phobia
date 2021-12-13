using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
   public static Fade Instance { get; set; }

    public Image fade;
	// Start is called before the first frame update
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
	void Start()
    {
        fade.DOFade(0, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            LoadSceneManager.LoadScene("Playground");
        }
    }
    public void SetFade()
    {
        fade.color = new Color(0, 0, 0, 1);
    }
    public void FadeInOut(float time = 1f)
    {
        fade.color = new Color(0, 0, 0, 1);
        if (!GameManager.instance.canMove)
        {
            GameManager.instance.canMove = false;
            //fade.DOFade(1, time).OnComplete(()=>fade.DOFade(0,time).OnComplete(()=> GameManager.instance.canMove = true));   
            fade.DOFade(0, time).OnComplete(() => GameManager.instance.canMove = true);
        }
        else
        {
            fade.DOFade(0, time);
        }
        
    }
}
