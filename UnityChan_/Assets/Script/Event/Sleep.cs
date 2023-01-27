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
        UIManager.Instance.Dialogue();//��ȭâ Ȱ��ȭ
        UIManager.Instance.gameTime.Time++;// �ð� +1
        if (rand >7)//30�� Ȯ���� �Ǹ��۴�.
        {
            CameraManager.Instance.cameras[2].gameObject.SetActive(true);// �Ϲ��̶� �Ȱ�����
            //���� ����Ʈ�� ���� �߰�
            EventManager.Instance.nightMare.EventOn();
        }
        else
        {
            CameraManager.Instance.cameras[2].gameObject.SetActive(true);
            GameManager.Instance.player.Health += 30;
            StartCoroutine(Typing(UIManager.Instance.dialogueText, eventLogue.logues[currentIndex].logue, 0.1f));
            Debug.Log("����~");
        }
        
    }
}
