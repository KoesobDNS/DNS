using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DNS
{
    public class Define
    {
        public enum Scene
        {
            Unknown,
            Title,
            Lobby,
            Town,
            Map,
            Battle,
            End,
        }

        public enum Sound
        {
            BGM,
            Effect,
            MaxCount,
        }

        public enum UIEvent
        {
            Click,
            Drag,
        }

        public enum MouseEvent
        {
            Press,
            Click,
        }
    }
}