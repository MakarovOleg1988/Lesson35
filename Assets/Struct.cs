using UnityEngine;
using static Ai.manager.Extensions;

namespace Ai.manager
{
    public struct GroupWeightAI
    {
        [Tooltip("Вес группы перемещения")]
        public float Move;
        [Tooltip("Вес группы атаки")]
        public float Attack;
        [Tooltip("Вес группы защиты")]
        public float Defence;
        [Tooltip("Вес группы использования способностей")]
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

