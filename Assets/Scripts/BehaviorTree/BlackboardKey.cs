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
            public Define.KeyType KeyType;
            public object Value;
        }
    }
}