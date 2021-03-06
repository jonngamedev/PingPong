using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class RestartMenu : MonoBehaviour
{
    [Header("Add References")]
    [SerializeField] GameObject restartMenu;
    [SerializeField] Image displayImage;
    [SerializeField] Sprite winSprite;
    [SerializeField] Sprite gameOverSprite;
    [SerializeField] Button restart;
    [SerializeField] Button exitGame;

    private GameObject ball;

    private void Start()
    {
        SubscribeEvents();
        restartMenu.SetActive(false);
    }

    public void IsActivateMenu(bool isActive, bool isWin)
    {
        restartMenu.SetActive(isActive);

        if (isWin)
        {
            displayImage.sprite = winSprite;
        }
        else
        {
            displayImage.sprite = gameOverSprite;
        }
    }
   
    private void SubscribeEvents()
    {                      
        restart.onClick.AddListener(delegate
        {
            restartMenu.SetActive(false);
            GameManager.Instance.RestartGame();
        });

        exitGame.onClick.AddListener(delegate
        {
             Application.Quit();
        });
    }
}
