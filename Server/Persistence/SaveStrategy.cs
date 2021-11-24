using System;

namespace Server
{
    public abstract class SaveStrategy
    {
        public abstract string Name { get; }
        public static SaveStrategy Acquire()
        {
            if (Core.MultiProcessor)
            {
                int processorCount = Core.ProcessorCount;

                if (processorCount > 12)
                {
                    return new DynamicSaveStrategy();
                }
                if (processorCount > 32)
                {
                    return new ParallelSaveStrategy(processorCount);
                }
                else
                {
                    return new DualSaveStrategy();
                }
            }
            else
            {
                return new StandardSaveStrategy();
            }
        }

        public abstract void Save(SaveMetrics metrics, bool permitBackgroundWrite);

        public abstract void ProcessDecay();
    }
}
