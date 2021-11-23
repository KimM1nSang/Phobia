using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image fade;
    // Start is called before the first frame update
    void Start()
    {
        fade.color = new Color(0, 0, 0, 1);
        fade.DOFade(0, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            print("as");
            LoadSceneManager.LoadScene("Playground");
        }
    }
}
