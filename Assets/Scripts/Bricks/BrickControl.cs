using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AudioSource))]
public class BrickControl : MonoBehaviour
{
    public static Action OnAllBrickDestroy;

    [Header("Add References")]
    [SerializeField] private List<ParticleSystem> brickDestroyVfx;
    [SerializeField] private List<ParticleSystem> brickGuardVfx;
    [SerializeField] private AudioClip destroyAudioClip;
    [SerializeField] private AudioClip guardAudioClip;
    [SerializeField] private AudioClip powerUpAudioClip;
    [SerializeField] private GameObject[] powerUpPrefabs;
 
    private AudioSource audioSource;
    private int destroyVfxLength;
    private int bricksInGame;
    private BrickLife[] bricks;
    private int totalPowerUps;

    private void Start()
    {
        Initializations();
        SubscribeEvents();
        CountBricksInGame();
    }

    
    private void CountBricksInGame()
    {
        bricks = GetComponentsInChildren<BrickLife>();
        bricksInGame = bricks.Length;
    }


    // Restart level 
    // Reactivate all bricks to it's original state
    public void ReActivateAllBricks()
    {
        bricksInGame = bricks.Length;
        GameObject brickGameObject;

        for (int brickIndex= 0; brickIndex < bricks.Length; brickIndex++)
        {
            brickGameObject = bricks[brickIndex].gameObject;

            // Disable All Bricks
            if (brickGameObject.activeSelf == true)
            {
                brickGameObject.SetActive(false);
            }

            // Enable all to reactivate original state
            brickGameObject.SetActive(true);
        }
    }

    private void PlayDestroyVFXAndSound(Vector3 position)
    {
        bricksInGame -= 1;

        // play Sound
        audioSource.PlayOneShot(destroyAudioClip);

        // Choose random destroy VFX
        int randomVfx = Random.Range(0, destroyVfxLength);
        brickDestroyVfx[randomVfx].transform.position = position;
        brickDestroyVfx[randomVfx].Play();
        GeneratePowerUp(position);

        // All brick destroy event
        if (bricksInGame <= 0)
        {
            if (OnAllBrickDestroy != null)
            {
                OnAllBrickDestroy();
            }
        }
    }

    // Brick health/ level is down
    private void PlayGuardVFXAndSound(Vector3 position)
    {
        audioSource.PlayOneShot(guardAudioClip);
        brickGuardVfx[0].transform.position = position;
        brickGuardVfx[0].Play();
    }

    private void GeneratePowerUp(Vector3 position)
    {
        // Power Generartion probaility is 50%
        int probabilityVal = Random.Range(0, 2);       

        if (probabilityVal == 1)
        {
            // Get random powerup index   
            int powerUpRandomIndex = Random.Range(0, totalPowerUps);
            Instantiate(powerUpPrefabs[powerUpRandomIndex], position, Quaternion.identity);
            audioSource.PlayOneShot(powerUpAudioClip);
        }
    }

    private void SubscribeEvents()
    {
        BrickLife.OnBrickDestroy += PlayDestroyVFXAndSound;
        BrickLife.OnBrickGuard += PlayGuardVFXAndSound;
    }

    private void Initializations()
    {
        destroyVfxLength = brickDestroyVfx.Count;
        totalPowerUps = powerUpPrefabs.Length;
        audioSource = GetComponent<AudioSource>();
    }

}
