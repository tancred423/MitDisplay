> **Archived**
>
> Moved to https://gitlab.com/tancred/mit-display

> ⚠️ **Personal Use Plugin!**
> 
> You are allowed to use this plugin. However, I created this for personal usage. So, I do not guarantee updates for future game versions. I will update it if I need it and that's it. If you are a developer, feel free to copy and maintain this yourself.
> 
> If you find a bug or want to provide an update, you can also open an issue. I am open for suggestions and help. The only rule set I have is to keep this simple. I don't want to overcomplicate this.

# MitDisplay

A Dalamud plugin that calculates and displays real-time mitigation from party buffs, personal buffs and enemy debuffs in FFXIV.

<img width="240" height="231" alt="2026_03_07_8K6eMjxaJw" src="https://github.com/user-attachments/assets/3e7ddfd9-fbc1-4147-8a21-9c776da5c25a" />

It computes total damage reduction using multiplicative stacking and displays four numbers:

| | Physical | Magical |
|---|---|---|
| **Personal Mit** | Total physical mit on you from all sources | Total magical mit on you from all sources |
| **Party Mit** | Party wide physical mit | Parse wide magical mit |

Status icons of all active mitigations are shown below the numbers with tooltips.

## Usage

1. Add custom repo URL: `https://raw.githubusercontent.com/tancred423/MitDisplay/master/repo.json`
2. Then install "MitDisplay"
3. Open window with `/mit`

