using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime : MonoBehaviour//������ �ð� �帧�� ����ϴ� Ŭ����
{
    private int time;
    private int day;
    
    public int Time
    {
        get {
            
            if (time == 5)
            {
               day++;
               time = 1;
               Debug.Log("�Ϸ簡 �������ϴ�");
               
            } 
            return time; 
        }
        set { time = value;}
    }

    public int Day
    {
        get { return day; }     
        set { day = value; }
    }

    private void Awake()
    {
        day = 1;
        time = 2;
       
    }

 }
