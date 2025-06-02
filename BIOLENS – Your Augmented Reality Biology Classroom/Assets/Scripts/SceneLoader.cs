using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class SceneLoader : MonoBehaviour
{
    public ARSession arSession;

    public void LoadScene(string sceneName)
    {
        if (arSession != null)
        {
            arSession.enabled = false; // ✅ Stop ARSession before switching scenes
        }

        SceneManager.LoadScene(sceneName);
    }
}
// This script is designed to load a specified scene in Unity.
// It includes a reference to an ARSession, which is disabled before the scene change to ensure a smooth transition.
// The LoadScene method takes a string parameter for the scene name and uses Unity's SceneManager to load that scene.
// Ensure that the scene names passed to LoadScene match the actual names of your scenes in Unity.
// This script should be attached to a GameObject in your scene, and the LoadScene method can be called from UI buttons or other scripts.
// The ARSession reference allows for proper management of AR features, ensuring that the AR session is stopped before changing scenes. 
// This is particularly useful in AR applications where scene transitions might disrupt the AR experience.
// Make sure to test the scene transitions to ensure they work as expected, especially in AR contexts where the session state is important.