using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DNS
{
    namespace BT
    {
        [CreateAssetMenu(menuName = "AI/Blackboard")]
        public class Blackboard : ScriptableObject
        {
            public List<BlackboardKey> keys = new List<BlackboardKey>();

            public Blackboard Clone()
            {
                Blackboard blackboard = CreateInstance<Blackboard>();
                blackboard.keys.Clear();

                foreach (var key in keys)
                {
                    blackboard.keys.Add(key.Clone());
                }

                return blackboard;
            }
#if UNITY_EDITOR
            public bool AddKeyValue(string name, Define.KeyType type)
            {
                foreach (var obj in keys)
                {
                    if (obj.Name == name) return false;
                }

                BlackboardKey key = CreateInstance<BlackboardKey>();
                key.Name = name;
                key.Type = type;

                switch (type)
                {
                    case Define.KeyType.Bool:
                        key.Value = false;
                        break;
                    case Define.KeyType.Int:
                        key.Value = 0;
                        break;
                    case Define.KeyType.Float:
                        key.Value = 0.0f;
                        break;
                    case Define.KeyType.Vector2:
                        key.Value = Vector2.zero;
                        break;
                    case Define.KeyType.Vector3:
                        key.Value = Vector3.zero;
                        break;
                    case Define.KeyType.GameObject:
                        key.Value = new GameObject();
                        break;
                }

                keys.Add(key);

                if(!Application.isPlaying)
                {
                    AssetDatabase.AddObjectToAsset(key, this);
                }

                AssetDatabase.SaveAssets();

                return true;
            }

            public void DeleteKey(string name)
            {
                var key = FindKey(name);

                keys.Remove(key);
                DestroyImmediate(key, true);
                AssetDatabase.SaveAssets();
            }
#endif
            public bool GetValueAsBool(string name)
            {
                return GetValueAs<bool>(name);
            }

            public void SetValueAsBool(string name, bool value)
            {
                SetValueAs(name, value);
            }

            public int GetValueAsInt(string name)
            {
                return GetValueAs<int>(name);
            }

            public void SetValueAsInt(string name, int value)
            {
                SetValueAs(name, value);
            }

            public float GetValueAsFloat(string name)
            {
                return GetValueAs<float>(name);
            }

            public void SetValueAsFloat(string name, float value)
            {
                SetValueAs(name, value);
            }

            public Vector2 GetValueAsVector2(string name)
            {
                return GetValueAs<Vector2>(name);
            }

            public void SetValueAsVector2(string name, Vector2 value)
            {
                SetValueAs(name, value);
            }

            public Vector3 GetValueAsVector3(string name)
            {
                return GetValueAs<Vector3>(name);
            }

            public void SetValueAsVector3(string name, Vector3 value)
            {
                SetValueAs(name, value);
            }

            public GameObject GetValueAsGameObject(string name)
            {
                return GetValueAs<GameObject>(name);
            }

            public void SetValueAsGameObject(string name, GameObject value)
            {
                SetValueAs(name, value);
            }

            private T GetValueAs<T>(string name)
            {
                var key = FindKey(name);

                return key ? (T)key.Value : throw new System.Exception("Blackboard key does not exist.");
            }

            private void SetValueAs<T>(string name, T value)
            {
                var key = FindKey(name);

                _ = key ? key.Value = value : throw new System.Exception("Blackboard key does not exist.");
            }

            private BlackboardKey FindKey(string name)
            {
                BlackboardKey key = keys.Find(element => element.Name == name);

                return key;
            }
        }
    }
}