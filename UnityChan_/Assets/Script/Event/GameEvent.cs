using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameEvent : MonoBehaviour
{
    public EventLogue eventLogue;//�̺�Ʈ �αװ� ��� ������Ʈ

    public int currentIndex =0;//���� �α� ��ġ
   

    public virtual void EventOn()//�̺�Ʈ ���� : ��ȭâ�� �ؽ�Ʈ Ȱ��ȭ�ϰ�, �����ִ� ��ũ���ͺ� ������Ʈ�� ������ ��ȭâ�� ���
    {
        UIManager.Instance.Dialogue();//��ȭâ Ȱ��ȭ
        UIManager.Instance.gameTime.Time++;// �ð� +1
        
        StartCoroutine(Typing(UIManager.Instance.dialogueText, eventLogue.logues[currentIndex].logue, 0.1f));//��ȭâ�� �ѱ��ھ� �α� ���
       
    }

    public virtual IEnumerator Typing(TextMeshProUGUI typingText, string message, float speed)// �ѱ��ھ� ����ϴ� �Լ�
    {
        if(eventLogue.logues[currentIndex].name != null)//�̸��� ������?       
        {
            UIManager.Instance.nameText.text = eventLogue.logues[currentIndex].name;//�̸� ���
        }
        else//�̸��� ������?
        {
            UIManager.Instance.nameText.text = " ";//�̸��� ����ó��
        }

        for (int i = 0; i < message.Length; i++)
        {
            typingText.text = message.Substring(0, i + 1);//�α� �ѱ��ھ� ���
            yield return new WaitForSeconds(speed);//���� ���� ��±����� ��
        }

        currentIndex++;

        yield return new WaitForSeconds(1f);//���� �αױ����� ��(1��)

        if (currentIndex < eventLogue.logues.Length)//���� �αװ� ���� ���
        {
            yield return StartCoroutine(Typing(UIManager.Instance.dialogueText, eventLogue.logues[currentIndex].logue, 0.1f));//���� �α׸� �ѱ��ھ� ���(����Լ�)
        }
        else if(currentIndex >= eventLogue.logues.Length)//���� �αװ� ���� ���
        {
            currentIndex = 0;//0���� �ʱ�ȭ
            UIManager.Instance.UIInit();//�̺�Ʈ ��ȭ ���� ��, ���� �÷��� ui�� ��ȯ�ϴ� �Լ� ����
            yield break;   
        }
        
    }

}
