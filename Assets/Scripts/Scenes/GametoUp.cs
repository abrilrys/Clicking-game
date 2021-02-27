using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.SceneManagement;

public class GametoUp : MonoBehaviour
{
    Scene scene;

    public void changescene()
    {
        scene = SceneManager.GetActiveScene();
        if (scene.name=="Main Game")
            SceneManager.LoadScene("Upgrades");
        else if (scene.name== "Upgrades")
            SceneManager.LoadScene("Main Game");
    }
}
