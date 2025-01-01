using UnityEngine;

public class CameraFollowY : MonoBehaviour
{
    public float followSpeed = 2f;
    public Transform Player;
    public float yOffset = 1f;

    void Update()
    {
        if (Player != null)
        {
            Vector3 newPos = new Vector3(transform.position.x, Player.position.y + yOffset, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPos, followSpeed * Time.deltaTime);
        }
    }
}
