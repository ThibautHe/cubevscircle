using UnityEngine;

public class BounceScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField]private float YbounceForce = 10f;
    [SerializeField]private float XbounceForce = 10f;
    private Rigidbody rb;

    public bool isInital;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if(isInital)
        {
            rb.AddForce(Vector3.right * XbounceForce, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x,YbounceForce,rb.linearVelocity.z);
        }
        
        if (collision.contacts[0].normal.x > 0.5f)
        {
            rb.linearVelocity = new Vector3(XbounceForce, rb.linearVelocity.y, rb.linearVelocity.z);
        }
        
        if (collision.contacts[0].normal.x < 0)
        {
            rb.linearVelocity = new Vector3(-XbounceForce,rb.linearVelocity.y,rb.linearVelocity.z);
        }
    }
}
