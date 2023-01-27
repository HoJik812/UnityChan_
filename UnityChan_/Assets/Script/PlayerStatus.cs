using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField]
    private int health;//체력
    [SerializeField]
    private int str;//힘
    [SerializeField] 
    private int intel;//지능
    [SerializeField]
    private int maxHealth = 100;
    public int Health
    {
        get
        {
            if (health >= maxHealth)//최대체력보다 많아지지 않게
            {
                health = maxHealth;
            }
            else if(health <=0)//0 밑으로 떨어지지 않게
            {
                health = 0;
            }
                return health;
        }
        set {
                health = value;
            }
    }

    public int Str
    {
        get {
             if(str <=0)
            {
                str = 0;
            }
            return str; } 
        set { str = value; }
    }
    public int Intel
    {
        get {
            if(intel <=0)
            {
                intel = 0;
            }
            return intel; }   
        set { intel = value; }
    }

    public int MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }

    private void Awake()
    {
        health = maxHealth;
        str = 10;
        intel = 10;  
    }


}
