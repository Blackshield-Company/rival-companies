Scriptname RVC_TIF_Duel extends TopicInfo Hidden
{Rival Companies - dialogue fragment: duel.}

Int Property CompanyIndex Auto

Function Fragment_0(ObjectReference akSpeakerRef)
	(GetOwningQuest() as RVC_CampsScript).StartDuel(CompanyIndex)
EndFunction
