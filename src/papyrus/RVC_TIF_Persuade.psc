Scriptname RVC_TIF_Persuade extends TopicInfo Hidden
{Rival Companies - dialogue fragment: persuade.}

Int Property CompanyIndex Auto

Function Fragment_0(ObjectReference akSpeakerRef)
	(GetOwningQuest() as RVC_CampsScript).WinOver(CompanyIndex)
EndFunction
