using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]//Ŭ������ ����ȭ
public class Logue
{
    public string name;// ȭ���� �̸�

    [TextArea(2, 5)]//�ν�����â���� ������ �����ϰ� �ϱ� ���� ����

    public string logue;//�α� ����
}

[CreateAssetMenu(menuName = "ScriptableObject/EventLogue")]//���� �����쿡 ���� �� �ְ� ����
public class EventLogue: ScriptableObject
{
    public Logue[] logues;//��ȭ�� �������� ��츦 ����ؼ� �迭�� ����
}


