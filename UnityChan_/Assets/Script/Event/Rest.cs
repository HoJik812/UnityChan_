using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rest : GameEvent
{
    public override void EventOn()
    {
        int rand = Random.Range(1, 11);//�޽��� ������ �Ǻ� �� ���� ����
        UIManager.Instance.Dialogue();//��ȭâ Ȱ��ȭ
        UIManager.Instance.gameTime.Time++;// �ð� +1
        Debug.Log(rand);
        if(rand < 7)//�Ϲ� �޽�
        {
            CameraManager.Instance.cameras[3].gameObject.SetActive(true);//�Ϲ� �޽Ŀ� �ش��ϴ� ī�޶� Ȱ��ȭ
            GameManager.Instance.player.Health += 30;
            StartCoroutine(Typing(UIManager.Instance.dialogueText, eventLogue.logues[currentIndex].logue, 0.1f));
        }
        else if(rand == 7)// ���ϰ� �޽�(��޸�Ʈ)
        {
            EventManager.Instance.exRest.EventOn();
        }
        else// �ۿ��� ���ִ°� �Ա�(ü�� �� ȸ��)
        {
            EventManager.Instance.superRest.EventOn();
        }
    }
}
