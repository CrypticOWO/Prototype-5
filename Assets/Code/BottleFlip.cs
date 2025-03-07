using UnityEngine;
using TMPro;

public class BottleFlip : MonoBehaviour
{
    public GameObject bottlePrefab;
    public Transform spawnPoint;
    public float flipForce = 4f;
    public float forceMultiplier = 1f;
    public float torqueMultiplier = 0.00001f;
    public int Attempts;
    public TMP_Text AttemptsText;

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
            Attempts++;
            AttemptsText.text = "Attempts: " + Attempts;
            
            
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
