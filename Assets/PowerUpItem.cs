using UnityEngine;

public class PowerUpItem : MonoBehaviour
{

    [SerializeField]PowerUp powerUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Apply power-up effect
            PlayerShoot playerShoot = other.GetComponent<PlayerShoot>();

            playerShoot.AddPower(powerUp);

            // Destroy power-up object
            Destroy(gameObject);
        }
    }
}
