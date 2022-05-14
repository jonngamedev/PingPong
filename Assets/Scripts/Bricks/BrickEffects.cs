using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AudioSource))]
public class BrickEffects : MonoBehaviour
{
    [Header("Add References")]
    [SerializeField] private List<ParticleSystem> brickDestroyVfx;
    [SerializeField] private List<ParticleSystem> brickGuardVfx;
    [SerializeField] private AudioClip destroyAudioClip;
    [SerializeField] private AudioClip guardAudioClip;

    private AudioSource audioSource;
    private int destroyVfxLength;

    private void Start()
    {
        Initializations();
        SubscribeEvents();
    }

   
    private void PlayVFXAndSound(Vector3 position)
    {
        audioSource.PlayOneShot(destroyAudioClip);

        int randomVfx = Random.Range(0, destroyVfxLength);

        brickDestroyVfx[randomVfx].transform.position = position;
        brickDestroyVfx[randomVfx].Play();        
    }

    private void PlayGuardVFXAndSound(Vector3 position)
    {
        audioSource.PlayOneShot(guardAudioClip);
        brickGuardVfx[0].transform.position = position;
        brickGuardVfx[0].Play();
    }

    private void SubscribeEvents()
    {
        BrickLife.OnBrickDestroy += PlayVFXAndSound;
        BrickLife.OnBrickGuard += PlayGuardVFXAndSound;
    }

    private void Initializations()
    {
        destroyVfxLength = brickDestroyVfx.Count;
        audioSource = GetComponent<AudioSource>();
    }

}
