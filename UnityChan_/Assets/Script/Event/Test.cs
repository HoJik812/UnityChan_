using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : GameEvent
{

    public bool IsPass;

    private void Awake()
    {
        IsPass = false;
    }
    public override void EventOn()
    {

        UIManager.Instance.Dialogue();//대화창 활성화
        UIManager.Instance.gameTime.Time++;// 시간 +1

        if(GameManager.Instance.player.Intel >=30)//지능 30 이상시
        {
            IsPass = true;// 통과
        }
        else
        {
            IsPass = false;// 불합격
        }
        Debug.Log(IsPass);
        CameraManager.Instance.cameras[9].gameObject.SetActive(true);
        StartCoroutine(Typing(UIManager.Instance.dialogueText, eventLogue.logues[currentIndex].logue, 0.1f));

    }
}
