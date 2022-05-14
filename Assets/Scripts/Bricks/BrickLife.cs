using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class BrickLife : MonoBehaviour, IReceiveDamage
{
    public static Action<Vector3> OnBrickDestroy;
    public static Action<Vector3> OnBrickGuard;

    [Range(1,5)]
    [SerializeField] private int health = 5;
    [SerializeField] private Collider2D brickCollider;
    [SerializeField] private List<Color> colorLevels;

    private int startHealth;
    private Vector3 brickPosition;
    private SpriteRenderer spriteRenderer;
    private bool isFirstPass = true;

    // Original health should be equal to user provided health
    private void Awake()
    {
        // Storing initial health as start health for level replay
        startHealth = health;
    }

    private void Start()
    {
        Initializations();
    }


    // On level restart, bricks original health should restore
    private void OnEnable()
    {
        if (isFirstPass)
        {
            isFirstPass = false;
        }
        else
        {
            health = startHealth;
            brickCollider.enabled = true;
            SetBrickColor();           
        }
      
    }

    public void ReceiveDamage(int damage)
    {        
        health -= damage;
        SetBrickColor();

        // Brick Destroyed
        if (health <= 0)
        {            
            if (OnBrickDestroy != null)
            {                
                OnBrickDestroy(brickPosition);
            }

            brickCollider.enabled = false;
            this.gameObject.SetActive(false);
        }
        // Brick health is down
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

        brickCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        SetBrickColor();
    }
   
}
