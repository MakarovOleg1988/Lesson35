using System;

namespace Ai.manager
{
    [Flags]
    public enum ActionGroup: byte
    {
        move,
        attack,
        defence,
        ability
    }
}
