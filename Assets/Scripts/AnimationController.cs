using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    public PlayerMovement playerMovement;
    public RotationAnimator rotationAnimator;
    
    public void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }
    public void Update()
    {
        animator.SetFloat("Speed", playerMovement.accelerationTimer);
        animator.SetInteger("RotationIndex", rotationAnimator.GetSector(rotationAnimator.angle));
    }
}
