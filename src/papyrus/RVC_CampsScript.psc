Scriptname RVC_CampsScript extends Quest
{Rival Companies - camp quest: rival, duel, won, raided.}

GlobalVariable[] Property RVC_States Auto
Faction[] Property RVC_Factions Auto
ReferenceAlias[] Property Leaders Auto
ReferenceAlias[] Property Veterans Auto
ReferenceAlias[] Property Grunts1 Auto
ReferenceAlias[] Property Grunts2 Auto
ReferenceAlias[] Property Chests Auto
Faction Property PotentialFollowerFaction Auto
GlobalVariable Property RVC_TributeGold Auto
MiscObject Property Gold001 Auto
Message[] Property RVC_MsgWon Auto
Message[] Property RVC_MsgRaid Auto

Function PlayerHit(Int i)
	If RVC_States[i].GetValueInt() == 0
		StartRaid(i)
	EndIf
EndFunction

Function StartRaid(Int i)
	If RVC_States[i].GetValueInt() >= 2
		Return
	EndIf
	RVC_States[i].SetValueInt(3)
	RVC_Factions[i].SetPlayerEnemy(True)
	Fight(Leaders[i])
	Fight(Veterans[i])
	Fight(Grunts1[i])
	Fight(Grunts2[i])
	Chests[i].GetReference().SetFactionOwner(None)
	RVC_MsgRaid[i].Show()
EndFunction

Function Fight(ReferenceAlias a)
	Actor actorRef = None
	Actor player = Game.GetPlayer()
	If a
		actorRef = a.GetActorReference()
	EndIf
	If actorRef
		If !actorRef.IsDead()
			If player
				actorRef.StartCombat(player)
			EndIf
		EndIf
	EndIf
EndFunction

Function StartDuel(Int i)
	Actor leader = None
	Actor player = Game.GetPlayer()
	If RVC_States[i].GetValueInt() != 0
		Return
	EndIf
	RVC_States[i].SetValueInt(1)
	leader = Leaders[i].GetActorReference()
	If leader
		leader.GetActorBase().SetEssential(True)
		If player
			leader.StartCombat(player)
		EndIf
	EndIf
EndFunction

Function LeaderBleedout(Int i)
	Actor leader = None
	Actor player = Game.GetPlayer()
	If RVC_States[i].GetValueInt() == 1
		leader = Leaders[i].GetActorReference()
		If leader
			leader.StopCombat()
		EndIf
		If player
			player.StopCombatAlarm()
		EndIf
		If leader
			leader.GetActorBase().SetEssential(False)
		EndIf
		WinOver(i)
	EndIf
EndFunction

Function LeaderCombatEnded(Int i)
	Actor leader = None
	If RVC_States[i].GetValueInt() == 1
		leader = Leaders[i].GetActorReference()
		If leader
			leader.GetActorBase().SetEssential(False)
		EndIf
		RVC_States[i].SetValueInt(0)
	EndIf
EndFunction

Function LeaderDied(Int i)
	If RVC_States[i].GetValueInt() != 3
		RVC_States[i].SetValueInt(3)
		Chests[i].GetReference().SetFactionOwner(None)
	EndIf
EndFunction

Function PayTribute(Int i)
	Actor player = Game.GetPlayer()
	If player
		player.RemoveItem(Gold001, RVC_TributeGold.GetValueInt())
	EndIf
	WinOver(i)
EndFunction

Function WinOver(Int i)
	Int campState = RVC_States[i].GetValueInt()
	Actor veteran = None
	Actor player = Game.GetPlayer()
	If campState >= 2 && campState != 1
		Return
	EndIf
	RVC_States[i].SetValueInt(2)
	veteran = Veterans[i].GetActorReference()
	If veteran
		veteran.AddToFaction(PotentialFollowerFaction)
		If player
			veteran.SetRelationshipRank(player, 1)
		EndIf
	EndIf
	RVC_MsgWon[i].Show()
EndFunction
