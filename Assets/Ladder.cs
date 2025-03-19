using UnityEngine;

public class Ladder : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Enter");
            PlayerMovements player = other.GetComponent<PlayerMovements>();
            player.canClimb = true;
            player.SetLadderX(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Exit");
            other.GetComponent<PlayerMovements>().canClimb = false;
        }
    }
}
