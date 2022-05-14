using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class RestartMenu : MonoBehaviour
{
    [Header("Add References")]
    [SerializeField] GameObject restartMenu;
    [SerializeField] Button restart;
    [SerializeField] Button exitGame;

    private GameObject ball;

    private void Start()
    {
        SubscribeEvents();
        restartMenu.SetActive(false);
    }

    public void IsActivateMenu(bool isActive)
    {
        restartMenu.SetActive(isActive);
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
            if (Application.isEditor)
            {
                EditorApplication.ExitPlaymode();
            }
            else
            {
                Application.Quit();
            }           
        });
    }
}
