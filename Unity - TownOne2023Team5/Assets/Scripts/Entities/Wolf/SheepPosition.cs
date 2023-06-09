using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class SheepPosition : ActionNode
{
    protected override void OnStart() 
    {
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate() 
    {
        AI_FOV agentSight = context.agent.GetComponent<AI_FOV>();

        //Debug.Log("[BT] Sheep being checked " + agentSight.visibleTargets.Count);

        if (agentSight != null && agentSight.closestTarget != null)
        {
            blackboard.moveToPosition = agentSight.closestTarget.position;
            //Debug.Log("[BT] Sheep visible " + blackboard.moveToPosition);
            blackboard.wandering = false;
            return State.Success;
        }

        blackboard.wandering = true;
        return State.Failure;
    }
}
