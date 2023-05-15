using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DNS
{
    public interface ILoader<Key, Value>
    {
        Dictionary<Key, Value> MakeDict();
    }
    public class DataManager
    {
        public Dictionary<int, Stat> StatDict { get; private set; } = new Dictionary<int, Stat>();
        
        public void Init()
        {
            StatDict = LoadJson<StatData, int, Stat>("StatData").MakeDict();
        }
        Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
        {
            // Resource ������ Data ����, �ش� Data ���� �־����
            TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data/{path}");
            return JsonUtility.FromJson<Loader>(textAsset.text);
        }
    }
}
