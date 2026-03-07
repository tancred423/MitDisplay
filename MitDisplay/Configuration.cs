using System;
using Dalamud.Configuration;

namespace MitDisplay;

[Serializable]
public class Configuration : IPluginConfiguration
{
    public int Version { get; set; } = 0;

    public bool ShowPartyMit { get; set; } = true;
    public bool ShowPersonalMit { get; set; } = true;
    public bool ShowPersonalMitIcons { get; set; } = true;

    public void Save()
    {
        Plugin.PluginInterface.SavePluginConfig(this);
    }
}
