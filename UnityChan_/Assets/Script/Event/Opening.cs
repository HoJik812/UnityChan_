using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Opening : GameEvent
{
    public override void EventOn()
    {
        UIManager.Instance.dayImage.SetActive(false);
        UIManager.Instance.timeImage.SetActive(false);
        UIManager.Instance.Dialogue();//��ȭâ Ȱ��ȭ
        CameraManager.Instance.cameras[11].gameObject.SetActive(true);
        StartCoroutine(Typing(UIManager.Instance.dialogueText, eventLogue.logues[currentIndex].logue, 0.1f));
        Debug.Log("�Լ� ����");
    }

    
}
