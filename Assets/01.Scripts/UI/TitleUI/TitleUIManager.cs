using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleUIManager : MonoBehaviour
{
    [SerializeField] private GameObject Cam;

    private Vector3 firstPosition;
    private Quaternion firstquaternion;

    private float cam_Speed = 0.5f;

    private bool is_Cam_Moving = false;

    [SerializeField] private Button GameStartbtn;
    [SerializeField] private Button Optionbtn;
    
    [SerializeField] private Button Exitbtn;
    [SerializeField] private Button ReallyExitbtn;

    [SerializeField] private Button NewGamebtn;
    [SerializeField] private Button LoadGamebtn;

    [SerializeField] private GameObject OptionPanel;
    [SerializeField] private GameObject GameStartPanel;
    [SerializeField] private GameObject GameExitPanel;

    [SerializeField] private Transform OptionTransform;
    [SerializeField] private Transform GameStartTransform;
    [SerializeField] private Transform ExitPosition;

    void Start()
    {
        firstPosition =  Cam.transform.position;
        firstquaternion =  Cam.transform.rotation;

        is_Cam_Moving = false;

        OptionPanel.SetActive(false);
        GameStartPanel.SetActive(false);

        GameStartbtn.onClick.AddListener(OnActiveGameStart);
       
        Optionbtn.onClick.AddListener(OnActiveOption);
        
        Exitbtn.onClick.AddListener(OnActiveGameExit);
        ReallyExitbtn.onClick.AddListener(QuitGame);

        NewGamebtn.onClick.AddListener(OnNewGame);
        LoadGamebtn.onClick.AddListener(OnLoadGame);

        PC_UI.Instance.SetSubtitle("ESC : 뒤로가기", 3.0f);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)&& !is_Cam_Moving)
        {
            Optionbtn.gameObject.SetActive(true);
            OptionPanel.SetActive(false);
            GameStartbtn.gameObject.SetActive(true);
            GameStartPanel.SetActive(false);
            Exitbtn.gameObject.SetActive(true);
            GameExitPanel.SetActive(false);

            CamMoving(firstPosition, firstquaternion);
        }
    }
    private void OnActiveOption()
    {
        if (is_Cam_Moving) return;

        Optionbtn.gameObject.SetActive(OptionPanel.activeSelf);
        OptionPanel.SetActive(!OptionPanel.activeSelf);

        CamMoving(OptionTransform.position, OptionTransform.rotation);
    }
    private void OnActiveGameStart()
    {
        if (is_Cam_Moving) return;

        GameStartbtn.gameObject.SetActive(GameStartPanel.activeSelf);
        GameStartPanel.SetActive(!GameStartPanel.activeSelf);

        CamMoving(GameStartTransform.position, GameStartTransform.rotation);
    }

    private void OnActiveGameExit()
    {
        if (is_Cam_Moving) return;

        Exitbtn.gameObject.SetActive(GameExitPanel.activeSelf);
        GameExitPanel.SetActive(!GameExitPanel.activeSelf);
        CamMoving(ExitPosition.position, ExitPosition.rotation);

    }

    private void CamMoving(Vector3 transform,Quaternion quaternion)
    {
        if (is_Cam_Moving) return;
        is_Cam_Moving = true;

        Cam.transform.DOMove(transform, cam_Speed).OnComplete(() => { is_Cam_Moving = false; }); ;
        Cam.transform.DORotate(quaternion.eulerAngles, cam_Speed);
    }
    private void OnLoadGame()
    {
        Debug.Log("안만들었음");
    }
    private void OnNewGame()
    {
        Debug.Log("NewGame!");
        LoadSceneManager.LoadScene("HighwayScene");
    }
    private void QuitGame()
    {
        Debug.Log("QuitGame!");
        Application.Quit();
    }
}
