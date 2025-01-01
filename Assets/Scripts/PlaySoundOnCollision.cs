using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    public AudioSource impactSound; // Public variable to assign the sound effect

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Check if collision is with the floor
        {
            if (impactSound != null && !impactSound.isPlaying) // Check if sound is assigned and not playing
            {
                impactSound.Play();
            }
        }
    }
}
