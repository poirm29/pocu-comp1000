using System.Data;

namespace Lab7
{
    public class Frame
    {
        public EFeatureFlags Features { get; private set; }
        public uint ID { get; set; }
        public string Name { get; set; }
        public byte FeatureBoard { get; private set; }
        public Frame(uint id, string name)
        {
            Features = EFeatureFlags.Default;
            ID = id;
            Name = name;
            FeatureBoard = 0;
        }

        public void ToggleFeatures(EFeatureFlags features)
        {
            Features ^= features;
        }

        public void TurnOnFeatures(EFeatureFlags features)
        {
            Features |= features;
        }

        public void TurnOffFeatures(EFeatureFlags features)
        {
            features = ~features;
            Features &= features;
        }
    }
}
