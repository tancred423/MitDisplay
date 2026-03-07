using System;
using System.Collections.Generic;
using System.Numerics;
using Dalamud.Bindings.ImGui;
using Dalamud.Game.ClientState.Objects.Types;
using Dalamud.Interface.Textures;
using Dalamud.Interface.Textures.TextureWraps;
using Dalamud.Interface.Utility;
using Dalamud.Interface.Windowing;
using Lumina.Excel.Sheets;

namespace MitDisplay.Windows;

public class MainWindow : Window, IDisposable
{
    private readonly List<MitigationEntry> activeEntries = [];

    private const uint PhysicalIconId = 60011;
    private const uint MagicalIconId = 60012;

    public MainWindow()
        : base("MitDisplay", ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse)
    {
        SizeConstraints = new WindowSizeConstraints
        {
            MinimumSize = new Vector2(220, 150),
            MaximumSize = new Vector2(400, 600),
        };
    }

    public void Dispose() { }

    public override void Draw()
    {
        var localPlayer = Plugin.ClientState.LocalPlayer;
        if (localPlayer == null)
        {
            ImGui.Text("Not logged in.");
            return;
        }

        activeEntries.Clear();

        foreach (var status in localPlayer.StatusList)
        {
            if (status.StatusId == 0)
                continue;
            if (MitigationData.Entries.TryGetValue(status.StatusId, out var entry) && entry.Source != MitigationSource.TargetDebuff)
                activeEntries.Add(entry);
        }

        var target = Plugin.TargetManager.Target as IBattleChara;
        if (target != null)
        {
            foreach (var status in target.StatusList)
            {
                if (status.StatusId == 0)
                    continue;
                if (MitigationData.Entries.TryGetValue(status.StatusId, out var entry) && entry.Source == MitigationSource.TargetDebuff)
                    activeEntries.Add(entry);
            }
        }

        var totalPhysRemaining = 1.0f;
        var totalMagRemaining = 1.0f;
        var groupPhysRemaining = 1.0f;
        var groupMagRemaining = 1.0f;

        foreach (var entry in activeEntries)
        {
            totalPhysRemaining *= 1.0f - entry.PhysMit;
            totalMagRemaining *= 1.0f - entry.MagMit;

            if (entry.Source != MitigationSource.PersonalBuff)
            {
                groupPhysRemaining *= 1.0f - entry.PhysMit;
                groupMagRemaining *= 1.0f - entry.MagMit;
            }
        }

        var totalPhys = (1.0f - totalPhysRemaining) * 100.0f;
        var totalMag = (1.0f - totalMagRemaining) * 100.0f;
        var groupPhys = (1.0f - groupPhysRemaining) * 100.0f;
        var groupMag = (1.0f - groupMagRemaining) * 100.0f;

        var labelIconSize = new Vector2(20, 20) * ImGuiHelpers.GlobalScale;
        var physIcon = Plugin.TextureProvider.GetFromGameIcon(new GameIconLookup(PhysicalIconId)).GetWrapOrDefault();
        var magIcon = Plugin.TextureProvider.GetFromGameIcon(new GameIconLookup(MagicalIconId)).GetWrapOrDefault();

        DrawMitigationRow(physIcon, labelIconSize, "Phys", totalPhys, magIcon, "Mag", totalMag);
        DrawMitigationRow(physIcon, labelIconSize, "Phys", groupPhys, magIcon, "Mag", groupMag, dimmed: true);

        if (activeEntries.Count == 0)
        {
            ImGui.Separator();
            ImGui.TextDisabled("No active mitigations");
            return;
        }

        ImGui.Separator();

        var statusSheet = Plugin.DataManager.GetExcelSheet<Status>();
        var iconSize = new Vector2(24, 32) * ImGuiHelpers.GlobalScale;

        foreach (var entry in activeEntries)
        {
            if (!statusSheet.TryGetRow(entry.StatusId, out var row))
                continue;

            var tex = Plugin.TextureProvider.GetFromGameIcon(new GameIconLookup(row.Icon)).GetWrapOrDefault();
            if (tex != null)
            {
                ImGui.Image(tex.Handle, iconSize);
                if (ImGui.IsItemHovered())
                    ImGui.SetTooltip($"{entry.Name}\nPhys: {entry.PhysMit * 100:F0}%  Mag: {entry.MagMit * 100:F0}%");
                ImGui.SameLine();
            }
        }

        ImGui.NewLine();
    }

    private static void DrawMitigationRow(
        IDalamudTextureWrap? physIcon, Vector2 iconSize, string physLabel, float physValue,
        IDalamudTextureWrap? magIcon, string magLabel, float magValue,
        bool dimmed = false)
    {
        if (dimmed)
            ImGui.PushStyleColor(ImGuiCol.Text, new Vector4(0.6f, 0.6f, 0.6f, 1.0f));

        if (physIcon != null)
        {
            ImGui.Image(physIcon.Handle, iconSize);
            ImGui.SameLine();
        }
        else
        {
            ImGui.Text(physLabel);
            ImGui.SameLine();
        }
        ImGui.Text($"{physValue:F2}%");

        ImGui.SameLine(140 * ImGuiHelpers.GlobalScale);

        if (magIcon != null)
        {
            ImGui.Image(magIcon.Handle, iconSize);
            ImGui.SameLine();
        }
        else
        {
            ImGui.Text(magLabel);
            ImGui.SameLine();
        }
        ImGui.Text($"{magValue:F2}%");

        if (dimmed)
            ImGui.PopStyleColor();
    }
}
