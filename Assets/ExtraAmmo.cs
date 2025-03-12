using UnityEngine;

public class ExtraAmmo : PowerUp
{

    public override void applyPowerUp(PlayerShoot playerShoot)
    {
        base.applyPowerUp(playerShoot);
        playerShoot.MaxAmmo = 3;
    }

    public override void removePowerUp(PlayerShoot playerShoot)
    {
        base.removePowerUp(playerShoot);
        playerShoot.MaxAmmo = playerShoot.originalMaxAmmo;
    }

}
