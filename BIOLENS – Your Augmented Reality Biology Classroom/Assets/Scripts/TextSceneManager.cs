using UnityEngine;
using UnityEngine.SceneManagement;

public class TextSceneManager : MonoBehaviour
{
    public void OpenTextScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        switch (currentScene)
        {
            case "photo":
                SceneManager.LoadScene("PhotoText");
                break;

            case "plantcycle":
                SceneManager.LoadScene("PlantText");
                break;

            case "SelfPollinationScene":
                SceneManager.LoadScene("SelfText");
                break;

            case "CrossPollinationScene":
                SceneManager.LoadScene("CrossText");
                break;

            default:
                Debug.LogWarning("No text scene defined for this scene.");
                break;
        }
    }
}
