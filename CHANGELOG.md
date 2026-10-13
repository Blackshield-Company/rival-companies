# Changelog

All notable changes to this project are documented here. Versions follow [Semantic Versioning](https://semver.org/).

## [0.1.0] - 2026-10-13

Early beta. First public release. It passes every automated check in the build (Papyrus compile, plugin validation, byte-exact round trip, SEQ check, FOMOD schema) but has not been playtested in game yet. Please report problems on the Nexus page or on GitHub.

### Added
- Four rival mercenary companies (The Ashen Lances, The Red Tithe, The Gallows Pikes, The Thornwatch), each with a camp spawned by quest aliases at an existing exterior map marker. No vanilla cells or records are edited.
- Raid: turn on a camp (dialogue, or any hit on a camp member) to fight the whole company. The chest becomes free to loot and the leader carries a bounty note.
- Win over: persuade the leader (Speechcraft), pay tribute, call in Blackshield Company standing (optional, detected at runtime), or beat the leader in a non-lethal duel.
- A won-over company's veteran becomes a recruitable vanilla follower (one per company, no wages).
- `SEQ/RivalCompanies.seq` for the Start Game Enabled quest with dialogue.
- FOMOD installer with optional Papyrus sources.
