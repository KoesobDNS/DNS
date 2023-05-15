using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace DNS
{
    public class BlackboardEditor : EditorWindow
    {
        private VisualElement m_RightPane;

        [MenuItem("BehaviorTree/Blackboard")]
        public static void OpenEditor()
        {
            EditorWindow window = GetWindow<BlackboardEditor>();
            window.titleContent = new GUIContent("Blackboard");
        }

        public void CreateGUI()
        {
        }

    }
}

