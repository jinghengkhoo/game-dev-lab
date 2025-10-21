
using UnityEngine;
using System;
[CreateAssetMenu(menuName = "PluggableSM/Decisions/Buff")]
public class BuffDecision : Decision
{
    public BuffTransformMap[] map;

    public override bool Decide(StateController controller)
    {
        BuffStateController m = (BuffStateController)controller;
        // we assume that the state is named (string matched) after one of possible values in MarioState
        // convert between current state name into MarioState enum value using custom class EnumExtension
        // you are free to modify this to your own use
        MarioBuffState toCompareState = EnumExtension.ParseEnum<MarioBuffState>(m.currentState.name);

        // loop through state transform and see if it matches the current transformation we are looking for
        for (int i = 0; i < map.Length; i++)
        {
            if (toCompareState == map[i].fromState && m.currentBuffType == map[i].buffCollected)
            {
                return true;
            }
        }

        return false;

    }
}

[System.Serializable]
public struct BuffTransformMap
{
    public MarioBuffState fromState;
    public BuffType buffCollected;
}
