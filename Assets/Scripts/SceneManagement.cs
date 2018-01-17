using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour {

    /*
    // Useless for this code, leave it 1st maybe for next time purpose
    #region Singleton

    public static SceneManagement instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Got Some Problem");
            return;
        }

        instance = this;

        DontDestroyOnLoad(this);
    }

    #endregion
    */

    public void SwitchScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
