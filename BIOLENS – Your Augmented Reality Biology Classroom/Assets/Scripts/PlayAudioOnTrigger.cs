using UnityEngine;

public class PlayAudioOnTrigger : MonoBehaviour
{
    public AudioSource audioSource;

    public void PlaySound()
    {
        if (!audioSource.isPlaying)
            audioSource.Play();
    }
}
// This script is designed to play an audio clip when a specific event occurs, such as a trigger being activated.
// It uses Unity's AudioSource component to handle audio playback.
// To use this script, attach it to a GameObject that has an AudioSource component.
// Ensure that the AudioSource is assigned in the Unity Editor.
// You can call the PlaySound method from other scripts or events to trigger the audio playback.
// This is useful for adding sound effects to interactions in your game, such as button clicks, object pickups, or environmental sounds.