using UnityEngine;
using UnityEngine.EventSystems;

public class DragSound : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public AudioClip dragSound; // Assign the sound clip in the Inspector
    private AudioSource audioSource;
    private bool isDragging;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = dragSound;
        audioSource.loop = true; // Loop the sound while dragging
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;
        audioSource.Play();
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Handle the dragging logic here (optional)
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        audioSource.Stop();
    }

    void Update()
    {
        if (isDragging)
        {
            // Update the position of the object based on the drag (optional)
        }
    }
}
