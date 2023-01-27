using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fail : GameEvent
{
    public override void EventOn()
    {
  
        StartCoroutine(Typing(UIManager.Instance.dialogueText, eventLogue.logues[currentIndex].logue, 0.1f));
        Debug.Log("함수 실행");
    }
}
