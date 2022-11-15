using UnityEngine;
using static Ai.manager.Extensions;

namespace Ai.manager
{
    public struct GroupWeightAI
    {
        [Tooltip("��� ������ �����������")]
        public float Move;
        [Tooltip("��� ������ �����")]
        public float Attack;
        [Tooltip("��� ������ ������")]
        public float Defence;
        [Tooltip("��� ������ ������������� ������������")]
        public float Ability;

        public GroupWeightAI(WeightEnum<ActionGroup> Weight)
        {
            Move = Weight(ActionGroup.move);
            Attack = Weight(ActionGroup.attack);
            Defence = Weight(ActionGroup.defence);
            Ability = Weight(ActionGroup.ability);
        }
    }
}

