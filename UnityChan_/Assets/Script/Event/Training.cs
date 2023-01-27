using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Training : GameEvent
{
    public override void EventOn()
    {
        int rand = Random.Range(1, 11);//�뼺�� ����
        float rand2 = Random.Range(1f, 11f);//���� ����
        //Debug.Log(rand2);
        UIManager.Instance.Dialogue();//��ȭâ Ȱ��ȭ
        UIManager.Instance.gameTime.Time++;// �ð� +1

        if (rand2 < GameManager.Instance.chance)//���н�
        {
            
            EventManager.Instance.trainingFail.EventOn();
        }
        else if(rand > 7)//30�� Ȯ���� ���� Ʈ���̴�
        {
            
            EventManager.Instance.superTraining.EventOn();
        }
        else//������
        {
            CameraManager.Instance.cameras[1].gameObject.SetActive(true);
            GameManager.Instance.player.Health -= 30;
            GameManager.Instance.player.MaxHealth += 4;
            GameManager.Instance.player.Str += 4;
            _ = StartCoroutine(Typing(UIManager.Instance.dialogueText, eventLogue.logues[currentIndex].logue, 0.1f));
            Debug.Log("�Ʒ� ����");
        }
        
    }
}
