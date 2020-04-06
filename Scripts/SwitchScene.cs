using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchScene : MonoBehaviour
{
    int which = 0;
    public Text text;
    public void Switch(){
        which++;
        if(which>(SceneManager.sceneCountInBuildSettings-1)){
            which = 0;
        }
        SceneManager.LoadScene(which);
    }

	private void Update()
	{
        print(SceneManager.sceneCountInBuildSettings);

        text.text = SceneManager.GetActiveScene().name;

	}
}
