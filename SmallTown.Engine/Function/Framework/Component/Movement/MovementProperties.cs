﻿namespace SmallTown.Function.Framework.Component.Movement
{
    public class MovementProperties
    {
        public bool CanWalk { get; internal set; }
        public bool CanFly { get; internal set; }
        public bool CanSwim { get; internal set; }

        public static readonly MovementProperties StillLife = new MovementProperties();
    }
}