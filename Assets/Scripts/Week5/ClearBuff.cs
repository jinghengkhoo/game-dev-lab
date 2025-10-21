using UnityEngine;

[CreateAssetMenu(menuName = "PluggableSM/Actions/ClearBuff")]
public class ClearBuff : Action
{
    public override void Act(StateController controller)
    {
        BuffStateController m = (BuffStateController)controller;
        m.currentBuffType = BuffType.Default;
    }
}