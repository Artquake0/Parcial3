using System.Windows.Input;
using UnityEngine;
using UnityEngine.EventSystems;

public class RefactoredPlayerController : PlayerControllerBase
{
    private PlayerController playerController;
    public GameObject Shot;
    public float MaxShotDistance;
    public int MaxShots;
    public int ShotsRemaining;

    public static RefactoredPlayerController Instance;

    public delegate void GameOverDelegate();
    public delegate void ShotDelegate ();
    public event GameOverDelegate GameOver;
    public event ShotDelegate OnShot;

    void Awake()
    {
        Instance = this;
        playerController = new PlayerController();
    }

    void Update()
    {
        if (ShotsRemaining <= 0) return;

        if (Input.GetMouseButtonDown(0))
        {
            OnShot?.Invoke();
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, MaxShotDistance))
            {
                RefactoredGameController.Instance.ProcessShot(hit.point);
            }

            ShotsRemaining--;

            if (ShotsRemaining <= 0)
            {
                GameOver?.Invoke();
            }
        }
    }

    protected override void ProcessShot(Vector3 point)
    {
        throw new System.NotImplementedException();
    }
}