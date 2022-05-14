using UnityEngine;

public class BarPowerUps : MonoBehaviour, IPowerUp
{
    public void ReceivePowerUp(Utilities.PowerUpTypes powerUpType)
    {        
        GameManager.Instance.ApplyPowerUp(powerUpType);
    }
}
