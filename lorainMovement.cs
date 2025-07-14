using UnityEngine;

public class LorainMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(moveX, 0, moveZ).normalized;

        if (direction.magnitude >= 0.1f)
        {
            Vector3 move = transform.position + direction * speed * Time.fixedDeltaTime;
            rb.MovePosition(move);
        }
    }
}
