public class Context : Singleton<Context>
{
    public bool gameStarted = false;
    
    private StoryNode start;
    
    public Dictionary<string, string> clues = new Dictionary<string, string>(){
        {"Topps", "clue about bounty"},
        {"Zella", "clue about bounty"},
        {"Anigun", "clue about bounty"},
    };


    public Dictionary<string, string> scannerData = new Dictionary<string, string>(){
        {"Topps", new Character {name="Glenn (Uno) Topps", description="Wears a ragged brown cloak which covers his face. All that portrudes from the hood is a lit cigarette and a red glow from what looks to be where one of his eyes might be.", occupation="N/A"}},
        {"Zella", new Character {name="Zella Stingwray", description="", occupation="CEO of IronNori - the largest mining company in the galaxy"}},
        {"Anigun", new Character {name="Anigun", description="", occupation="Bartender"}},
    };
}

public class Character{
    public string name { get; set; };
    public string description { get; set; };
    public string occupation { get; set; };
}
