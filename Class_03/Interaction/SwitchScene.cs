using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Interaction;

public class SwitchScene : MonoBehaviour
{
    
    public Button button;
    int whichScene = 1;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene(whichScene);
            whichScene = (whichScene == 1) ? 0 : 1;
        }
    }
}
