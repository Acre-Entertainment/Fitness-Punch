using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimFunctions : MonoBehaviour
{

    public void LoadScene(string WhichLevel)
    {
        SceneManager.LoadScene(WhichLevel);
    }

}
