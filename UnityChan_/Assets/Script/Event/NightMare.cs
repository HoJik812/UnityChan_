using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightMare : GameEvent
{
    public override void EventOn()//�̺�Ʈ ���� : ��ȭâ�� �ؽ�Ʈ Ȱ��ȭ�ϰ�, ���� ��ũ���ͺ� ������Ʈ�� ������ ��ȭâ�� ���, �׸��� �ð� +1
    {
        GameManager.Instance.player.Health += 15;
        StartCoroutine(Typing(UIManager.Instance.dialogueText, eventLogue.logues[currentIndex].logue, 0.1f));
        Debug.Log("��! ��!");
    }
}
