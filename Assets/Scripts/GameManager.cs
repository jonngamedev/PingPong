using System;
using UnityEngine;

[RequireComponent(typeof(InGameMenuControl))]
[RequireComponent(typeof(RestartMenu))]
[RequireComponent(typeof(StatusBar))]
public class GameManager : MonoBehaviour
{
    // Singelton Definition
    private static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();

                if (instance == null)
                {
                    GameObject gameObject = new GameObject();
                    gameObject.name = "GameManager";
                    instance = gameObject.AddComponent<GameManager>();

                    DontDestroyOnLoad(gameObject);
                }

            }
            return instance;
        }

    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    [SerializeField] private int playerMaxLife = 3;
    [Range(0.1f, 1f)]
    [SerializeField] float timeScale = 0.5f;
    [SerializeField] private BrickControl brickControl;
    [SerializeField] private GameObject gameBall;

    private InGameMenuControl inGameMenuControl;
    private RestartMenu restartMenu;
    private StatusBar statusBar;    

    private int playerLife;        


    private void Start()
    {
        Initializations();
        SubscribeEvents();
        statusBar.AddLifePrefabs(playerMaxLife);
    }  

    public void ActivateBall()
    {
        if (gameBall != null && gameBall.activeSelf == false)
        {
            gameBall.SetActive(true);
        }
    }

    public void RestartGame()
    {
        playerLife = playerMaxLife;
        statusBar.RefillHealthBar();

        brickControl.ReActivateAllBricks();
        ActivateBall();
    }

    private void OnBallDisable(GameObject ball)
    {
        gameBall = ball;
        playerLife -= 1;
        statusBar.TakeLife();

        if (playerLife > 0)
        {
            inGameMenuControl.IsActivateMenu(true);            
        }
        else
        {
            restartMenu.IsActivateMenu(true, false);
        }
    }


    private void GameWinMenu()
    {
        gameBall.SetActive(false);
        restartMenu.IsActivateMenu(true, true);
    }


    public void ApplyPowerUp(Utilities.PowerUpTypes powerUpType)
    {
        switch (powerUpType)
        {
            case Utilities.PowerUpTypes.Health:
                if (playerLife < playerMaxLife)
                {
                    playerLife += 1;
                    statusBar.AddLife();
                }                            
                break;
            case Utilities.PowerUpTypes.DoubleHit:
                gameBall.GetComponent<BallControl>().DoubleDamage();
                break;
            default:
                break;
        }
    }

    private void SubscribeEvents()
    {
        BallDestroyer.OnBallDisable += OnBallDisable;
        BrickControl.OnAllBrickDestroy += GameWinMenu;
    }

    private void Initializations()
    {
        playerLife = playerMaxLife;

        inGameMenuControl = GetComponent<InGameMenuControl>();
        statusBar = GetComponent<StatusBar>();
        restartMenu = GetComponent<RestartMenu>();
        

        Time.timeScale = timeScale;
    }
}
