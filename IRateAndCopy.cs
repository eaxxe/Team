﻿namespace Team
{
    interface IRateAndCopy
    {
        double Rating { get; }
        object DeepCopy();
    }
}
