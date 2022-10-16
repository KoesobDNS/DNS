﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class EventManager : MonoBehaviour
{
    #region Enum Types
    public enum EventType
    {
        LifeLake,
        CampFire,
        TelltheTruth,
        Merchant,
        Villain,
        QnA
    }
    #endregion

    // 해당 이벤트 지역에 나타날 지역 유형
    private EventType Type;

    public GameObject QuestionBox, MBTIQnABox, ResultBox, Image;
    private GameObject EventPanel, Name, Ask, choiceA, choiceB;
    public int ChoiceMode;

    // 이벤트에 Result 관련 변수
    public string ResultMent;
    public string ResultType;
    public string ResultNum;
    public string ResultSign;
    public List<Hero> ResultTarget = new List<Hero>();

    void Start()
    {
        ChoiceMode = 0;
        Type = (EventType)0;
        //Type = (EventType)UnityEngine.Random.Range(0, 5);
        ResultTarget.Clear();


        if ((int)Type < 5)
        {
            EventPanel = Instantiate(QuestionBox, new Vector3(1200, 540, 0), Quaternion.identity);
            EventPanel.transform.SetParent(GameObject.FindWithTag("UI").transform);

            Name = EventPanel.transform.GetChild(0).gameObject;
            Ask = EventPanel.transform.GetChild(1).gameObject;
            choiceA = EventPanel.transform.GetChild(2).gameObject;
            choiceB = EventPanel.transform.GetChild(3).gameObject;
            choiceA.GetComponent<Button>().onClick.AddListener(ChoiceOption);
            choiceB.GetComponent<Button>().onClick.AddListener(ChoiceOption);

            //choiceB.GetComponent<Button>().onClick.RemoveListener(ChoiceOptionB);
        }

        // Ramdom으로 선택된 Event 유형에 따라서 Set
        SetEvent(Type);
    }

    public void SetEvent(EventType type)
    {
        switch (Type)
        {
            case EventType.LifeLake:
                {
                    Name.GetComponent<TextMeshProUGUI>().text = "생명의 샘";
                    Ask.GetComponent<TextMeshProUGUI>().text = "용병들은 숲을 지나가다 생명의 샘을 발견했습니다! \n하지만 너무 조그마해서 모두가 충분히 마실 순 없습니다.";
                    choiceA.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "모든 용병의 생명력을 조금씩 회복시킨다";
                    choiceB.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "한 용병의 생명력을 완전히 회복시킨다";
                    break;
                }
            case EventType.CampFire:
                {
                    Name.GetComponent<TextMeshProUGUI>().text = "캠프파이어";
                    Ask.GetComponent<TextMeshProUGUI>().text = "용병들이 오늘 밤 캠프파이어를 원합니다 \n어떤 활동을 하는 것이 좋을까요?";
                    choiceA.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "진실게임 \n서로가 하지 못했던 속 깊은 대화를 나눕니다\n팀워크 포인트가 영구적으로 2 증가합니다.";
                    choiceB.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "휴식\n모닥불에 모여 앉아 하루를 마무리합니다\n모든 용병의 생명력을 10%씩 회복합니다.";
                    break;
                }
            case EventType.TelltheTruth:
                {
                    Name.GetComponent<TextMeshProUGUI>().text = "진실의 방으로";
                    Ask.GetComponent<TextMeshProUGUI>().text = "우리 팀 중 누군가는 거짓말을 하고 있을지도 모릅니다.\n당신은 진실을 원하십니까?";
                    choiceA.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "진실을 원한다.";
                    choiceB.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "진실을 원하지 않는다.";
                    break;
                }
            case EventType.Merchant:
                {
                    Name.GetComponent<TextMeshProUGUI>().text = "떠돌이 상인";
                    Ask.GetComponent<TextMeshProUGUI>().text = "무언가를 잔뜩 실은 마차를 끌고 허름한 차림의 누군가가 지나갑니다.\n근방에서 유명한 떠돌이 상인입니다.";
                    choiceA.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "금화 100을 지불하고, 일반 장비를 구매합니다.";
                    choiceB.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "금화 1000을 지불하고, 특수 장비를 구매합니다.";
                    break;
                }
            case EventType.Villain:
                {
                    Name.GetComponent<TextMeshProUGUI>().text = "악당 출현";
                    Ask.GetComponent<TextMeshProUGUI>().text = "용병들은 숲을 지나가다 악당의 습격을 받았습니다.\n다들 지쳐있는데 어떡하지?";
                    choiceA.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "이보 전진을 위한 일보 후퇴...\n도망갑니다.\n그러나 모든 용병의 허기가 일부 감소합니다.";
                    choiceB.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "맞서 싸웁니다.\n금화 500을 획득할 수 있으나, 모든 용병이 체력을 일부 잃습니다.";
                    break;
                }
            case EventType.QnA:
                {
                    SetQnA();
                    break;
                }
        }
    }

    public void ChoiceOption()
    {
        string choice = this.transform.name;
        ChoiceMode = Int32.Parse(choice.Substring(choice.Length-1));
    }

    public void Result()
    {
        EventPanel = Instantiate(ResultBox, new Vector3(1200, 540, 0), Quaternion.identity);
        EventPanel.transform.SetParent(GameObject.FindWithTag("UI").transform);

        EventPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = ResultMent;
        EventPanel.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = ResultType;
        EventPanel.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text = ResultNum.ToString();
        EventPanel.transform.GetChild(1).GetChild(2).GetComponent<TextMeshProUGUI>().text = ResultSign;
        
        foreach (Hero _hero in ResultTarget)
        {
            Debug.Log(ResultTarget.Count());
            GameObject HeroImage = Instantiate(Image, new Vector3(0, 0, 0), Quaternion.identity);
            HeroImage.transform.SetParent(EventPanel.transform.GetChild(2).GetChild(0).transform);
            HeroImage.GetComponent<Image>().sprite = GameManager.Data.LoadSprite(_hero.GUID);
        }

    }


    private void LifeLake(int mode)
    {
        // 선택지
        Debug.Log("LifeLake " + mode + " 선택지의 기능을 수행합니다");
        Destroy(EventPanel);

        if (mode == 1)
        {
            ResultTarget = GameManager.Hero.GetHeroList();
            foreach (Hero _hero in ResultTarget)
            {
                // 체력을 용병의 최대 체력의 10%씩 회복.
                _hero.CurrentHP += _hero.MaxHP * (float)0.1;

                if (_hero.CurrentHP > _hero.MaxHP)
                {
                    _hero.CurrentHP = _hero.MaxHP;
                }
            }
            ResultMent = "모든 용병의 생명력이 조금씩 회복됩니다!";
            ResultType = "체력";
            ResultNum = "10 %";
            ResultSign = "+";
        }
        else if (mode == 2)
        {
            ResultTarget.Add(GameManager.Hero.GetHeroList()[UnityEngine.Random.Range(0, GameManager.Hero.HeroList.Count())]);
            foreach (Hero _hero in ResultTarget)
            {
                // 체력을 용병의 최대 체력으로 회복
                _hero.CurrentHP = _hero.MaxHP;
            }
            ResultMent = "랜덤으로 한 용병의 생명력을 완전히 회복시킵니다!";
            ResultType = "체력";
            ResultNum = "100 %";
            ResultSign = "+";
        }

        // 선택에 따른 결과를 띄워준다
        Result();

        ChoiceMode = 0;
    }

    private void CampFire(int mode)
    {
        // 선택지
        Debug.Log("CampFire " + mode + " 선택지의 기능을 수행합니다");
        Destroy(EventPanel);

        if (mode == 1)
        {
            ResultTarget = GameManager.Hero.GetHeroList();
            ResultMent = "용병들은 진실 게임을 진행합니다 ...";
            ResultType = "팀포인트";
            ResultNum = "2 point";
            ResultSign = "+";
        }
        else if (mode == 2)
        {
            ResultTarget = GameManager.Hero.GetHeroList();
            foreach (Hero _hero in ResultTarget)
            {
                // 체력을 용병의 최대 체력의 10%씩 회복.
                _hero.CurrentHP += _hero.MaxHP * (float)0.1;

                if (_hero.CurrentHP > _hero.MaxHP)
                {
                    _hero.CurrentHP = _hero.MaxHP;
                }
            }
            ResultMent = "용병들은 각자 휴식 시간을 즐깁니다 ...";
            ResultType = "체력";
            ResultNum = "10 %";
            ResultSign = "+";
        }

        // 선택에 따른 결과를 띄워준다
        Result();

        ChoiceMode = 0;
    }
    private void TelltheTruth(int mode)
    {
        // 선택지
        Debug.Log("TelltheTruth " + mode + " 선택지의 기능을 수행합니다");
        Destroy(EventPanel);

        if (mode == 1)
        {
            Hero _hero = GameManager.Hero.GetHeroList()[UnityEngine.Random.Range(0, GameManager.Hero.HeroList.Count())];
            _hero.MBTI = (GameManager.MbtiType)UnityEngine.Random.Range(0, 16);
            ResultTarget.Add(_hero);

            ResultMent = "한 용병에게 진실을 요구했습니다";
            ResultType = "MBTI";
            ResultNum = " ??? ";
            ResultSign = " ??? ";
        }
        else if (mode == 2)
        {
            ResultMent = "누군가는 거짓말을 하고 있을 것입니다\n...다음 기회에...";
            ResultType = " ??? ";
            ResultNum = " ??? ";
            ResultSign = " ??? ";
        }

        // 선택에 따른 결과를 띄워준다
        Result();

        ChoiceMode = 0;
    }
    private void Merchant(int mode)
    {
        // 선택지
        Debug.Log("Merchant " + mode + " 선택지의 기능을 수행합니다");
        Destroy(EventPanel);

        // 선택에 따른 결과를 띄워준다

        ChoiceMode = 0;
    }
    private void Villain(int mode)
    {
        // 선택지
        Debug.Log("Villain " + mode + " 선택지의 기능을 수행합니다");
        Destroy(EventPanel);

        // 선택에 따른 결과를 띄워준다
        ChoiceMode = 0;
    }

    private void QnA(int mode)
    {
        // 선택지
        Debug.Log("QnA " + mode + " 선택지의 기능을 수행합니다");
        Destroy(EventPanel);

        // 선택에 따른 결과를 띄워준다
        ChoiceMode = 0;
    }

    private void SetQnA()
    {
        //int num = UnityEngine.Random.Range(1, 6);
        int num = 1;

        EventPanel = Instantiate(Resources.Load("Prefabs/Event_QnA/MBTI_Q" + num) as GameObject, new Vector3(1200, 540, 0), Quaternion.identity);
        EventPanel.transform.SetParent(GameObject.FindWithTag("UI").transform);

        Name = EventPanel.transform.GetChild(0).gameObject;
        Ask = EventPanel.transform.GetChild(1).gameObject;
        Name.GetComponent<TextMeshProUGUI>().text = "Q n A";
        Ask.GetComponent<TextMeshProUGUI>().text = EventPanel.GetComponent<ChoiceController>().Ask;

        for (int i = 0; i < EventPanel.GetComponent<ChoiceController>().choiceNum; i++)
        {
            // EventPanel.transform.GetChild(2).GetChild(0).GetChild(0).gameObject;
            GameObject choice = EventPanel.transform.GetChild(2).GetChild(0).GetChild(i).gameObject;
            choice.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = choice.GetComponent<Choice>().text;
        }
    }

    void Update()
    {
        if (ChoiceMode > 0)
        {
            switch (Type)
            {
                case EventType.LifeLake:
                    {
                        LifeLake(ChoiceMode);
                        break;
                    }
                case EventType.CampFire:
                    {
                        CampFire(ChoiceMode);
                        break;
                    }
                case EventType.TelltheTruth:
                    {
                        TelltheTruth(ChoiceMode);
                        break;
                    }
                case EventType.Merchant:
                    {
                        Merchant(ChoiceMode);
                        break;
                    }
                case EventType.Villain:
                    {
                        Villain(ChoiceMode);
                        break;
                    }
                case EventType.QnA:
                    {
                        QnA(ChoiceMode);
                        break;
                    }
            }
        }
    }
}

