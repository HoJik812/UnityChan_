using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingFail : Fail
{
    public override void EventOn()//�̺�Ʈ ���� : ��ȭâ�� �ؽ�Ʈ Ȱ��ȭ�ϰ�, ���� ��ũ���ͺ� ������Ʈ�� ������ ��ȭâ�� ���, �׸��� �ð� +1
    {
        CameraManager.Instance.cameras[4].gameObject.SetActive(true);
        GameManager.Instance.player.Health -= 30;
        GameManager.Instance.player.MaxHealth -= 4;
        GameManager.Instance.player.Str -= 4;
        StartCoroutine(Typing(UIManager.Instance.dialogueText, eventLogue.logues[currentIndex].logue, 0.1f));
        Debug.Log("�Ʒ� ����");

    }
}
