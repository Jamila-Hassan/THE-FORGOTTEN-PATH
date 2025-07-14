using UnityEngine;

public class CapsuleMovement : MonoBehaviour
{
    public float moveSpeed = 2f;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // Left/Right Arrows or A/D
        float moveZ = Input.GetAxis("Vertical");   // Up/Down Arrows or W/S

        Vector3 move = new Vector3(moveX, 0, moveZ);
        transform.Translate(move * moveSpeed * Time.deltaTime);
    }
}
