using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float duration = 5f; // Total time in seconds


    public virtual void applyPowerUp(PlayerShoot playerShoot) { }
    public virtual void removePowerUp(PlayerShoot playerShoot) { }

}
