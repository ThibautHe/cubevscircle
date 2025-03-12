using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Animator anim;
    public Transform shootPoint;
    private bool canShoot = true;
    private List<PowerUp> powerUps = new List<PowerUp>();
    public int originalMaxAmmo = 1;
    public int MaxAmmo = 1;

    private void Start()
    {
        MaxAmmo = originalMaxAmmo;
    }


    void Update()
    {
        foreach (PowerUp powerUp in powerUps)
        {
            powerUp.duration -= Time.deltaTime;
            if (powerUp.duration <= 0)
            {
                powerUp.duration = 0;
                powerUp.removePowerUp(this);
                powerUps.Remove(powerUp);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && canShoot) // Fire spear
        {
            Bullet spear = Instantiate(bulletPrefab.gameObject, shootPoint.position + bulletPrefab.transform.position, shootPoint.rotation).GetComponent<Bullet>();
            spear.AddOnDie(() => canShoot = true);
            anim.SetTrigger("attack");
            canShoot = false;
        }
    }

    public void AddPower(PowerUp power)
    {
        power.applyPowerUp(this);
        powerUps.Add(power);
    }
}
