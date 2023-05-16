using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DNS
{
    namespace BT
    {
        public class BlackboardKey : ScriptableObject
        {
            public enum KeyType
            {
                Bool,
                Int,
                Float,
                Vector2,
                Vector3,
                GameObject,
            }

            public string Name { get; set; }
            public KeyType Type { get; set; }
            public object Value { get; set; }

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
                    case KeyType.Bool:
                        Value = false;
                        break;
                    case KeyType.Int:
                        Value = 0;
                        break;
                    case KeyType.Float:
                        Value = 0.0f;
                        break;
                    case KeyType.Vector2:
                        Value = Vector2.zero;
                        break;
                    case KeyType.Vector3:
                        Value = Vector3.zero;
                        break;
                    case KeyType.GameObject:
                        Value = null;
                        break;
                }
            }
        }
    }
}