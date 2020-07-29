using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public string nextSceneName; 
    // Start is called before the first frame update
    public void DoSwitchScene()
    {
        SceneManager.LoadScene(nextSceneName, LoadSceneMode.Single);
    }
}
