using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : GameEvent
{

    public bool IsPass;

    private void Awake()
    {
        IsPass = false;
    }
    public override void EventOn()
    {

        UIManager.Instance.Dialogue();//��ȭâ Ȱ��ȭ
        UIManager.Instance.gameTime.Time++;// �ð� +1

        if(GameManager.Instance.player.Intel >=30)//���� 30 �̻��
        {
            IsPass = true;// ���
        }
        else
        {
            IsPass = false;// ���հ�
        }
        Debug.Log(IsPass);
        CameraManager.Instance.cameras[9].gameObject.SetActive(true);
        StartCoroutine(Typing(UIManager.Instance.dialogueText, eventLogue.logues[currentIndex].logue, 0.1f));

    }
}
