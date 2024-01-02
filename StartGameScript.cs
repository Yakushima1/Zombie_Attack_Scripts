using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour
{ 
    public void StartButton()
    {
        SceneManager.LoadScene("Demo");
        StartCoroutine(WaitForSceneLoad(SceneManager.GetSceneByName("Demo")));
    }
    
    public IEnumerator WaitForSceneLoad(Scene scene){
        while(!scene.isLoaded){
            yield return null;  
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Demo"));
        SceneManager.UnloadSceneAsync("StartScreen");
    }
}
