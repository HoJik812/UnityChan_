using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ending : GameEvent
{
    public override void EventOn()
    {
        UIManager.Instance.Dialogue();//대화창 활성화
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
            if(GameManager.Instance.player.Str > 100)
            {
                //운동엔딩
                EventManager.Instance.ending1.EventOn();
            }
            else if(GameManager.Instance.player.Intel > 100)
            {
                //공부엔딩
                EventManager.Instance.ending2.EventOn();
            }
            else
            {
                //백수엔딩
                EventManager.Instance.ending3.EventOn();
            }

            yield break;

        }

    }
}
