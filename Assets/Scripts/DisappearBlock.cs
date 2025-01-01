using UnityEngine;

public class DisappearBlock : MonoBehaviour
{
    public float interval = 3f; // Time interval for disappearing

    void Start()
    {
        // Start the disappearing process
        InvokeRepeating("ToggleVisibility", interval, interval);
    }

    void ToggleVisibility()
    {
        // Toggle the GameObject's active state
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
