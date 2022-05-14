using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class BrickLife : MonoBehaviour
{
    public static Action<Vector3> OnBrickDestroy;
    public static Action<Vector3> OnBrickGuard;

    [Range(1,5)]
    [SerializeField] private int health = 5;
    [SerializeField] private Collider2D collider;
    [SerializeField] private List<Color> colorLevels;

    private int startHealth;
    private Vector3 brickPosition;
    private SpriteRenderer spriteRenderer;
    private bool isFirstPass = true;

    // Original health should be equal to user provided health
    private void Awake()
    {
        startHealth = health;
    }

    private void Start()
    {
        Initializations();
    }


    // On Reactivating bricks original health should restore
    private void OnEnable()
    {
        if (isFirstPass)
        {
            isFirstPass = false;
        }
        else
        {
            health = startHealth;
            collider.enabled = true;
            SetBrickColor();           
        }
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {        
        health -= 1;
        SetBrickColor();

        if (health <= 0)
        {            
            if (OnBrickDestroy != null)
            {                
                OnBrickDestroy(brickPosition);
            }

            collider.enabled = false;
            this.gameObject.SetActive(false);
        }
        else
        {
            if (OnBrickGuard != null)
            {
                OnBrickGuard(brickPosition);
            }
        }
        
    }


    private void SetBrickColor()
    {
        if (health > 0)
        {
            spriteRenderer.color = colorLevels[health - 1];
        }       
    }

    private void Initializations()
    {
        brickPosition = transform.position;
        startHealth = health;

        collider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        SetBrickColor();
    }


}
