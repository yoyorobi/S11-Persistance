using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Vaisseau : MonoBehaviour
{
    [SerializeField] private float forceMoteur;
    [SerializeField] private MiniJeu jeu;
    [SerializeField] private GameObject fxExplosion;

    private Rigidbody2D rb;
    private Animator animator;
    
    private Vector2 directionInput;
    private Vector2 positionPointerEcran;
    private bool vaisseauAccelere;
    private Vector3 positionPointerMonde;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
        animator = GetComponent<Animator>();
    }

    void OnMove(InputValue input)
    {
        directionInput = input.Get<Vector2>();
    }

    void OnPointerMove(InputValue input)
    {
        positionPointerEcran = input.Get<Vector2>();
    }

    void OnFire(InputValue input)
    {
        vaisseauAccelere = input.isPressed;
        animator.SetBool("Acceleration", vaisseauAccelere);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(positionPointerMonde, transform.position);
    }

    private void Update()
    {
        jeu.pointageTemps += Time.deltaTime;        
    }

    void FixedUpdate()
    {
        // Version souris
        Vector3 positionEcranTraitee = new Vector3(positionPointerEcran.x, positionPointerEcran.y, Camera.main.nearClipPlane);
        positionPointerMonde = Camera.main.ScreenToWorldPoint(positionEcranTraitee);
        positionPointerMonde.z = 0f;
        transform.right = positionPointerMonde - transform.position;
        if (vaisseauAccelere)
        {
            rb.AddRelativeForce(Vector2.right * forceMoteur, ForceMode2D.Force);
        }
    }

    private void OnDestroy()
    {
        Instantiate(fxExplosion, transform.position, transform.rotation);
    }
}
