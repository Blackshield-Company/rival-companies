# Rival Companies: design

## Goal
Give the world a few named mercenary outfits that are not the player's. Each one is a choice: take it apart, or bring it round.

## Records
Per company: a named faction, a unique leader, a unique veteran, one sellsword base used twice, a vanilla boss chest (Created alias), a bounty note carried by the leader, two notification messages and a state global. Shared: quest `RVC_Camps` (Start Game Enabled, SEQ), globals `RVC_BSCRank`, `RVC_PersuadeSkill`, `RVC_TributeGold`.

## No vanilla edits
The quest has a Forced alias on each vanilla persistent map marker and creates every camp reference at that alias. `RVC_CampActorScript` / `RVC_CampObjectScript` move each reference once, on its first load, to a fixed offset from the marker. Nothing is placed in a vanilla cell record.

## States
`RVC_State<Co>`: 0 rival, 1 dueling, 2 won over, 3 raided.
- 0 -> 3: raid dialogue or any player hit on a camp actor (`OnHit`). Faction set enemy of the player, all living camp actors start combat, chest ownership cleared.
- 0 -> 1: duel dialogue. Leader base set essential, leader starts combat.
- 1 -> 2: leader `OnEnterBleedout`. Combat stopped, essential cleared.
- 1 -> 0: leader `OnCombatStateChanged` to 0 without bleedout (player fled). Essential cleared.
- 0 -> 2: persuade, tribute or Blackshield dialogue. The veteran joins `PotentialFollowerFaction` with relationship rank 1, so vanilla follower dialogue takes over.
- any (not 3) -> 3: leader `OnDeath`.

## Blackshield hook
`RVC_SeriesScript` on the player alias reads `Game.GetFormFromFile(0x805, "BlackshieldCompany.esp") as GlobalVariable` (BSC_Rank) on init and on every load, guarded with `If`. `RVC_BSCRank` = BSC_Rank + 1, or 0 when the plugin is missing. The Blackshield dialogue option requires `RVC_BSCRank >= 2`.

## How this differs from Company Quartermaster and Sellsword Roster
Company Quartermaster's camp mode is the player's own camp, with stashes and rest. These camps belong to NPC companies; the player never owns or uses them. Sellsword Roster hires for wages from a rotating roster. Here there are no wages and no roster: each company has one veteran, unlocked once and free, only by winning the company over.

## Rules kept
No SKSE. No update loops. No vanilla overrides. Skyrim.esm only.
