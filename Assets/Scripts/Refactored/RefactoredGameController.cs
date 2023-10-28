public class RefactoredGameController : GameControllerBase
{
    private GameController gameController;

    public static RefactoredGameController Instance;

    public override PlayerControllerBase PlayerController => throw new System.NotImplementedException();

    void Awake()
    {
        Instance = this;
        gameController = new GameController();

    }


    public int GetScore()
    {

        return 0;
    }
}