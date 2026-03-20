using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{
    // Name of the scene you want to load
    public string sceneToLoad;

    // This function will be called when the button is pressed
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}