using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameFromMainMenu : MonoBehaviour
{
   static bool hasLoadedScene0 = false;

    void Start()
    {
        if (!hasLoadedScene0)
        {
            SceneManager.LoadScene(0); // Load Scene 0
            hasLoadedScene0 = true;
        }
    }
}
