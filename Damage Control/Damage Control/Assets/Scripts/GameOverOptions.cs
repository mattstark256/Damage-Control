using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverOptions : MonoBehaviour {

	public void Restart()
    {
        LevelManager.instance.RestartGame();
    }

    public void Quit()
    {
        LevelManager.instance.Quit();
    }
}
