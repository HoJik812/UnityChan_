using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperRest : GameEvent
{
    public override void EventOn()//�̺�Ʈ ���� : ��ȭâ�� �ؽ�Ʈ Ȱ��ȭ�ϰ�, ���� ��ũ���ͺ� ������Ʈ�� ������ ��ȭâ�� ���, �׸��� �ð� +1
    {
        CameraManager.Instance.cameras[10].gameObject.SetActive(true);
        GameManager.Instance.player.Health += 50;
        StartCoroutine(Typing(UIManager.Instance.dialogueText, eventLogue.logues[currentIndex].logue, 0.1f));
        Debug.Log("��.... �츶��!!");
    }
}
