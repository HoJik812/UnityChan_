using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestResult : GameEvent
{

    public bool IsTalk;

    private void Awake()
    {
        IsTalk = false;
    }
    public override void EventOn()
    {

        UIManager.Instance.Dialogue();//대화창 활성화
        UIManager.Instance.gameTime.Time++;
        CameraManager.Instance.cameras[6].gameObject.SetActive(true);
        

        StartCoroutine(Typing(UIManager.Instance.dialogueText, eventLogue.logues[currentIndex].logue, 0.1f));

    }

    public override IEnumerator Typing(TextMeshProUGUI typingText, string message, float speed)// 한글자씩 출력하는 함수
    {
        if (eventLogue.logues[currentIndex].name != null)//이름이 있으면?       
        {
            UIManager.Instance.nameText.text = eventLogue.logues[currentIndex].name;
        }
        else//이름이 없으면?
        {
            UIManager.Instance.nameText.text = " ";
        }

        for (int i = 0; i < message.Length; i++)
        {
            typingText.text = message.Substring(0, i + 1);
            yield return new WaitForSeconds(speed);
        }

       

        yield return new WaitForSeconds(1f);//다음 로그까지의 텀(1초)

        //if (currentIndex < eventLogue.logues.Length)
        //{
        //    Debug.Log("다음 대화");
        //    yield return StartCoroutine(Typing(UIManager.Instance.dialogueText, eventLogue.logues[currentIndex].logue, 0.1f));
        //}

        if (currentIndex >= 2)//eventLogue.logues.Length)
        {
            Debug.Log("대화 끝");
            currentIndex = 0;
            UIManager.Instance.UIInit();//이벤트 대화 종료 후 플레이 ui로 전환
            yield break;

        }

        currentIndex = 2;//다음 대화 없이 끝내기

        if (EventManager.Instance.test.IsPass)//시험 통과시
        {
            GameManager.Instance.player.Intel += 10;
            IsTalk = true;
            yield return StartCoroutine(Typing(UIManager.Instance.dialogueText, eventLogue.logues[1].logue, 0.1f));
        }
        else//시험 불합격시
        {
            IsTalk = true;
            GameManager.Instance.player.Intel -= 10;
            GameManager.Instance.player.Health -= 20;
            yield return StartCoroutine(Typing(UIManager.Instance.dialogueText, eventLogue.logues[2].logue, 0.1f));
        }



        

        
    }



}
