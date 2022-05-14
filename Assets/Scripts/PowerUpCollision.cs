using UnityEngine;

public class PowerUpCollision : MonoBehaviour
{
    [SerializeField] Utilities.PowerUpTypes powerUpType;

    private void OnCollisionEnter2D(Collision2D collision)
    {    
        collision.gameObject.SendMessage("ReceivePowerUp", powerUpType, SendMessageOptions.DontRequireReceiver);
        
        Destroy(this.gameObject);
    }
}
