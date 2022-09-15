using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager
{
    public void Init()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        Debug.Log("SceneLoaded Event Init");
    }

    public void Clear()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        Debug.Log("SceneLoaded Evetn Clear");
    }

    private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.name)
        {
            case "00.StartScene":
                Debug.Log("This is Start Scene");
                GameManager.Stage.HideStageMap();
                break;

            case "01.StageSelectScene":
                Debug.Log("This is Stage Select Scene");
                // ���� ����ٰ� Stage Show �Լ� �־�θ� �ɵ�
                GameManager.Stage.ShowStageMap();
                break;

            case "02.BattleSelectScene":
                Debug.Log("This is Battle Scene");

                // GameManager.Stage.Test_SetBattleStage();
                GameManager.Stage.HideStageMap();

                GameObject obj = new GameObject("BattleManager");
                GameManager.Battle = obj.AddComponent<BattleSceneManager>();
                obj.AddComponent<Path.PathManager>();
                Hero h1 = (Hero)GameManager.Data.ObjectCodex[0];
                Hero h2 = (Hero)GameManager.Data.ObjectCodex[1];
                Hero h3 = (Hero)GameManager.Data.ObjectCodex[2];
                Hero h4 = (Hero)GameManager.Data.ObjectCodex[3];
                Hero h5 = (Hero)GameManager.Data.ObjectCodex[4];
                Hero h6 = (Hero)GameManager.Data.ObjectCodex[5];
                Hero h7 = (Hero)GameManager.Data.ObjectCodex[6];
                Hero h8 = (Hero)GameManager.Data.ObjectCodex[7];
                Hero h9 = (Hero)GameManager.Data.ObjectCodex[8];
                Hero h10 = (Hero)GameManager.Data.ObjectCodex[9];
                Hero h11 = (Hero)GameManager.Data.ObjectCodex[10];
                Hero h12 = (Hero)GameManager.Data.ObjectCodex[11];
                Hero h13 = (Hero)GameManager.Data.ObjectCodex[12];
                Hero h14 = (Hero)GameManager.Data.ObjectCodex[13];
                Hero h15 = (Hero)GameManager.Data.ObjectCodex[14];
                Hero h16 = (Hero)GameManager.Data.ObjectCodex[15];
                Hero h17 = (Hero)GameManager.Data.ObjectCodex[16];
                Hero h18 = (Hero)GameManager.Data.ObjectCodex[17];
                Hero h19 = (Hero)GameManager.Data.ObjectCodex[18];
                Hero h20 = (Hero)GameManager.Data.ObjectCodex[19];
                List<Hero> hlist = new List<Hero>();
                hlist.Add(h1);
                hlist.Add(h2);
                hlist.Add(h3);
                hlist.Add(h4);
                hlist.Add(h5);
                hlist.Add(h6);
                hlist.Add(h7);
                hlist.Add(h8);
                hlist.Add(h9);
                hlist.Add(h10);
                hlist.Add(h11);
                hlist.Add(h12);
                hlist.Add(h13);
                hlist.Add(h14);
                hlist.Add(h15);
                hlist.Add(h16);
                hlist.Add(h17);
                hlist.Add(h18);
                hlist.Add(h19);
                hlist.Add(h20);
                List<Enemy> elist = GameManager.Stage.GetEnemies();
                GameManager.Battle.Init(hlist, elist, GameManager.MapType.Boss);
                break;

            case "03.TownScene":
                Debug.Log("This is Town Scene");
                GameManager.Stage.HideStageMap();
                break;

            case "04.EvevntScene":
                Debug.Log("This is Event Scene");
                GameManager.Stage.HideStageMap();
                break;

            default:
                break;
        }
    }

    public void ToInitGameScene()
    {
        SceneManager.LoadScene("00.StartScene");
    }

    public void ToStageSelectScene()
    {
        SceneManager.LoadScene("01.StageSelectScene");
    }

    public void ToBattleScene()
    {
        SceneManager.LoadScene("02.BattleSelectScene");
    }

    public void ToTownScene()
    {
        SceneManager.LoadScene("03.TownScene");
    }

    public void ToEventScene()
    {
        SceneManager.LoadScene("04.EventScene");
    }
}
