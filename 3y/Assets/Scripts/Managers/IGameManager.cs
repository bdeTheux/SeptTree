using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameManager
{
    void Quit();
    void StartGame();

    void NextLevel();
    void EndGame();

    void MainMenu();
}
