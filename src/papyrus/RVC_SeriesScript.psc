Scriptname RVC_SeriesScript extends ReferenceAlias
{Soft integration with the rest of the series, on the player alias.
Plugins are looked up at runtime (vanilla Papyrus, no SKSE); when one is missing the call returns None.}

GlobalVariable Property RVC_BSCRank Auto
{0 = Blackshield Company not installed, otherwise BSC_Rank + 1}

Event OnInit()
	Refresh()
EndEvent

Event OnPlayerLoadGame()
	Refresh()
EndEvent

Function Refresh()
	GlobalVariable bscRank = Game.GetFormFromFile(0x805, "BlackshieldCompany.esp") as GlobalVariable ; soft: BSC_Rank
	If bscRank
		RVC_BSCRank.SetValue(bscRank.GetValue() + 1.0)
	Else
		RVC_BSCRank.SetValue(0.0)
	EndIf
EndFunction
