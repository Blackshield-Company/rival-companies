# Rival Companies

Four rival mercenary companies have pitched camp across Skyrim. Raid a camp for its loot and the bounty on its leader, or win the company over with words, coin or a duel, and its veteran will follow you.

**Status: v0.1.0, early beta.** It passes every automated check in the build (Papyrus compile, plugin validation, byte-exact round trip, SEQ check, FOMOD schema) but has not been playtested in game yet. Expect rough edges and please report what you find. See [docs/TESTING.md](docs/TESTING.md).

- Game: Skyrim Special Edition / Anniversary Edition 1.6.x (1.5.97 also works). Runs on Windows, and on Linux through Proton.
- Requirements: just the base game. No SKSE, SkyUI, DLC or Creation Club content.
- Plugin: `RivalCompanies.esp`, ESL-flagged, with Skyrim.esm as its only master. **It edits no vanilla records** and adds no cells. The camps are new references created by a quest at existing map markers.
- Part of the [Blackshield Company](https://github.com/Blackshield-Company/blackshield-company) series. Blackshield Company is optional and detected at runtime. Prefix `RVC_`.

## Install

Use the FOMOD. It installs `RivalCompanies.esp`, the scripts, `SEQ/RivalCompanies.seq` and silent voice files for the dialogue. Papyrus sources are optional. Enable the plugin. Load order does not matter.

## The companies

| Company | Camp | Leader | Veteran |
|---|---|---|---|
| The Ashen Lances | Solitude Lighthouse (Haafingar) | Captain Hrodna Ash-Spear | Ulfgar the Lance |
| The Red Tithe | Stony Creek Cave (Eastmarch) | Varro Teneus | Sela Coin-Sworn |
| The Gallows Pikes | Brittleshin Pass (Falkreath) | Morvayn Gallows-Hand | Brother Kesh |
| The Thornwatch | Stendarr's Beacon (the Rift) | Ilvie Thorn-Captain | Dagny Thornblade |

Each camp has the leader, the veteran, two sellswords and a company chest. The company keeps to itself until you speak to the leader or draw steel.

## Raid or win over

- **Raid.** Tell the leader "Your company ends here", or hit any member of the camp. The whole company turns on you. The chest is no longer owned, so taking from it is not theft. The leader carries a bounty note.
- **Persuade.** With Speechcraft at or above `RVC_PersuadeSkill` (50), talk the leader round.
- **Tribute.** Pay `RVC_TributeGold` (500) gold.
- **Blackshield.** If Blackshield Company is installed and you hold a rank in it, the leader takes its word for you.
- **Duel.** Challenge the leader one on one. The leader cannot die during the duel, and the rest of the camp stays out. Bring the leader to bleedout to win. Run away and the duel is off.

A won-over company stays friendly and its veteran becomes a normal vanilla follower: ask them to follow you through the usual follower dialogue. A raided company cannot be won over afterwards.

No `RegisterForUpdate`, no polling. Everything runs on dialogue, hit, bleedout, combat and death events.

## How this differs from Company Quartermaster and Sellsword Roster

Company Quartermaster's camp mode is your own camp: you set it up, rest there and keep stashes. Rival Companies' camps belong to NPC companies. You never own, plant or rest at them, and there is no stash or contract table.

Sellsword Roster is hiring: wages, a roster and rotation. Rival Companies has no wages and no roster. Each company has exactly one veteran, unlocked once, for free, and only by winning that company over.

## Settings (console)

```
set RVC_PersuadeSkill to 50     ; Speechcraft needed to persuade a leader
set RVC_TributeGold to 500      ; gold for the tribute option
```

State per company: `RVC_StateAshen`, `RVC_StateTithe`, `RVC_StateGallows`, `RVC_StateThorn` (0 rival, 1 dueling, 2 won over, 3 raided). `RVC_BSCRank` is written by the script (0 = Blackshield Company not installed).

## Known issues (early beta)

- Not playtested in game.
- Camp layout is placed once by script when the camp first loads, offset from the map marker. On uneven ground an actor or the chest may sit a little high or low.
- There are no tents or other props yet, only people and a chest.
- If a leader dies by any means (including a stray dragon) the camp counts as raided.

## Building

`./build.sh` on Linux builds the release zip from this repo. Papyrus is compiled with the open-source [papyrus-compiler](https://github.com/russo-2025/papyrus-compiler), the plugin is generated from C# with [Mutagen](https://github.com/Mutagen-Modding/Mutagen), and everything is validated. You need .NET SDK 9+, python3, curl and, optionally, xmllint. See [tools/modkit/README.md](tools/modkit/README.md).

## Layout

```
src/plugin/RivalCompanies.Generator/  C# generator (factions, NPCs, quest, aliases, dialogue, notes)
src/plugin/formids.json               pinned FormIDs
src/papyrus/                          quest, alias and dialogue fragment scripts
fomod/                                FOMOD installer config
tools/modkit/                         shared build tooling
docs/                                 design notes, testing checklist, Nexus page
```

## Credits

- Built with [Mutagen](https://github.com/Mutagen-Modding/Mutagen) and [russo-2025/papyrus-compiler](https://github.com/russo-2025/papyrus-compiler).
- The mod ships no Bethesda assets. It references vanilla records by FormID.

## Support

Donations are optional. Nothing in the mod is gated on them.

- GitHub Sponsors: https://github.com/sponsors/synthalorian
- Ko-fi: https://ko-fi.com/synthalorian

## License

MIT (code and text in this repository). See [LICENSE](LICENSE).
