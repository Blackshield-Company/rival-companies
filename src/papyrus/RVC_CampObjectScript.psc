Scriptname RVC_CampObjectScript extends ReferenceAlias
{Rival Companies - camp chest: one-time placement.}

Float Property OffsetX Auto
Float Property OffsetY Auto
ReferenceAlias Property Marker Auto
Faction Property OwnerFaction Auto

Bool placed = False

Event OnLoad()
	If !placed
		placed = True
		GetReference().MoveTo(Marker.GetReference(), OffsetX, OffsetY, 0.0)
		If OwnerFaction
			GetReference().SetFactionOwner(OwnerFaction)
		EndIf
	EndIf
EndEvent
