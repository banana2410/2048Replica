using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public int sceneToLoad;
    public void PlayTheGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
