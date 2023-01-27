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

    public void WhenEvent()//조건에 맞는 이벤트를 실행하는 함수(계속 추가 가능한 무한한 가능성)
    {
       //if(rest.IsRest && (rest.rand2 < 2))// 휴식중 10퍼 확률로..
       //{
       //    //소매치기 이벤트
       //    rest.IsRest = false;
       //}

        if (UIManager.Instance.gameTime.Time == 1)//잠을 잔다.
        {
            EventManager.Instance.sleep.EventOn();
        }

        if ((UIManager.Instance.gameTime.Time == 3) && (UIManager.Instance.gameTime.Day == 3) && (!EventManager.Instance.earlyTest.isEnd))
        {
            //쪽지시험 미리 알려주는 이벤트
            EventManager.Instance.earlyTest.isEnd = true;
            EventManager.Instance.earlyTest.EventOn();
        }

        if ((UIManager.Instance.gameTime.Time == 3) && (UIManager.Instance.gameTime.Day == 5))
        {
            //쪽지시험 이벤트
            EventManager.Instance.test.EventOn();
        }

        if ((UIManager.Instance.gameTime.Time == 3) && (UIManager.Instance.gameTime.Day == 6))
        {
            //쪽지시험 결과 알려주는 이벤트
            EventManager.Instance.testResult.EventOn();
        }

        if ((UIManager.Instance.gameTime.Time == 4) && (UIManager.Instance.gameTime.Day == 9) && (!EventManager.Instance.beforeEnding.isEnd))
        {
            EventManager.Instance.beforeEnding.isEnd = true;
            EventManager.Instance.beforeEnding.EventOn();
            // 엔딩직전 대화 이벤트
        }

        if ((UIManager.Instance.gameTime.Time == 3) && (UIManager.Instance.gameTime.Day == 10))
        {
           //엔딩
           EventManager.Instance.ending.EventOn();
        }

    }
}
