using UnityEngine;

public class BottleFlip : MonoBehaviour
{
    public GameObject bottlePrefab;
    public Transform spawnPoint;
    public float flipForce = 10f;
    public float forceMultiplier = 1f;
    public float torqueMultiplier = 5f;

    private Vector3 lastMousePosition;
    private float flickSpeed;

    private Rigidbody rb;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector3 mouseDelta = Input.mousePosition - lastMousePosition;
            flickSpeed = mouseDelta.magnitude / Time.deltaTime;

            
            GameObject bottle = Instantiate(bottlePrefab, spawnPoint.position, Quaternion.identity);
            
            
            rb = bottle.GetComponent<Rigidbody>();
            
            ApplyFlickForce(mouseDelta, flickSpeed);
        }
    }

    void ApplyFlickForce(Vector3 mouseDelta, float speed)
    {
        
        Vector3 flickDirection = mouseDelta.normalized;

        rb.AddForce(flickDirection.x * flipForce * forceMultiplier, 0, flickDirection.y * flipForce * forceMultiplier, ForceMode.Impulse);
        rb.AddTorque(Vector3.up * flickDirection.x * speed * torqueMultiplier, ForceMode.Impulse);
        rb.AddTorque(Vector3.right * flickDirection.y * speed * torqueMultiplier, ForceMode.Impulse);
    }
}
