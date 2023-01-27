using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ending3 : GameEvent
{
    public override void EventOn()
    {
        UIManager.Instance.Dialogue();//��ȭâ Ȱ��ȭ
        CameraManager.Instance.cameras[12].gameObject.SetActive(true);
        StartCoroutine(Typing(UIManager.Instance.dialogueText, eventLogue.logues[currentIndex].logue, 0.1f));
        Debug.Log("�Լ� ����");
    }

    public override IEnumerator Typing(TextMeshProUGUI typingText, string message, float speed)// �ѱ��ھ� ����ϴ� �Լ�
    {
        if (eventLogue.logues[currentIndex].name != null)//�̸��� ������?       
        {
            UIManager.Instance.nameText.text = eventLogue.logues[currentIndex].name;
        }
        else//�̸��� ������?
        {
            UIManager.Instance.nameText.text = " ";
        }

        for (int i = 0; i < message.Length; i++)
        {
            typingText.text = message.Substring(0, i + 1);
            yield return new WaitForSeconds(speed);
        }

        currentIndex++;

        yield return new WaitForSeconds(1f);//���� �αױ����� ��(1��)

        if (currentIndex < eventLogue.logues.Length)
        {
            Debug.Log("���� ��ȭ");
            yield return StartCoroutine(Typing(UIManager.Instance.dialogueText, eventLogue.logues[currentIndex].logue, 0.1f));
        }
        else if (currentIndex >= eventLogue.logues.Length)
        {
            Debug.Log("��ȭ ��");
            currentIndex = 0;
            //UIManager.Instance.UIInit();//�̺�Ʈ ��ȭ ���� �� �÷��� ui�� ��ȯ
            //���ӿ���â �����(Ÿ��Ʋ�� ��ư)
            Time.timeScale = 0;
            UIManager.Instance.GameOver();
            yield break;

        }

    }
}
