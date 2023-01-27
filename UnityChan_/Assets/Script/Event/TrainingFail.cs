using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingFail : Fail
{
    public override void EventOn()//이벤트 실행 : 대화창과 텍스트 활성화하고, 받은 스크럽터블 오브젝트의 내용을 대화창에 출력, 그리고 시간 +1
    {
        CameraManager.Instance.cameras[4].gameObject.SetActive(true);
        GameManager.Instance.player.Health -= 30;
        GameManager.Instance.player.MaxHealth -= 4;
        GameManager.Instance.player.Str -= 4;
        StartCoroutine(Typing(UIManager.Instance.dialogueText, eventLogue.logues[currentIndex].logue, 0.1f));
        Debug.Log("훈련 실패");

    }
}
