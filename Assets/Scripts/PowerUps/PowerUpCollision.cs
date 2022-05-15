using UnityEngine;

public class PowerUpCollision : MonoBehaviour
{
    [Header("Add References")]
    [SerializeField] Utilities.PowerUpTypes powerUpType;


    private void OnCollisionEnter2D(Collision2D collision)
    {     
        // Power Up is collided with bar
        if (collision.gameObject.tag == Utilities.barTag)
        {
            transform.parent.SendMessage("PlaySFX", powerUpType);                         
        }

        collision.gameObject.SendMessage("ReceivePowerUp", powerUpType, SendMessageOptions.DontRequireReceiver);
        
        Destroy(this.gameObject);
    }

}
