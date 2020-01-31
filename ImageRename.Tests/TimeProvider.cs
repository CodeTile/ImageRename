using System;

namespace ImageRename.Tests
{

    public abstract class TimeProvider
    {
        private static TimeProvider current = DefaultTimeProvider.Instance;

        public static TimeProvider Current
        {
            get => TimeProvider.current;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                TimeProvider.current = value;
            }
        }

        public abstract DateTime Now { get; }
        public abstract DateTime Today { get; }

        public static void ResetToDefault()
        {
            TimeProvider.current = DefaultTimeProvider.Instance;
        }
    }

    public class DefaultTimeProvider : TimeProvider
    {
        private static readonly DefaultTimeProvider instance = new DefaultTimeProvider();

        public static DefaultTimeProvider Instance => DefaultTimeProvider.instance;

        public override DateTime Now => DateTime.Now;

        public override DateTime Today => DateTime.Today;

        private DefaultTimeProvider()
        {
        }
    }

}