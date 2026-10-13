Scriptname RVC_TIF_Tribute extends TopicInfo Hidden
{Rival Companies - dialogue fragment: tribute.}

Int Property CompanyIndex Auto

Function Fragment_0(ObjectReference akSpeakerRef)
	(GetOwningQuest() as RVC_CampsScript).PayTribute(CompanyIndex)
EndFunction
