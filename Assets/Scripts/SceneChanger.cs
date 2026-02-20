using UnityEngine;
using UnityEngine.SceneManagement; // Essential for scene switching

public class SceneChanger : MonoBehaviour
{
    // You can call this by Scene Name
    public void LoadNextScene(string MenuPage)
    {
        SceneManager.LoadScene(MenuPage);
    }

    // Or call this to just load the next scene in the Build Index
    public void LoadByIndex()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}