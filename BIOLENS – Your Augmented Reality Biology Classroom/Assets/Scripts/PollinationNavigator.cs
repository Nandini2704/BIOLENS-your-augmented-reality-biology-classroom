using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PollinationNavigator : MonoBehaviour
{
    public Button selfPollinationButton;
    public Button crossPollinationButton;

    void Start()
    {
        if (selfPollinationButton != null)
            selfPollinationButton.onClick.AddListener(OpenSelfPollination);

        if (crossPollinationButton != null)
            crossPollinationButton.onClick.AddListener(OpenCrossPollination);
    }

    void OpenSelfPollination()
    {
        SceneManager.LoadScene("SelfPollinationScene");
    }

    void OpenCrossPollination()
    {
        SceneManager.LoadScene("CrossPollinationScene");
    }
}
// This script manages the navigation to self-pollination and cross-pollination scenes.
// It uses Unity's SceneManager to load the respective scenes when the buttons are clicked.
// Ensure that the scene names "SelfPollinationScene" and "CrossPollinationScene" match the actual names of your scenes in Unity.
// Attach this script to a GameObject in your scene, and assign the buttons in the Unity Editor.
// The buttons should be linked to the public Button fields in this script.
// This script is designed to be used in a Unity project where you have multiple scenes related to pollination and need to navigate between them.