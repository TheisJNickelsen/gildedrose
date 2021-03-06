﻿using System;

namespace GildedRose.Console.Exceptions
{
    public class MaxQualityReachedException : Exception
    {
        public MaxQualityReachedException()
        {
        }

        public MaxQualityReachedException(string message)
            : base(message)
        {
        }

        public MaxQualityReachedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}