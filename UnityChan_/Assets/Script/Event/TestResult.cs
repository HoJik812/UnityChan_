using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestResult : GameEvent
{

    public bool IsTalk;

    private void Awake()
    {
        IsTalk = false;
    }
    public override void EventOn()
    {

        UIManager.Instance.Dialogue();//��ȭâ Ȱ��ȭ
        UIManager.Instance.gameTime.Time++;
        CameraManager.Instance.cameras[6].gameObject.SetActive(true);
        

        StartCoroutine(Typing(UIManager.Instance.dialogueText, eventLogue.logues[currentIndex].logue, 0.1f));

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

       

        yield return new WaitForSeconds(1f);//���� �αױ����� ��(1��)

        //if (currentIndex < eventLogue.logues.Length)
        //{
        //    Debug.Log("���� ��ȭ");
        //    yield return StartCoroutine(Typing(UIManager.Instance.dialogueText, eventLogue.logues[currentIndex].logue, 0.1f));
        //}

        if (currentIndex >= 2)//eventLogue.logues.Length)
        {
            Debug.Log("��ȭ ��");
            currentIndex = 0;
            UIManager.Instance.UIInit();//�̺�Ʈ ��ȭ ���� �� �÷��� ui�� ��ȯ
            yield break;

        }

        currentIndex = 2;//���� ��ȭ ���� ������

        if (EventManager.Instance.test.IsPass)//���� �����
        {
            GameManager.Instance.player.Intel += 10;
            IsTalk = true;
            yield return StartCoroutine(Typing(UIManager.Instance.dialogueText, eventLogue.logues[1].logue, 0.1f));
        }
        else//���� ���հݽ�
        {
            IsTalk = true;
            GameManager.Instance.player.Intel -= 10;
            GameManager.Instance.player.Health -= 20;
            yield return StartCoroutine(Typing(UIManager.Instance.dialogueText, eventLogue.logues[2].logue, 0.1f));
        }



        

        
    }



}
