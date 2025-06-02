using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // Call this method when Reload Button is clicked
    public void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    // Call this method when Back Button is clicked
    public void GoBack()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "SelfPollinationScene")//|| currentScene == "CrossPollinationScene")
        {
            SceneManager.LoadScene("PollinationScene");
        }
        else if (currentScene == "CrossPollinationScene")
        {
            SceneManager.LoadScene("PollinationScene");
        }
        else if (currentScene == "PollinationScene")
        {
            SceneManager.LoadScene("SampleScene"); // Home scene
        }
        else if (currentScene == "photo" || currentScene == "plantcycle")
        {
            SceneManager.LoadScene("photosynthesisscene");
        }
        else if (currentScene == "photosynthesisscene")
        {
            SceneManager.LoadScene("SampleScene"); // Home scene
        }
        else if (currentScene == "UnknownScene")
        {
            SceneManager.LoadScene("SampleScene"); // Home scene
        }
        else if (currentScene == "SampleScene")
        {
            SceneManager.LoadScene("MainMenu"); // Main menu scene
        }
        else if (currentScene == "MainMenu")
        {
            SceneManager.LoadScene("StartScene"); // Start scene
        }
        else
        {
            Debug.LogWarning("No back action defined for this scene.");
        }
    }
}
// This script manages the button actions for reloading the current scene and navigating back to previous scenes.
// It uses Unity's SceneManager to load scenes based on the current active scene.
// The ReloadScene method reloads the current scene, while the GoBack method navigates to specific scenes based on the current scene.
// Ensure that the scenes are added to the build settings in Unity for this to work correctly.
// This script should be attached to a GameObject in your scene, and the methods can be linked to UI buttons in the Unity Editor.
// Make sure to test the scene transitions to ensure they work as expected.
// Note: The scene names used in this script should match the actual names of your scenes in Unity.
// This script is designed to be used in a Unity project where you have multiple scenes and need to manage navigation between them.
