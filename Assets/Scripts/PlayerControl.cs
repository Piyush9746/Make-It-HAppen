using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float power = 10f;
    public float maxDrag = 5f;
    public Rigidbody2D rb;
    public LineRenderer lr;

    Vector3 dragStartPos;
    Touch touch;
    public bool isGrounded; // Flag to check if player is on the ground

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                DragStart();
            }

            if (touch.phase == TouchPhase.Moved)
            {
                Dragging();
            }

            if (touch.phase == TouchPhase.Ended)
            {
                DragRelease();
            }
        }
    }

    void DragStart()
    {
        dragStartPos = Camera.main.ScreenToWorldPoint(touch.position);
        dragStartPos.z = 0f;
        lr.positionCount = 2; // Set position count to 2 to include starting and ending points
        lr.SetPosition(0, dragStartPos);
        lr.SetPosition(1, dragStartPos); // Set the end position to the starting position initially
    }

    void Dragging()
    {
        Vector3 draggingPos = Camera.main.ScreenToWorldPoint(touch.position);
        draggingPos.z = 0f;

        // Calculate the direction and distance between start and current dragging position
        Vector3 direction = draggingPos - dragStartPos;
        float distance = Mathf.Min(direction.magnitude, maxDrag); // Limit distance to maxDrag

        // Set the end position of the LineRenderer to a point along the drag direction limited by maxDrag
        Vector3 endPos = dragStartPos + direction.normalized * distance;
        lr.SetPosition(1, endPos);
    }

    void DragRelease()
    {
        lr.positionCount = 0;

        Vector3 dragReleasePos = Camera.main.ScreenToWorldPoint(touch.position);
        dragReleasePos.z = 0f;

        if (isGrounded) // Check if player is grounded before applying force
        {
            Vector3 force = dragStartPos - dragReleasePos;
            Vector3 clampedForce = Vector3.ClampMagnitude(force, maxDrag) * power;
            rb.AddForce(clampedForce, ForceMode2D.Impulse);
        }
    }

    // You'll need to implement your own logic to determine if the player is grounded
    // Here's a basic example using a ground check collider:
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Replace "Ground" with your ground tag
        {
            isGrounded = true;
        }
    }



    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Replace "Ground" with your ground tag
        {
            isGrounded = false;
        }
    }
}



