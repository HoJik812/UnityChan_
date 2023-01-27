using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]//클래스를 직렬화
public class Logue
{
    public string name;// 화자의 이름

    [TextArea(2, 5)]//인스펙터창에서 수정이 용이하게 하기 위해 설정

    public string logue;//로그 내용
}

[CreateAssetMenu(menuName = "ScriptableObject/EventLogue")]//에셋 윈도우에 만들 수 있게 설정
public class EventLogue: ScriptableObject
{
    public Logue[] logues;//대화가 여러개일 경우를 고려해서 배열로 설정
}


