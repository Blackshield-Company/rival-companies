Scriptname RVC_TIF_Blackshield extends TopicInfo Hidden
{Rival Companies - dialogue fragment: blackshield.}

Int Property CompanyIndex Auto

Function Fragment_0(ObjectReference akSpeakerRef)
	(GetOwningQuest() as RVC_CampsScript).WinOver(CompanyIndex)
EndFunction
