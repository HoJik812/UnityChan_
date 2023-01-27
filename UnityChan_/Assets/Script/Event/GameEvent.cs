using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameEvent : MonoBehaviour
{
    public EventLogue eventLogue;//이벤트 로그가 담긴 오브젝트

    public int currentIndex =0;//현재 로그 위치
   

    public virtual void EventOn()//이벤트 실행 : 대화창과 텍스트 활성화하고, 갖고있는 스크럽터블 오브젝트의 내용을 대화창에 출력
    {
        UIManager.Instance.Dialogue();//대화창 활성화
        UIManager.Instance.gameTime.Time++;// 시간 +1
        
        StartCoroutine(Typing(UIManager.Instance.dialogueText, eventLogue.logues[currentIndex].logue, 0.1f));//대화창에 한글자씩 로그 출력
       
    }

    public virtual IEnumerator Typing(TextMeshProUGUI typingText, string message, float speed)// 한글자씩 출력하는 함수
    {
        if(eventLogue.logues[currentIndex].name != null)//이름이 있으면?       
        {
            UIManager.Instance.nameText.text = eventLogue.logues[currentIndex].name;//이름 출력
        }
        else//이름이 없으면?
        {
            UIManager.Instance.nameText.text = " ";//이름을 공백처리
        }

        for (int i = 0; i < message.Length; i++)
        {
            typingText.text = message.Substring(0, i + 1);//로그 한글자씩 출력
            yield return new WaitForSeconds(speed);//다음 글자 출력까지의 텀
        }

        currentIndex++;

        yield return new WaitForSeconds(1f);//다음 로그까지의 텀(1초)

        if (currentIndex < eventLogue.logues.Length)//다음 로그가 있을 경우
        {
            yield return StartCoroutine(Typing(UIManager.Instance.dialogueText, eventLogue.logues[currentIndex].logue, 0.1f));//다음 로그를 한글자씩 출력(재귀함수)
        }
        else if(currentIndex >= eventLogue.logues.Length)//다음 로그가 없을 경우
        {
            currentIndex = 0;//0으로 초기화
            UIManager.Instance.UIInit();//이벤트 대화 종료 후, 메인 플레이 ui로 전환하는 함수 실행
            yield break;   
        }
        
    }

}
