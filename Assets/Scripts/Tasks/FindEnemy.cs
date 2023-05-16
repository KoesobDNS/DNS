using Bonsai.Core;
using UnityEngine;

namespace DNS
{
    public class FindEnemy : Task
    {
        public string TargetKey = "Target";
        public override void OnStart()
        {
            if(!Blackboard.Contains(TargetKey))
            {
                GameObject target = null;
                Blackboard.Set(TargetKey, target);
            }
        }
        public override Status Run()
        {
            throw new System.NotImplementedException();
        }
    }
}
