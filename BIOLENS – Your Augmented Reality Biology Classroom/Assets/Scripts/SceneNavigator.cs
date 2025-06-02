using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneNavigator : MonoBehaviour
{
    public Button photosynthesisButton;
    public Button plantCycleButton;

    void Start()
    {
        if (photosynthesisButton != null)
            photosynthesisButton.onClick.AddListener(OpenPhotosynthesis);

        if (plantCycleButton != null)
            plantCycleButton.onClick.AddListener(OpenPlantCycle);
    }

    void OpenPhotosynthesis()
    {
        SceneManager.LoadScene("photo");
    }

    void OpenPlantCycle()
    {
        SceneManager.LoadScene("plantcycle");
    }
}
// This script manages the navigation to the photosynthesis and plant cycle scenes.
// It uses Unity's SceneManager to load the respective scenes when the buttons are clicked.
// Ensure that the scene names "photo" and "plantcycle" match the actual names of your scenes in Unity.
// Attach this script to a GameObject in your scene, and assign the buttons in the Unity Editor.
// The buttons should be linked to the public Button fields in this script.
// This script is designed to be used in a Unity project where you have multiple scenes related to plant biology and need to navigate between them.