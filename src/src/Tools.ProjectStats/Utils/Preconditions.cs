namespace Tools.ProjectStats.Utils
{
    using System;

    public static class Preconditions
    {
        public static void CheckNotNull(object obj, string argumentName)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        public static void CheckCondition(bool expression, string message)
        {
            if (!expression)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
