using System;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class PowerUpSFX : MonoBehaviour, IPowerUpSFX
{
    [Header("SFX")]
    [SerializeField] private AudioClip audioClip;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Initializations();
    }

    public void PlaySFX(Utilities.PowerUpTypes powerUpType)
    {
        // We can use power up type to select required clip
        // Cureently we only have one clip, so directly playing it
        audioSource.PlayOneShot(audioClip);
    }

    private void Initializations()
    {
        audioSource = GetComponent<AudioSource>();
    }    
}
