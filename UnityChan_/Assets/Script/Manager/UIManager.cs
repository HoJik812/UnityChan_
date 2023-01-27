using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    public GameObject dayImage;
    public TextMeshProUGUI dayText;
    public GameObject timeImage;
    public TextMeshProUGUI timeText;
    public GameTime gameTime;
    public Button settingButton;
    public GameObject dialogueWindow;
    public TextMeshProUGUI dialogueText;
    public Button training;
    public Button study;
    public Button rest;
    public TextMeshProUGUI statusTest;
    public TextMeshProUGUI nameText;
    public GameObject settingWindow;
    
    public Button gotoTitle;
    public Button returntoGame;

    private void Awake()
    {
        //UIInit();
        //base.Awake();
        gameTime = GetComponent<GameTime>();
    }

    private void Update()
    {
        dayText.text = "Day \n" + gameTime.Day;
        timeText.text = "Time \n" + gameTime.Time;
    }

    public void UIInit()// 초기 ui 세팅
    {
        CameraManager.Instance.CheckCamera();
        dayImage.SetActive(true);
        timeImage.SetActive(true);
        settingButton.gameObject.SetActive(true);
        training.gameObject.SetActive(true);
        study.gameObject.SetActive(true);
        rest.gameObject.SetActive(true);
        dialogueWindow.SetActive(false);
        dialogueText.gameObject.SetActive(false);
        settingButton.gameObject.SetActive(true);
        nameText.text = " ";
        EventManager.Instance.WhenEvent();//조건에 맞는 이벤트 있으면 실행한다.
    }

    

    public void Dialogue()//선택버튼 치우고, 대화창 띄우는 함수
    {
        Debug.Log("in");
        training.gameObject.SetActive(false);
        settingButton.gameObject.SetActive(false);
        study.gameObject.SetActive(false);
        rest.gameObject.SetActive(false);
        dialogueWindow.gameObject.SetActive(true);
        dialogueText.gameObject.SetActive(true);
        settingButton.gameObject.SetActive(false);
    }

    public void Setting()//세팅창 키는 함수
    {
        Time.timeScale = 0;
        settingWindow.SetActive(true);
    }

    public void CloseSetting()
    {
        Time.timeScale = 1;
        settingWindow.SetActive(false);
    }

    public void GotoTitle()
    {
        SceneManager.LoadScene("Start");
    }

    public void GameOver()//게임 오버시 발동, 게임오버 글자와 타이틀로 가는 버튼 외의 ui 안보이게하기
    {
        SceneManager.LoadScene("GameOver");
    }
  

}
