﻿namespace Terminal;
internal abstract class BaseClass
{
    protected int _x = 100;
    protected int _y = 150;
    public abstract void AbstractMethod();
    public abstract int X { get; }
    public abstract int Y { get; }
}