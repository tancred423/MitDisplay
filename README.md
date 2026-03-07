# MitDisplay

A Dalamud plugin that calculates and displays real-time mitigation from party buffs and enemy debuffs in FFXIV.

## What It Does

MitDisplay reads status effects from two sources every frame:

- **Your buffs** -- party-wide mitigations (e.g., Troubadour, Shield Samba) and personal cooldowns (e.g., Rampart, Sentinel)
- **Your target's debuffs** -- enemy debuffs applied by your party (e.g., Reprisal, Feint, Addle)

It computes total damage reduction using multiplicative stacking and displays four numbers:

| | Physical | Magical |
|---|---|---|
| **Total** | All mitigation on you + target debuffs | All mitigation on you + target debuffs |
| **Group** | Party buffs + target debuffs only | Party buffs + target debuffs only |

The "Group" row excludes personal mitigations like Rampart, so you can see what the party provides for everyone.

Physical and magical columns are indicated by in-game damage type icons. Status icons of all active mitigations are shown below the numbers with tooltips.

## Usage

1. Use `/mit` in chat to toggle the overlay on or off.
2. Target a boss or enemy to include their debuffs (Reprisal, Feint, Addle, Dismantle) in the calculation.
3. Untarget or switch targets and the numbers update instantly -- only what is present at that moment is shown.

## Building

### Prerequisites

- XIVLauncher, FINAL FANTASY XIV, and Dalamud installed and run at least once.
- XIVLauncher at default directories, or `DALAMUD_HOME` set to Dalamud's dev directory.
- .NET 10 SDK installed.

### Steps

1. Open `MitDisplay.sln` in Visual Studio 2022+ or JetBrains Rider.
2. Build the solution (`Debug` or `Release`).
3. Output DLL is at `MitDisplay/bin/x64/Debug/MitDisplay.dll`.

### Activating In-Game

1. `/xlsettings` -> Experimental -> add the full path to the DLL under Dev Plugin Locations.
2. `/xlplugins` -> Dev Tools -> Installed Dev Plugins -> enable MitDisplay.
3. `/mit` to open the overlay.
