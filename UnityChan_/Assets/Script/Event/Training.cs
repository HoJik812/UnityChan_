using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Training : GameEvent
{
    public override void EventOn()
    {
        int rand = Random.Range(1, 11);//대성공 변수
        float rand2 = Random.Range(1f, 11f);//실패 변수
        //Debug.Log(rand2);
        UIManager.Instance.Dialogue();//대화창 활성화
        UIManager.Instance.gameTime.Time++;// 시간 +1

        if (rand2 < GameManager.Instance.chance)//실패시
        {
            
            EventManager.Instance.trainingFail.EventOn();
        }
        else if(rand > 7)//30퍼 확률로 슈퍼 트레이닝
        {
            
            EventManager.Instance.superTraining.EventOn();
        }
        else//성공시
        {
            CameraManager.Instance.cameras[1].gameObject.SetActive(true);
            GameManager.Instance.player.Health -= 30;
            GameManager.Instance.player.MaxHealth += 4;
            GameManager.Instance.player.Str += 4;
            _ = StartCoroutine(Typing(UIManager.Instance.dialogueText, eventLogue.logues[currentIndex].logue, 0.1f));
            Debug.Log("훈련 성공");
        }
        
    }
}
