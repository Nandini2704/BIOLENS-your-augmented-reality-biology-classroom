using UnityEngine;

public class KeepCameraAlive : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
//
// This script ensures that the camera GameObject it is attached to persists across scene loads.    
// It uses the DontDestroyOnLoad method in Unity to keep the camera alive even when changing scenes.
// Attach this script to your camera GameObject in the Unity Editor.
// This is useful in scenarios where you want to maintain camera settings or effects across different scenes without having to reinitialize them.