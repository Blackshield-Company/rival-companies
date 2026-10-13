Scriptname RVC_TIF_Raid extends TopicInfo Hidden
{Rival Companies - dialogue fragment: raid.}

Int Property CompanyIndex Auto

Function Fragment_0(ObjectReference akSpeakerRef)
	(GetOwningQuest() as RVC_CampsScript).StartRaid(CompanyIndex)
EndFunction
