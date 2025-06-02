using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    void Start()
    {
        // Load the next scene after 1 second
        Invoke("LoadNextScene", 1f);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
// This script is designed to automatically load the "SampleScene" after a 1-second delay when the game starts.
// It uses Unity's SceneManager to handle the scene loading.
// Attach this script to a GameObject in your initial scene (e.g., a splash screen or loading screen).
// Ensure that the "SampleScene" is correctly named and included in the Build Settings of your Unity project.
// This script is useful for creating a smooth transition from an introductory scene to the main gameplay or menu scene.
// The Start method is called when the script instance is being loaded, and it schedules the LoadNextScene method to be called after a 1-second delay using Invoke.