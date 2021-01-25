public class Context : Singleton<Context>
{
    public bool gameStarted = false;
    
    private StoryNode start;
    
    public string[] bountyClues;
    public Choice[] scannerData;
}
