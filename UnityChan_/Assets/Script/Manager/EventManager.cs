using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public enum EVENT_TYPE
{
    OPENING,TRAINING,STUDY,SLEEP,TRAINGFAIL,STUDYFAIL
}

public class EventManager : Singleton<EventManager>
{
    //public GameEvent[] events;

    public Opening gameOpening;
    public Training training;
    public Study study;
    public Sleep sleep;
    public TrainingFail trainingFail;
    public StudyFail studyFail;
    public Rest rest;
    public NightMare nightMare;
    public SuperStudy superStudy;
    public SuperTraining superTraining;
    public ExRest exRest;
    public SuperRest superRest;
    public EarlyTest earlyTest;
    public Test test;
    public TestResult testResult;
    public BeforeEnding beforeEnding;
    public Ending ending;
    public Ending1 ending1;
    public Ending2 ending2;
    public Ending3 ending3;

    private void Awake()
    {
        gameOpening = GetComponent<Opening>();
        training = GetComponent<Training>();
        study = GetComponent<Study>();
        sleep = GetComponent<Sleep>();
        trainingFail = GetComponent<TrainingFail>();
        studyFail = GetComponent<StudyFail>();
        rest = GetComponent<Rest>();
        nightMare = GetComponent<NightMare>();
        superStudy = GetComponent<SuperStudy>();
        superTraining = GetComponent<SuperTraining>();
        exRest = GetComponent<ExRest>();
        superRest = GetComponent<SuperRest>();
        earlyTest = GetComponent<EarlyTest>();
        test= GetComponent<Test>();
        testResult = GetComponent<TestResult>();
        beforeEnding = GetComponent<BeforeEnding>();
        ending = GetComponent<Ending>();
        ending1 = GetComponent<Ending1>();
        ending2 = GetComponent<Ending2>();
        ending3 = GetComponent<Ending3>();

    }

    //public void EventOn(EVENT_TYPE type)
    //{
    //    switch (type)
    //    {
    //        case EVENT_TYPE.OPENING:
    //            gameOpening.EventOn();
    //            break;
    //    }
    //}

    public void WhenEvent()//���ǿ� �´� �̺�Ʈ�� �����ϴ� �Լ�(��� �߰� ������ ������ ���ɼ�)
    {
       //if(rest.IsRest && (rest.rand2 < 2))// �޽��� 10�� Ȯ����..
       //{
       //    //�Ҹ�ġ�� �̺�Ʈ
       //    rest.IsRest = false;
       //}

        if (UIManager.Instance.gameTime.Time == 1)//���� �ܴ�.
        {
            EventManager.Instance.sleep.EventOn();
        }

        if ((UIManager.Instance.gameTime.Time == 3) && (UIManager.Instance.gameTime.Day == 3) && (!EventManager.Instance.earlyTest.isEnd))
        {
            //�������� �̸� �˷��ִ� �̺�Ʈ
            EventManager.Instance.earlyTest.isEnd = true;
            EventManager.Instance.earlyTest.EventOn();
        }

        if ((UIManager.Instance.gameTime.Time == 3) && (UIManager.Instance.gameTime.Day == 5))
        {
            //�������� �̺�Ʈ
            EventManager.Instance.test.EventOn();
        }

        if ((UIManager.Instance.gameTime.Time == 3) && (UIManager.Instance.gameTime.Day == 6))
        {
            //�������� ��� �˷��ִ� �̺�Ʈ
            EventManager.Instance.testResult.EventOn();
        }

        if ((UIManager.Instance.gameTime.Time == 4) && (UIManager.Instance.gameTime.Day == 9) && (!EventManager.Instance.beforeEnding.isEnd))
        {
            EventManager.Instance.beforeEnding.isEnd = true;
            EventManager.Instance.beforeEnding.EventOn();
            // �������� ��ȭ �̺�Ʈ
        }

        if ((UIManager.Instance.gameTime.Time == 3) && (UIManager.Instance.gameTime.Day == 10))
        {
           //����
           EventManager.Instance.ending.EventOn();
        }

    }
}
