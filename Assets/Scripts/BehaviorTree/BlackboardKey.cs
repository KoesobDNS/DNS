using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DNS
{
    namespace BT
    {
        public class BlackboardKey : ScriptableObject
        {
            public string Name;
            public Define.KeyType Type;
            public object Value;

            public BlackboardKey Clone()
            {
                BlackboardKey blackboardKey = CreateInstance<BlackboardKey>();
                blackboardKey.SetValueAsDefault();

                return blackboardKey;
            }

            private void SetValueAsDefault()
            {
                switch(Type)
                {
                    case Define.KeyType.Bool:
                        Value = false;
                        break;
                    case Define.KeyType.Int:
                        Value = 0;
                        break;
                    case Define.KeyType.Float:
                        Value = 0.0f;
                        break;
                    case Define.KeyType.Vector2:
                        Value = Vector2.zero;
                        break;
                    case Define.KeyType.Vector3:
                        Value = Vector3.zero;
                        break;
                    case Define.KeyType.GameObject:
                        Value = null;
                        break;
                }
            }
        }
    }
}