using UnityEngine;
using System.Collections;

public class BottleLifeSpan : MonoBehaviour
{
    public float lifeSpan = 10f;
    public GameObject Explosion;

    void Start()
    {
        StartCoroutine(DestroyBottleAfterTime());
    }

    private IEnumerator DestroyBottleAfterTime()
    {
        yield return new WaitForSeconds(lifeSpan);

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bottle") || collision.gameObject.CompareTag("Floor"))
        {
            Vector3 collisionPoint = collision.contacts[0].point;
            Instantiate(Explosion, collisionPoint, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
