using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;                         // The capsule to follow
    public Vector3 offset = new Vector3(0f, 3f, -5f); // Offset relative to capsule
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        // Rotate the offset based on the capsule's current rotation
        Vector3 rotatedOffset = target.rotation * offset;

        // Desired camera position behind the player
        Vector3 desiredPosition = target.position + rotatedOffset;

        // Smoothly interpolate the camera's position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        transform.position = smoothedPosition;

        // Make the camera look at the player
        transform.LookAt(target);
    }
}
