using System.Collections.Generic;

namespace MitDisplay;

public enum MitigationSource
{
    PartyBuff,
    PersonalBuff,
    TargetDebuff,
}

public record MitigationEntry(uint StatusId, string Name, float PhysMit, float MagMit, MitigationSource Source);

public static class MitigationData
{
    public static readonly Dictionary<uint, MitigationEntry> Entries = new()
    {
        // ============================================================
        // Enemy debuffs (checked on current target)
        // ============================================================
        { 1193, new MitigationEntry(1193, "Reprisal", 0.10f, 0.10f, MitigationSource.TargetDebuff) },
        { 1195, new MitigationEntry(1195, "Feint", 0.10f, 0.05f, MitigationSource.TargetDebuff) },
        { 1203, new MitigationEntry(1203, "Addle", 0.05f, 0.10f, MitigationSource.TargetDebuff) },
        { 860, new MitigationEntry(860, "Dismantle", 0.10f, 0.10f, MitigationSource.TargetDebuff) },

        // ============================================================
        // Party buffs (checked on local player)
        // ============================================================

        // --- Ranged Physical DPS ---
        { 1934, new MitigationEntry(1934, "Troubadour", 0.15f, 0.15f, MitigationSource.PartyBuff) },
        { 1826, new MitigationEntry(1826, "Shield Samba", 0.15f, 0.15f, MitigationSource.PartyBuff) },
        { 1951, new MitigationEntry(1951, "Tactician", 0.15f, 0.15f, MitigationSource.PartyBuff) },

        // --- Tank party mitigations ---
        { 1839, new MitigationEntry(1839, "Heart of Light", 0.05f, 0.10f, MitigationSource.PartyBuff) },
        { 1894, new MitigationEntry(1894, "Dark Missionary", 0.05f, 0.10f, MitigationSource.PartyBuff) },
        { 1175, new MitigationEntry(1175, "Passage of Arms", 0.15f, 0.15f, MitigationSource.PartyBuff) },

        // --- Healer party mitigations ---
        { 2618, new MitigationEntry(2618, "Kerachole", 0.10f, 0.10f, MitigationSource.PartyBuff) },
        { 3003, new MitigationEntry(3003, "Holos", 0.10f, 0.10f, MitigationSource.PartyBuff) },
        { 299, new MitigationEntry(299, "Sacred Soil", 0.10f, 0.10f, MitigationSource.PartyBuff) },
        { 317, new MitigationEntry(317, "Fey Illumination", 0.00f, 0.05f, MitigationSource.PartyBuff) },
        { 1875, new MitigationEntry(1875, "Seraphic Illumination", 0.00f, 0.05f, MitigationSource.PartyBuff) },
        { 4402, new MitigationEntry(4402, "Seraphic Illumination", 0.00f, 0.05f, MitigationSource.PartyBuff) },
        { 2711, new MitigationEntry(2711, "Expedient", 0.10f, 0.10f, MitigationSource.PartyBuff) },
        { 1872, new MitigationEntry(1872, "Temperance", 0.10f, 0.10f, MitigationSource.PartyBuff) },
        { 849, new MitigationEntry(849, "Collective Unconscious", 0.10f, 0.10f, MitigationSource.PartyBuff) },
        { 1219, new MitigationEntry(1219, "Confession", 0.10f, 0.10f, MitigationSource.PartyBuff) },

        // --- Caster DPS ---
        { 2707, new MitigationEntry(2707, "Magick Barrier", 0.10f, 0.10f, MitigationSource.PartyBuff) },
        { 3240, new MitigationEntry(3240, "Magick Barrier", 0.10f, 0.10f, MitigationSource.PartyBuff) },

        // ============================================================
        // Personal mitigations (checked on local player)
        // ============================================================

        // --- Tank role ---
        { 1191, new MitigationEntry(1191, "Rampart", 0.20f, 0.20f, MitigationSource.PersonalBuff) },

        // --- PLD ---
        { 74, new MitigationEntry(74, "Sentinel", 0.30f, 0.30f, MitigationSource.PersonalBuff) },
        { 3829, new MitigationEntry(3829, "Guardian", 0.40f, 0.40f, MitigationSource.PersonalBuff) },
        { 1856, new MitigationEntry(1856, "Sheltron", 0.15f, 0.15f, MitigationSource.PersonalBuff) },
        { 728, new MitigationEntry(728, "Sheltron", 0.15f, 0.15f, MitigationSource.PersonalBuff) },
        { 2674, new MitigationEntry(2674, "Holy Sheltron", 0.15f, 0.15f, MitigationSource.PersonalBuff) },
        { 3026, new MitigationEntry(3026, "Holy Sheltron", 0.15f, 0.15f, MitigationSource.PersonalBuff) },
        { 2675, new MitigationEntry(2675, "Knight's Resolve", 0.15f, 0.15f, MitigationSource.PersonalBuff) },
        { 1174, new MitigationEntry(1174, "Intervention", 0.10f, 0.10f, MitigationSource.PersonalBuff) },
        { 2020, new MitigationEntry(2020, "Intervention", 0.10f, 0.10f, MitigationSource.PersonalBuff) },

        // --- WAR ---
        { 89, new MitigationEntry(89, "Vengeance", 0.30f, 0.30f, MitigationSource.PersonalBuff) },
        { 3832, new MitigationEntry(3832, "Damnation", 0.40f, 0.40f, MitigationSource.PersonalBuff) },
        { 735, new MitigationEntry(735, "Raw Intuition", 0.10f, 0.10f, MitigationSource.PersonalBuff) },
        { 2678, new MitigationEntry(2678, "Bloodwhetting", 0.10f, 0.10f, MitigationSource.PersonalBuff) },
        { 2679, new MitigationEntry(2679, "Stem the Flow", 0.10f, 0.10f, MitigationSource.PersonalBuff) },
        { 1858, new MitigationEntry(1858, "Nascent Glint", 0.10f, 0.10f, MitigationSource.PersonalBuff) },
        { 1857, new MitigationEntry(1857, "Nascent Flash", 0.10f, 0.10f, MitigationSource.PersonalBuff) },
        { 2061, new MitigationEntry(2061, "Nascent Flash", 0.10f, 0.10f, MitigationSource.PersonalBuff) },

        // --- DRK ---
        { 747, new MitigationEntry(747, "Shadow Wall", 0.30f, 0.30f, MitigationSource.PersonalBuff) },
        { 3835, new MitigationEntry(3835, "Shadowed Vigil", 0.40f, 0.40f, MitigationSource.PersonalBuff) },
        { 746, new MitigationEntry(746, "Dark Mind", 0.10f, 0.20f, MitigationSource.PersonalBuff) },
        { 2682, new MitigationEntry(2682, "Oblation", 0.10f, 0.10f, MitigationSource.PersonalBuff) },

        // --- GNB ---
        { 1834, new MitigationEntry(1834, "Nebula", 0.30f, 0.30f, MitigationSource.PersonalBuff) },
        { 3838, new MitigationEntry(3838, "Great Nebula", 0.40f, 0.40f, MitigationSource.PersonalBuff) },
        { 1832, new MitigationEntry(1832, "Camouflage", 0.10f, 0.10f, MitigationSource.PersonalBuff) },
        { 1840, new MitigationEntry(1840, "Heart of Stone", 0.15f, 0.15f, MitigationSource.PersonalBuff) },
        { 2683, new MitigationEntry(2683, "Heart of Corundum", 0.15f, 0.15f, MitigationSource.PersonalBuff) },
        { 2684, new MitigationEntry(2684, "Clarity of Corundum", 0.15f, 0.15f, MitigationSource.PersonalBuff) },

        // --- Healer ---
        { 2619, new MitigationEntry(2619, "Taurochole", 0.10f, 0.10f, MitigationSource.PersonalBuff) },
        { 2708, new MitigationEntry(2708, "Aquaveil", 0.15f, 0.15f, MitigationSource.PersonalBuff) },
        { 3086, new MitigationEntry(3086, "Aquaveil", 0.15f, 0.15f, MitigationSource.PersonalBuff) },
        { 2717, new MitigationEntry(2717, "Exaltation", 0.10f, 0.10f, MitigationSource.PersonalBuff) },
    };
}
