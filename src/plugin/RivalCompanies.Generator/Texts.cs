namespace Wave3Gen;

internal static class T
{
    internal static readonly string[] Faction = new[]
    {
        "The Ashen Lances",
        "The Red Tithe",
        "The Gallows Pikes",
        "The Thornwatch",
    };

    internal static readonly string[] Leader = new[]
    {
        "Captain Hrodna Ash-Spear",
        "Varro Teneus",
        "Morvayn Gallows-Hand",
        "Ilvie Thorn-Captain",
    };

    internal static readonly string[] LeaderShort = new[]
    {
        "Hrodna",
        "Varro",
        "Morvayn",
        "Ilvie",
    };

    internal static readonly string[] Veteran = new[]
    {
        "Ulfgar the Lance",
        "Sela Coin-Sworn",
        "Brother Kesh",
        "Dagny Thornblade",
    };

    internal static readonly string[] VeteranShort = new[]
    {
        "Ulfgar",
        "Sela",
        "Kesh",
        "Dagny",
    };

    internal static readonly string[] Grunt = new[]
    {
        "Ashen Lances Sellsword",
        "Red Tithe Sellsword",
        "Gallows Pikes Sellsword",
        "Thornwatch Sellsword",
    };

    internal const string GruntShort = "Sellsword";

    internal static readonly string[] BountyName = new[]
    {
        "Bounty: Ashen Lances",
        "Bounty: Red Tithe",
        "Bounty: Gallows Pikes",
        "Bounty: Thornwatch",
    };

    internal static readonly string[] Bounty = new[]
    {
        "By order of Castle Dour.<br><br>Captain Hrodna Ash-Spear and the Ashen Lances burned three wagons on the Dragon Bridge road and left the drivers for the crows. One thousand septims for the company broken. Bring her ash-charm to the steward at Castle Dour to claim the coin.",
        "Posted by the merchants of Windhelm.<br><br>Varro Teneus and the Red Tithe take coin or a throat from Eastmarch caravans. Eight hundred septims to see them ended. Show his seal at the Palace of the Kings to claim it.",
        "By writ of the Jarl of Falkreath.<br><br>Morvayn Gallows-Hand and the Gallows Pikes hang travelers at Brittle Shin Pass with no trial and no writ. Six hundred septims for the pikes thrown down. Bring his glove to the Jarl's longhouse to claim the coin.",
        "Posted at Mistveil Keep.<br><br>Ilvie Thorn-Captain and the Thornwatch cut pilgrims on the road to Stendarr's Beacon and strip their offerings. Seven hundred septims for the company broken. Bring her thorn-brooch to the keep to claim it.",
    };

    internal static readonly string[] MsgWon = new[]
    {
        "The Ashen Lances stand down.",
        "The Red Tithe accepts your terms.",
        "The Gallows Pikes lower their steel.",
        "The Thornwatch sheathes its blades.",
    };

    internal static readonly string[] MsgRaid = new[]
    {
        "The Ashen Lances turn on you.",
        "The Red Tithe draws steel.",
        "The Gallows Pikes come for you.",
        "The Thornwatch attacks.",
    };

    internal static readonly string[] MsgDead = new[]
    {
        "Hrodna Ash-Spear is dead. The bounty is on her body.",
        "Varro Teneus is dead. The bounty is on his body.",
        "Morvayn Gallows-Hand is dead. The bounty is on his body.",
        "Ilvie Thorn-Captain is dead. The bounty is on her body.",
    };

    internal const string PromptLead = "You lead this company?";
    internal const string PromptSeek = "I'm looking for the leader of this company.";
    internal const string PromptRaid = "Your company ends here.";
    internal const string PromptDuel = "I challenge you, one on one.";
    internal const string PromptBlackshield = "The Blackshield vouches for me.";

    internal static readonly string[] PromptPersuade = new[]
    {
        "Take your lances and leave. No one else has to die.",
        "End the tithe. Your people live if you do.",
        "Cut them down from the pikes, and go.",
        "Sheathe the thorns. Your company walks away whole.",
    };

    internal static readonly string[] PromptTribute = new[]
    {
        "Five hundred septims. Point those spears elsewhere.",
        "Five hundred. The tithe, paid. Now leave.",
        "Five hundred septims. Put the rope away.",
        "Five hundred for the road. Take it and go.",
    };

    internal static readonly string[] Intro = new[]
    {
        "Aye. Captain Hrodna Ash-Spear. These lances answer to me. Speak, or take the road back.",
        "Varro Teneus. The Red Tithe is mine. If this is about coin, pay it. If not, make it worth hearing.",
        "Morvayn. Gallows-Hand, if you need the whole of it. You found the leader. Talk.",
        "Ilvie. Captain of the Thornwatch. You're in our camp. Choose your next words.",
    };

    internal static readonly string[] LineRaid = new[]
    {
        "Then come and take them. Lances!",
        "Blood, then. Cut them down and strip the coin.",
        "Another neck for the pass. Pikes!",
        "On our own ground? Thornwatch — cut them down!",
    };

    internal static readonly string[] LineDuel = new[]
    {
        "Steel to steel. The rest of you, hold your spears.",
        "A duel. Stand clear. This one is mine.",
        "No rope, then. Just you and I.",
        "Alone it is. The watch will not step in.",
    };

    internal static readonly string[] LinePersuade = new[]
    {
        "You've the right of it. Lances — stand down.",
        "Sensible. I prefer a living company. The tithe is closed.",
        "Hmph. Live, then. The pikes come down.",
        "You speak like a captain. We sheathe our blades.",
    };

    internal static readonly string[] LineTribute = new[]
    {
        "Septims spend. We break camp. Don't follow.",
        "Counted. The Red Tithe withdraws.",
        "Coin before the drop. We're finished here.",
        "Paid. The road is open. Take it.",
    };

    internal static readonly string[] LineBlackshield = new[]
    {
        "The Blackshield. I won't cross that name. We stand down.",
        "Blackshield word is good. This camp is closed.",
        "If the Blackshield vouches, the rope stays coiled.",
        "Blackshield. Then you are no enemy of ours.",
    };

    internal static readonly string[] LineWon = new[]
    {
        "The lances stay down. Don't give me cause.",
        "Our business is settled. Keep it that way.",
        "You have your peace. Don't waste it.",
        "The watch keeps its word. See that you do.",
    };
}
