Scriptname RVC_CampActorScript extends ReferenceAlias
{Rival Companies - camp actor: one-time placement and combat hooks.}

Int Property CompanyIndex Auto
Bool Property IsLeader Auto
Float Property OffsetX Auto
Float Property OffsetY Auto
ReferenceAlias Property Marker Auto

Bool placed = False

Event OnLoad()
	If !placed
		placed = True
		GetReference().MoveTo(Marker.GetReference(), OffsetX, OffsetY, 0.0)
	EndIf
EndEvent

Event OnHit(ObjectReference akAggressor, Form akSource, Projectile akProjectile, Bool abPowerAttack, Bool abSneakAttack, Bool abBashAttack, Bool abHitBlocked)
	If akAggressor == Game.GetPlayer()
		camps().PlayerHit(CompanyIndex)
	EndIf
EndEvent

Event OnEnterBleedout()
	If IsLeader
		camps().LeaderBleedout(CompanyIndex)
	EndIf
EndEvent

Event OnCombatStateChanged(Actor akTarget, Int aeCombatState)
	If IsLeader && aeCombatState == 0
		camps().LeaderCombatEnded(CompanyIndex)
	EndIf
EndEvent

Event OnDeath(Actor akKiller)
	If IsLeader
		camps().LeaderDied(CompanyIndex)
	EndIf
EndEvent

RVC_CampsScript Function camps()
	Return GetOwningQuest() as RVC_CampsScript
EndFunction
