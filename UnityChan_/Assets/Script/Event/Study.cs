using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study : GameEvent
{

    public override void EventOn()
    {
        int rand = Random.Range(1, 11);//대성공변수
        float rand2 = Random.Range(1f, 11f);//실패 변수
       // Debug.Log(rand2);
        UIManager.Instance.Dialogue();//대화창 활성화
        UIManager.Instance.gameTime.Time++;// 시간 +1
       
        if (rand2 < GameManager.Instance.chance)//실패시
        {
            EventManager.Instance.studyFail.EventOn();
        }
        else if(rand > 7)//30퍼 확률로 슈퍼트레이닝
        {
            //전용 이펙트랑 사운드 추가
            EventManager.Instance.superStudy.EventOn();
        }
        else//성공시
        {
            CameraManager.Instance.cameras[7].gameObject.SetActive(true);
            
            GameManager.Instance.player.Intel += 4;
            GameManager.Instance.player.Health -= 20;
            StartCoroutine(Typing(UIManager.Instance.dialogueText, eventLogue.logues[currentIndex].logue, 0.1f));
            Debug.Log("공부!");
        }
        
    }
}
