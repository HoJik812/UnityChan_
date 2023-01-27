using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rest : GameEvent
{
    public override void EventOn()
    {
        int rand = Random.Range(1, 11);//휴식의 종류를 판별 할 랜덤 변수
        UIManager.Instance.Dialogue();//대화창 활성화
        UIManager.Instance.gameTime.Time++;// 시간 +1
        Debug.Log(rand);
        if(rand < 7)//일반 휴식
        {
            CameraManager.Instance.cameras[3].gameObject.SetActive(true);//일반 휴식에 해당하는 카메라를 활성화
            GameManager.Instance.player.Health += 30;
            StartCoroutine(Typing(UIManager.Instance.dialogueText, eventLogue.logues[currentIndex].logue, 0.1f));
        }
        else if(rand == 7)// 과하게 휴식(디메리트)
        {
            EventManager.Instance.exRest.EventOn();
        }
        else// 밖에서 맛있는거 먹기(체력 더 회복)
        {
            EventManager.Instance.superRest.EventOn();
        }
    }
}
