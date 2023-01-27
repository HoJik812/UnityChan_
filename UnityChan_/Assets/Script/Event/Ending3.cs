using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ending3 : GameEvent
{
    public override void EventOn()
    {
        UIManager.Instance.Dialogue();//대화창 활성화
        CameraManager.Instance.cameras[12].gameObject.SetActive(true);
        StartCoroutine(Typing(UIManager.Instance.dialogueText, eventLogue.logues[currentIndex].logue, 0.1f));
        Debug.Log("함수 실행");
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

        currentIndex++;

        yield return new WaitForSeconds(1f);//다음 로그까지의 텀(1초)

        if (currentIndex < eventLogue.logues.Length)
        {
            Debug.Log("다음 대화");
            yield return StartCoroutine(Typing(UIManager.Instance.dialogueText, eventLogue.logues[currentIndex].logue, 0.1f));
        }
        else if (currentIndex >= eventLogue.logues.Length)
        {
            Debug.Log("대화 끝");
            currentIndex = 0;
            //UIManager.Instance.UIInit();//이벤트 대화 종료 후 플레이 ui로 전환
            //게임오버창 만들기(타이틀로 버튼)
            Time.timeScale = 0;
            UIManager.Instance.GameOver();
            yield break;

        }

    }
}
