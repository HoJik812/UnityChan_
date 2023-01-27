//using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;


public class Sleep : GameEvent
{
   
    public override void EventOn()
    {
        int rand = Random.Range(1, 11);
        Debug.Log(rand);
        UIManager.Instance.Dialogue();//대화창 활성화
        UIManager.Instance.gameTime.Time++;// 시간 +1
        if (rand >7)//30퍼 확률로 악몽꾼다.
        {
            CameraManager.Instance.cameras[2].gameObject.SetActive(true);// 일반이랑 똑같지만
            //전용 이펙트와 사운드 추가
            EventManager.Instance.nightMare.EventOn();
        }
        else
        {
            CameraManager.Instance.cameras[2].gameObject.SetActive(true);
            GameManager.Instance.player.Health += 30;
            StartCoroutine(Typing(UIManager.Instance.dialogueText, eventLogue.logues[currentIndex].logue, 0.1f));
            Debug.Log("꿀잠~");
        }
        
    }
}
