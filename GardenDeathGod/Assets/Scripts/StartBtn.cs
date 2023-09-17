using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{
    public string levelName = "Final";

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelName);
    }
}
