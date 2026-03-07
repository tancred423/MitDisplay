using System;
using System.Numerics;
using Dalamud.Bindings.ImGui;
using Dalamud.Interface.Windowing;

namespace MitDisplay.Windows;

public class ConfigWindow : Window, IDisposable
{
    private readonly Configuration configuration;

    public ConfigWindow(Plugin plugin) : base("MitDisplay Settings###MitDisplayConfig")
    {
        Flags = ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoScrollbar |
                ImGuiWindowFlags.NoScrollWithMouse;

        Size = new Vector2(280, 130);
        SizeCondition = ImGuiCond.Always;

        configuration = plugin.Configuration;
    }

    public void Dispose() { }

    public override void Draw()
    {
        var showPartyMit = configuration.ShowPartyMit;
        if (ImGui.Checkbox("Show Party Mit", ref showPartyMit))
        {
            configuration.ShowPartyMit = showPartyMit;
            configuration.Save();
        }

        var showPersonalMit = configuration.ShowPersonalMit;
        if (ImGui.Checkbox("Show Personal Mit", ref showPersonalMit))
        {
            configuration.ShowPersonalMit = showPersonalMit;
            configuration.Save();
        }

        ImGui.Indent();
        ImGui.BeginDisabled(!showPersonalMit);
        var showPersonalMitIcons = configuration.ShowPersonalMitIcons;
        if (ImGui.Checkbox("Show Personal Mitigation Icons", ref showPersonalMitIcons))
        {
            configuration.ShowPersonalMitIcons = showPersonalMitIcons;
            configuration.Save();
        }
        ImGui.EndDisabled();
        ImGui.Unindent();
    }
}
