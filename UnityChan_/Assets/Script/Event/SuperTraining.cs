using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperTraining : GameEvent
{
    public override void EventOn()//�̺�Ʈ ���� : ��ȭâ�� �ؽ�Ʈ Ȱ��ȭ�ϰ�, ���� ��ũ���ͺ� ������Ʈ�� ������ ��ȭâ�� ���, �׸��� �ð� +1
    {
        CameraManager.Instance.cameras[1].gameObject.SetActive(true);//�Ϲ� �����̶� ������
                                                                     //���� ����Ʈ & ���� ���
        GameManager.Instance.player.Health -= 30;
        GameManager.Instance.player.MaxHealth += 8;
        GameManager.Instance.player.Str += 8;
        StartCoroutine(Typing(UIManager.Instance.dialogueText, eventLogue.logues[currentIndex].logue, 0.1f));
        Debug.Log("�Ʒ� �� �� ��");

    }

}
