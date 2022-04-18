using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : SingletonBehaviour<GameManager>, IGameManager
{
//[SerializeField] private string startScene;
    [SerializeField] private UnityEvent onEndGame;
    [SerializeField] private LevelManager _levelManager;
    //[SerializeField] private CinemachineBrain cam;
    public LevelManager levelManager => _levelManager;
    
    [SerializeField] private PlayerManager _playerManager;
    public PlayerManager playerManager => _playerManager;
    
    [SerializeField] private CameraManager _cameraManager;
    public CameraManager cameraManager => _cameraManager;
    
    [SerializeField] private MenuManager _menuManager;
    public MenuManager menuManager => _menuManager;
    
    //SceneManager----------
    public void StartGame()
    {
        //Already a scene?
        StartCoroutine(levelManager.NextScene());
        menuManager.NextScene(levelManager.GetCurrentScene());
    }
    
    public void Quit()
    {
        menuManager.Quit();
    }
    
    public void EndGame()
    {
        menuManager.ShowVictory();
        onEndGame?.Invoke();
    }
    public void NextLevel()
    {
        //check if player is in life
        StartCoroutine(levelManager.NextScene());
    }

    public void MainMenu()
    {
        if (playerManager.getPlayer())
        {
            playerManager.DestroyPlayer();
        }
        if(cameraManager.GetCamera())
            cameraManager.DestroyCamera();


//        Destroy(gameObject);
        levelManager.MainMenu();
        menuManager.MenuScene();
    }
    //PlayerManager-------------

    public void AskAPlayer()
    {
        if (playerManager.getPlayer() == null)
        {
            playerManager.PlayerCreation();
        }
        else
        {
            playerManager.ReAffectPlayer();
        }
    }
    //CameraManager-----
    
    //I Could Refactor AskAPlayer && AskACamera
    public void AskACamera()
    {
        if (cameraManager.GetCamera() == null)
            cameraManager.CameraCreation();
        else
        {
            cameraManager.ReAffectCamera();
        }
    }

    public void MenuInGame()
    {
        //Display the main menu in game
        menuManager.MenuInGame();
    }

    public void DieMenu()
    {
        Debug.Log("ceci est le die menu");
        menuManager.DieMenu();
    }
    
    //Resume
    public void Resume()
    {
        menuManager.Resume();
    }
    //Restart
    public void Restart()
    {
        menuManager.Restart();
        levelManager.Reset();
        StartGame();
    }
}
