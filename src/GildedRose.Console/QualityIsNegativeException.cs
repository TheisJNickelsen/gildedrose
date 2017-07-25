using System;

namespace GildedRose.Console
{
    public class QualityIsNegativeException : Exception
    {
        public QualityIsNegativeException()
        {
        }

        public QualityIsNegativeException(string message)
            : base(message)
        {
        }

        public QualityIsNegativeException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}