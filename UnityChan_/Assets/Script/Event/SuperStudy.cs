using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperStudy : GameEvent
{
    public override void EventOn()//�̺�Ʈ ���� : ��ȭâ�� �ؽ�Ʈ Ȱ��ȭ�ϰ�, ���� ��ũ���ͺ� ������Ʈ�� ������ ��ȭâ�� ���, �׸��� �ð� +1
    {
        GameManager.Instance.player.Health -= 20;
        GameManager.Instance.player.Intel += 8;
        CameraManager.Instance.cameras[7].gameObject.SetActive(true);//�Ϲ��̶� �Ȱ�����
        StartCoroutine(Typing(UIManager.Instance.dialogueText, eventLogue.logues[currentIndex].logue, 0.1f));
        Debug.Log("��! ��!");

    }
}
