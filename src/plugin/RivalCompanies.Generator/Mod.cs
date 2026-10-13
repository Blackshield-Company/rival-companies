using Modkit.Mutagen;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Skyrim;
using static Wave3Gen.Kit;
using static Wave3Gen.Vanilla;

namespace Wave3Gen;

internal static class ModInfo
{
    public const string PluginName = "RivalCompanies.esp";
    public const string Description = "Rival Companies: four mercenary camps. Raid them, duel the captain, or buy the company off.";

    private readonly record struct Company(
        string Key,
        string Faction,
        string Leader,
        string LeaderShort,
        string Veteran,
        string VeteranShort,
        string Grunt,
        FormKey Marker,
        FormKey LeaderTraits,
        string LeaderVoice,
        FormKey VeteranTraits,
        string VeteranVoice);

    public static void Build(Kit k)
    {
        var companies = new[]
        {
            new Company("Ashen", T.Faction[0], T.Leader[0], T.LeaderShort[0], T.Veteran[0], T.VeteranShort[0], T.Grunt[0],
                SolitudeLighthouseMapmarkerRef, EncGuardSonsF01FemaleNord, "FemaleNord", EncGuardSonsM05MaleGuard, "MaleGuard"),
            new Company("Tithe", T.Faction[1], T.Leader[1], T.LeaderShort[1], T.Veteran[1], T.VeteranShort[1], T.Grunt[1],
                StonyCreekCaveMapMarker, EncGuardImperialM02MaleNordCommander, "MaleNordCommander", EncGuardSonsF03FemaleNord, "FemaleNord"),
            new Company("Gallows", T.Faction[2], T.Leader[2], T.LeaderShort[2], T.Veteran[2], T.VeteranShort[2], T.Grunt[2],
                BrittleShinPassSouthMapMarker, EncGuardImperialM05MaleGuard, "MaleGuard", EncGuardImperialM07MaleGuard, "MaleGuard"),
            new Company("Thorn", T.Faction[3], T.Leader[3], T.LeaderShort[3], T.Veteran[3], T.VeteranShort[3], T.Grunt[3],
                StendarrsBeaconMapMarkerREF, EncGuardSonsF02FemaleNord, "FemaleNord", EncGuardSonsF02FemaleNord, "FemaleNord"),
        };

        var gBsc = k.Global("RVC_BSCRank", 0);
        var gPersuade = k.Global("RVC_PersuadeSkill", 50);
        var gTribute = k.Global("RVC_TributeGold", 500);

        var q = k.Id("RVC_Camps");
        var camps = k.Quest(q, "RVC_Camps", "Rival Companies", true, Quest.TypeEnum.None, 40);
        camps.Aliases.Add(Player(0));

        var states = new FormKey[companies.Length];
        var factions = new FormKey[companies.Length];
        var leaders = new int[companies.Length];
        var veterans = new int[companies.Length];
        var grunts1 = new int[companies.Length];
        var grunts2 = new int[companies.Length];
        var chests = new int[companies.Length];
        var msgWon = new FormKey[companies.Length];
        var msgRaid = new FormKey[companies.Length];

        for (int i = 0; i < companies.Length; i++)
        {
            var c = companies[i];
            int marker = 1 + i * 7;
            int leaderA = marker + 1, veteranA = marker + 2, grunt1A = marker + 3, grunt2A = marker + 4, chestA = marker + 5, bountyA = marker + 6;
            leaders[i] = leaderA;
            veterans[i] = veteranA;
            grunts1[i] = grunt1A;
            grunts2[i] = grunt2A;
            chests[i] = chestA;

            var fac = k.Faction($"RVC_{c.Key}Faction", c.Faction);
            factions[i] = fac.FormKey;
            states[i] = k.Global($"RVC_State{c.Key}", 0);
            var bounty = k.Note($"RVC_{c.Key}Bounty", T.BountyName[i], T.Bounty[i]);
            msgWon[i] = Notify(k, $"RVC_{c.Key}MsgWon", T.MsgWon[i]);
            msgRaid[i] = Notify(k, $"RVC_{c.Key}MsgRaid", T.MsgRaid[i]);

            var leader = k.Speaker($"RVC_{c.Key}Leader", c.Leader, c.LeaderShort, c.LeaderTraits, ArmorSteelNoHelmetOutfit, fac.FormKey, 10, 40, false);
            var veteran = k.Speaker($"RVC_{c.Key}Veteran", c.Veteran, c.VeteranShort, c.VeteranTraits, ArmorSteelNoHelmetOutfit, fac.FormKey, 8, 30, false);
            HelpsNobody(leader);
            HelpsNobody(veteran);

            var grunt = k.Enemy($"RVC_{c.Key}Sellsword", c.Grunt, T.GruntShort, LCharBanditMeleeAny, NordRace);
            grunt.Configuration.TemplateFlags &= ~(NpcConfiguration.TemplateFlag.Factions | NpcConfiguration.TemplateFlag.AIData);
            HelpsNobody(grunt);
            grunt.Factions.Add(new RankPlacement { Faction = L<IFactionGetter>(fac.FormKey), Rank = 0 });

            camps.Aliases.Add(Forced(marker, $"{c.Key}Marker", c.Marker));
            camps.Aliases.Add(Created(leaderA, $"{c.Key}Leader", leader.FormKey, marker, false, Level.Medium, QuestAlias.Flag.StoresText));
            camps.Aliases.Add(Created(veteranA, $"{c.Key}Veteran", veteran.FormKey, marker, false, Level.Medium));
            camps.Aliases.Add(Created(grunt1A, $"{c.Key}Grunt1", grunt.FormKey, marker, false, Level.Medium));
            camps.Aliases.Add(Created(grunt2A, $"{c.Key}Grunt2", grunt.FormKey, marker, false, Level.Medium));
            camps.Aliases.Add(Created(chestA, $"{c.Key}Chest", TreasBanditChestBoss, marker, false, Level.Easy));
            camps.Aliases.Add(Created(bountyA, $"{c.Key}Bounty", bounty.FormKey, leaderA, true, Level.Easy));

            var say = new[] { (c.LeaderVoice, c.Leader) };
            var leadEdid = $"RVC_{c.Key}Lead";
            var tLead = k.TopTopic(leadEdid, q, T.PromptLead, say);
            var branch = tLead.Branch.FormKey;
            var tRaid = k.Topic($"RVC_{c.Key}Raid", q, branch, T.PromptRaid, say);
            var tDuel = k.Topic($"RVC_{c.Key}Duel", q, branch, T.PromptDuel, say);
            var tPers = k.Topic($"RVC_{c.Key}Pers", q, branch, T.PromptPersuade[i], say);
            var tPay = k.Topic($"RVC_{c.Key}Pay", q, branch, T.PromptTribute[i], say);
            var tBsc = k.Topic($"RVC_{c.Key}BSC", q, branch, T.PromptBlackshield, say);
            ScriptProperty[] Idx() => new ScriptProperty[] { Vmad.Int("CompanyIndex", i) };
            Condition[] Gate() => new[] { Cond.IsID(leader.FormKey), GlobalIs(states[i], CompareOperator.EqualTo, 0) };
            k.Info(tLead, leadEdid + "0", new[] { T.Intro[i] }, Gate(), links: new[] { tRaid, tDuel, tPers, tPay, tBsc });
            k.Info(tLead, leadEdid + "2", new[] { T.LineWon[i] }, new[] { Cond.IsID(leader.FormKey), GlobalIs(states[i], CompareOperator.EqualTo, 2) });
            k.Info(tRaid, $"RVC_{c.Key}RaidI", new[] { T.LineRaid[i] }, Gate(), goodbye: true, fragment: "RVC_TIF_Raid", fragmentProps: Idx());
            k.Info(tDuel, $"RVC_{c.Key}DuelI", new[] { T.LineDuel[i] }, Gate(), goodbye: true, fragment: "RVC_TIF_Duel", fragmentProps: Idx());
            k.Info(tPers, $"RVC_{c.Key}PersI", new[] { T.LinePersuade[i] }, Gate().Append(Speech()).ToArray(), goodbye: true, fragment: "RVC_TIF_Persuade", fragmentProps: Idx());
            k.Info(tPay, $"RVC_{c.Key}PayI", new[] { T.LineTribute[i] }, Gate().Append(PlayerGoldAtLeast(gTribute)).ToArray(), goodbye: true, fragment: "RVC_TIF_Tribute", fragmentProps: Idx());
            k.Info(tBsc, $"RVC_{c.Key}BscI", new[] { T.LineBlackshield[i] }, Gate().Append(GlobalIs(gBsc, CompareOperator.GreaterThanOrEqualTo, 2)).ToArray(), goodbye: true, fragment: "RVC_TIF_Blackshield", fragmentProps: Idx());

            Condition Speech() => Cond.MakeVsGlobal(new GetActorValueConditionData { ActorValue = ActorValue.Speech }, gPersuade, CompareOperator.GreaterThanOrEqualTo).OnRef(PlayerRef);
        }

        camps.NextAliasID = (uint)camps.Aliases.Count;
        var adapter = Vmad.QuestAdapter(Vmad.Script("RVC_CampsScript",
                Vmad.ObjList("RVC_States", states),
                Vmad.ObjList("RVC_Factions", factions),
                Vmad.AliasList("Leaders", q, leaders),
                Vmad.AliasList("Veterans", q, veterans),
                Vmad.AliasList("Grunts1", q, grunts1),
                Vmad.AliasList("Grunts2", q, grunts2),
                Vmad.AliasList("Chests", q, chests),
                Vmad.Obj("PotentialFollowerFaction", PotentialFollowerFaction),
                Vmad.Obj("RVC_TributeGold", gTribute),
                Vmad.Obj("Gold001", Gold001),
                Vmad.ObjList("RVC_MsgWon", msgWon),
                Vmad.ObjList("RVC_MsgRaid", msgRaid)))
            .WithAliasScripts(q, 0, Vmad.Script("RVC_SeriesScript", Vmad.Obj("RVC_BSCRank", gBsc)));
        for (int i = 0; i < companies.Length; i++)
        {
            int marker = 1 + i * 7;
            adapter = adapter
                .WithAliasScripts(q, marker + 1, Actor(q, i, marker, true, 0, 0))
                .WithAliasScripts(q, marker + 2, Actor(q, i, marker, false, 220, 120))
                .WithAliasScripts(q, marker + 3, Actor(q, i, marker, false, -220, 160))
                .WithAliasScripts(q, marker + 4, Actor(q, i, marker, false, 160, -220))
                .WithAliasScripts(q, marker + 5, Vmad.Script("RVC_CampObjectScript",
                    Vmad.Float("OffsetX", 0), Vmad.Float("OffsetY", 320),
                    Vmad.Alias("Marker", q, marker), Vmad.Obj("OwnerFaction", factions[i])));
        }
        camps.VirtualMachineAdapter = adapter;
    }

    private static ScriptEntry Actor(FormKey q, int i, int marker, bool isLeader, float x, float y) => Vmad.Script("RVC_CampActorScript",
        Vmad.Int("CompanyIndex", i), Vmad.Bool("IsLeader", isLeader),
        Vmad.Float("OffsetX", x), Vmad.Float("OffsetY", y), Vmad.Alias("Marker", q, marker));

    private static void HelpsNobody(Npc n) => n.AIData = new AIData
    {
        Aggression = Aggression.Unaggressive,
        Confidence = Confidence.Brave,
        Assistance = Assistance.HelpsNobody,
        EnergyLevel = 50,
    };

    private static FormKey Notify(Kit k, string edid, string text)
    {
        var m = new Message(k.Id(edid), R) { EditorID = edid, Description = text, INAM = new byte[4] };
        k.Mod.Messages.Add(m);
        return m.FormKey;
    }
}
