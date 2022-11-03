using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventEI : CustomEvent
{
    [SerializeField] private Hero preHero;
    [SerializeField] private Hero postHero;
    [SerializeField] private Enemy preEnemy;
    [SerializeField] private Enemy postEnemy;

    protected override bool Condition(LogInfo _logInfo)
    {
        // 일단 subject가 Hero여야 실행
        if (_logInfo.Subjective is Hero && _logInfo.Objective is Enemy)
        {
            postHero = (Hero)_logInfo.Subjective;
            postEnemy = (Enemy)_logInfo.Objective;

            if(preHero != null && preEnemy != null)
            {
                if(preHero.Name != postHero.Name && object.ReferenceEquals(preEnemy, postEnemy))
                {
                    Debug.Log("서로 다른 히어로 같은 적 공격");
                    return true;
                }
            }
        }

        return false;
    }

    protected override void Apply()
    {
        switch(preHero.MBTI)
        {
            case GameManager.MbtiType.INFP:
                GameManager.Relation.SetChangeRelationship(preHero, postHero, -10);
                break;
            case GameManager.MbtiType.ENFP:
                GameManager.Relation.SetChangeRelationship(preHero, postHero, 10);
                break;
            case GameManager.MbtiType.INFJ:
                GameManager.Relation.SetChangeRelationship(preHero, postHero, -10);
                break;
            case GameManager.MbtiType.ENFJ:
                GameManager.Relation.SetChangeRelationship(preHero, postHero, 10);
                break;
            case GameManager.MbtiType.INTJ:
                GameManager.Relation.SetChangeRelationship(preHero, postHero, -10);
                break;
            case GameManager.MbtiType.ENTJ:
                GameManager.Relation.SetChangeRelationship(preHero, postHero, 10);
                break;
            case GameManager.MbtiType.INTP:
                GameManager.Relation.SetChangeRelationship(preHero, postHero, -10);
                break;
            case GameManager.MbtiType.ENTP:
                GameManager.Relation.SetChangeRelationship(preHero, postHero, 10);
                break;
            case GameManager.MbtiType.ISFP:
                GameManager.Relation.SetChangeRelationship(preHero, postHero, -10);
                break;
            case GameManager.MbtiType.ESFP:
                GameManager.Relation.SetChangeRelationship(preHero, postHero, 10);
                break;
            case GameManager.MbtiType.ISTP:
                GameManager.Relation.SetChangeRelationship(preHero, postHero, -10);
                break;
            case GameManager.MbtiType.ESTP:
                GameManager.Relation.SetChangeRelationship(preHero, postHero, 10);
                break;
            case GameManager.MbtiType.ISFJ:
                GameManager.Relation.SetChangeRelationship(preHero, postHero, -10);
                break;
            case GameManager.MbtiType.ESFJ:
                GameManager.Relation.SetChangeRelationship(preHero, postHero, 10);
                break;
            case GameManager.MbtiType.ISTJ:
                GameManager.Relation.SetChangeRelationship(preHero, postHero, -10);
                break;
            case GameManager.MbtiType.ESTJ:
                GameManager.Relation.SetChangeRelationship(preHero, postHero, 10);
                break;
        }

        switch (postHero.MBTI)
        {
            case GameManager.MbtiType.INFP:
                GameManager.Relation.SetChangeRelationship(postHero, preHero, -10);
                break;
            case GameManager.MbtiType.ENFP:
                GameManager.Relation.SetChangeRelationship(postHero, preHero, 10);
                break;
            case GameManager.MbtiType.INFJ:
                GameManager.Relation.SetChangeRelationship(postHero, preHero, -10);
                break;
            case GameManager.MbtiType.ENFJ:
                GameManager.Relation.SetChangeRelationship(postHero, preHero, 10);
                break;
            case GameManager.MbtiType.INTJ:
                GameManager.Relation.SetChangeRelationship(postHero, preHero, -10);
                break;
            case GameManager.MbtiType.ENTJ:
                GameManager.Relation.SetChangeRelationship(postHero, preHero, 10);
                break;
            case GameManager.MbtiType.INTP:
                GameManager.Relation.SetChangeRelationship(postHero, preHero, -10);
                break;
            case GameManager.MbtiType.ENTP:
                GameManager.Relation.SetChangeRelationship(postHero, preHero, 10);
                break;
            case GameManager.MbtiType.ISFP:
                GameManager.Relation.SetChangeRelationship(postHero, preHero, -10);
                break;
            case GameManager.MbtiType.ESFP:
                GameManager.Relation.SetChangeRelationship(postHero, preHero, 10);
                break;
            case GameManager.MbtiType.ISTP:
                GameManager.Relation.SetChangeRelationship(postHero, preHero, -10);
                break;
            case GameManager.MbtiType.ESTP:
                GameManager.Relation.SetChangeRelationship(postHero, preHero, 10);
                break;
            case GameManager.MbtiType.ISFJ:
                GameManager.Relation.SetChangeRelationship(postHero, preHero, -10);
                break;
            case GameManager.MbtiType.ESFJ:
                GameManager.Relation.SetChangeRelationship(postHero, preHero, 10);
                break;
            case GameManager.MbtiType.ISTJ:
                GameManager.Relation.SetChangeRelationship(postHero, preHero, -10);
                break;
            case GameManager.MbtiType.ESTJ:
                GameManager.Relation.SetChangeRelationship(postHero, preHero, 10);
                break;
        }
    }
}
