using UnityEngine;

public interface IPowerUp
{
    /// <summary>
    /// On power up collision, recevive message
    /// </summary>
    /// <param name="powerUpType"></param>
    void ReceivePowerUp(Utilities.PowerUpTypes powerUpType);   
}

public interface IReceiveDamage
{   /// <summary>
    /// Ball sending Damage to Bricks
    /// </summary>
    /// <param name="damage"></param>
    void ReceiveDamage(int damage);
}
