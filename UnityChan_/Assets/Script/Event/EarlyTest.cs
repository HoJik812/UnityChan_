using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarlyTest : GameEvent
{
    public bool isEnd;

    private void Awake()
    {
        isEnd = false;
    }
    public override void EventOn()
    {
        
        UIManager.Instance.Dialogue();//대화창 활성화   
        StartCoroutine(Typing(UIManager.Instance.dialogueText, eventLogue.logues[currentIndex].logue, 0.1f));
        
    }
}
