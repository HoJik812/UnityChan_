using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyFail : Fail
{
    public override void EventOn()//�̺�Ʈ ���� : ��ȭâ�� �ؽ�Ʈ Ȱ��ȭ�ϰ�, ���� ��ũ���ͺ� ������Ʈ�� ������ ��ȭâ�� ���, �׸��� �ð� +1
    {
        GameManager.Instance.player.Health -= 20;
        GameManager.Instance.player.Intel -= 4;
        CameraManager.Instance.cameras[8].gameObject.SetActive(true);
        StartCoroutine(Typing(UIManager.Instance.dialogueText, eventLogue.logues[currentIndex].logue, 0.1f));
        Debug.Log("���� ����");

    }
}
