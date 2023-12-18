using Dalamud.Configuration;
using Dalamud.Plugin;
using System;

namespace SamplePlugin
{
    [Serializable]
    public class Configuration : IPluginConfiguration
    {
        public int Version { get; set; } = 0;

        public bool SomePropertyToBeSavedAndWithADefault { get; set; } = true;
        //stats
        public int Smashing { get; set; } = 0;
        public int Shooting { get; set; } = 0;
        public int Dodging { get; set; } = 0;
        public int Precision { get; set; } = 0;
        public int Entophy { get; set; } = 0;
        public int Harmony { get; set; } = 0;
        public int Moxie { get; set; } = 0;
        // Tech Tree Variables
        // Tech Tree Counter
        public int TalentsSelected { get; set; } = 0;
        // BEGIN EVASION
        public bool FleetFootedValue { get; set; } = false;
            public bool EvasionValue { get; set; } = false;
                public bool UntouchableValue { get; set; } = false;
                public bool ReactionTimeValue { get; set; } = false;
        // END EVASION
        // BEGIN STRENGTH
        public bool FitnessValue { get; set; } = false;
            public bool StrengthTrainingValue { get; set; } = false;
                public bool EnduringValue { get; set; } = false;
                public bool FortitudeValue { get; set; } = false;
        public bool MeleeCombatTrainingValue { get; set; } = false;
        public bool RangedCombatTrainingValue { get; set; } = false;
        public bool ArmoredWarfareValue { get; set; } = false;
        // END STRENGTH


        // the below exist just to make saving less cumbersome
        [NonSerialized]
        private DalamudPluginInterface? PluginInterface;

        public void Initialize(DalamudPluginInterface pluginInterface)
        {
            this.PluginInterface = pluginInterface;
        }

        public void Save()
        {
            this.PluginInterface!.SavePluginConfig(this);
        }
    }
}
