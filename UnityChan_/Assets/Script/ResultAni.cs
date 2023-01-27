using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultAni : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(EventManager.Instance.testResult.IsTalk)
        {
            if (EventManager.Instance.test.IsPass)
            {
                Debug.Log("victory");
                animator.SetTrigger("win");

            }
            else
            {
                Debug.Log("fail");
                animator.SetTrigger("lose");
            } 
                
        }
    }
}
