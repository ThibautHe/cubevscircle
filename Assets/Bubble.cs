using UnityEngine;

public class Bubble : MonoBehaviour
{
    public GameObject smallBubblePrefab; // Assign in Inspector
    private BounceScript bounceScript;
    public int splitCount = 2; // Number of bubbles to spawn
    public float forceAmount = 4f; // Force applied to new bubbles
    public float YforceAmount = 8f; // Force applied to new bubbles
    private bool ispopped = false;

    public void die()
    {
        PopBubble();
    }

    void PopBubble()
    {
        if (ispopped) return;
        for (int i = 0; i < splitCount; i++)
        {
            Debug.Log("spawn bubble");
            GameObject newBubble = Instantiate(smallBubblePrefab, transform.position, Quaternion.identity);
            BounceScript bounceScript = newBubble.GetComponent<BounceScript>();
            if (bounceScript != null)
            {
                bounceScript.isInital = false;
            }
            Rigidbody rb = newBubble.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(i == 0 ? new Vector3(1 * forceAmount, 1 * YforceAmount,0)  : new Vector3(-1 * forceAmount, 1 * YforceAmount,0), ForceMode.Impulse);
            }
        }
        ispopped = true;
        Destroy(gameObject); // Destroy the original bubble
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ceiling"))
        {
            Destroy(gameObject);
        }
    }
}
