using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace DNS
{
    namespace BT
    {
        public abstract class Node : ScriptableObject
        {
            public enum NodeState
            {
                Ready,
                InProgress,
                Succeeded,
                Failed,
                Aborted
            }

            public string GUID { get; set; }
            public NodeState State { get; set; } = NodeState.Ready;
            public Vector2 Position { get; set; }
            public Blackboard Blackboard { get; set; }

            public virtual Node Clone()
            {
                return CreateInstance<Node>();
            }

            public NodeState UpdateNode(BehaviourTreeComponent owner)
            {
                if(State == NodeState.Ready)
                {
                    OnStart();
                    State = NodeState.InProgress;
                }

                State = OnUpdate(owner);

                if(State == NodeState.Succeeded || State == NodeState.Failed)
                {
                    OnStop();
                    State = NodeState.Ready;
                }

                return State;
            }

            protected abstract void OnStart();
            protected abstract void OnStop();
            protected abstract NodeState OnUpdate(BehaviourTreeComponent owner);
            public virtual NodeState TickTask(BehaviourTreeComponent owner)
            {
                return NodeState.InProgress;
            }
        }
    }
}
