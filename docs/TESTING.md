# Testing checklist (v0.1.0, not yet playtested)

Start a new game or load a save with the plugin enabled. Open the console with `~`.

Markers: Ashen Lances `player.moveto 0C016D`, Red Tithe `player.moveto 080F13`, Gallows Pikes `player.moveto 082213`, Thornwatch `player.moveto 108A58`.

1. Move to a marker. The leader, veteran, two sellswords and a chest should appear nearby, not hostile.
2. Talk to the leader. "You lead this company?" opens the options. Persuade appears only with Speechcraft >= 50 (`player.setav speechcraft 60`), Tribute only with 500 gold (`player.additem f 500`), Blackshield only with Blackshield Company installed and a rank.
3. Raid: pick "Your company ends here." or hit a sellsword. All four should fight. `getglobalvalue RVC_StateAshen` = 3. Open the chest: no "steal" prompt. Kill the leader and loot the bounty note.
4. Duel (other camp): challenge, fight to bleedout. The leader must not die, combat ends, state = 2, "won over" notice.
5. Flee a duel: run until combat ends. State returns to 0. The leader can be killed normally afterwards.
6. After winning over: talk to the veteran, the vanilla "follow me" option should appear. Leader greeting changes.
7. Reset a camp for retesting: `set RVC_StateTithe to 0`.
8. Check `Papyrus.0.log` for RVC_ errors.
