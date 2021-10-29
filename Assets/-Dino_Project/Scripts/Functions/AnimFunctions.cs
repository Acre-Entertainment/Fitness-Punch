using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimFunctions : MonoBehaviour
{
    public string sceneToBeLoaded;
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToBeLoaded);
    }

}
