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

    public void UIInit()// �ʱ� ui ����
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
        EventManager.Instance.WhenEvent();//���ǿ� �´� �̺�Ʈ ������ �����Ѵ�.
    }

    

    public void Dialogue()//���ù�ư ġ���, ��ȭâ ���� �Լ�
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

    public void Setting()//����â Ű�� �Լ�
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

    public void GameOver()//���� ������ �ߵ�, ���ӿ��� ���ڿ� Ÿ��Ʋ�� ���� ��ư ���� ui �Ⱥ��̰��ϱ�
    {
        SceneManager.LoadScene("GameOver");
    }
  

}
