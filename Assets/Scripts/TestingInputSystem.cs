using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class TestingInputSystem : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float slowDownSpeed = 0.2f;

    private AudioSource audioSource;
    private Rigidbody2D squareRigidbody;
    private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;
    private Animator animator;

    public void Awake()
    {
        squareRigidbody = GetComponent<Rigidbody2D>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Movement.performed  += Movement;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    public void FixedUpdate()
    {
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        Debug.Log(inputVector);
        if (inputVector != Vector2.zero) SpeedUp(inputVector);
        else SlowDown();
        Debug.Log(squareRigidbody.velocity.normalized);
        CheckAnimation();
    }
    public void Movement(InputAction.CallbackContext context)
    {
        Vector2 inputVector = context.ReadValue<Vector2>();
        if(context.performed) squareRigidbody.AddForce(inputVector * speed, ForceMode2D.Force);
    }

    private void SpeedUp(Vector2 inputVector)
    {
        
        squareRigidbody.velocity = inputVector * Mathf.Lerp(squareRigidbody.velocity.magnitude, speed, 0.2f);
    }

    private void SlowDown()
    {
        Vector2 slowDownVector = squareRigidbody.velocity.normalized;
        squareRigidbody.velocity = new Vector2(Mathf.Lerp(squareRigidbody.velocity.x, 0, slowDownSpeed), Mathf.Lerp(squareRigidbody.velocity.y, 0, slowDownSpeed));
    }

    private void CheckAnimation()
    {
        if (squareRigidbody.velocity.normalized.x > 0) animator.SetInteger("AnimationNumber", 1);
        else if (squareRigidbody.velocity.normalized.x < 0) animator.SetInteger("AnimationNumber", 2);
        else animator.SetInteger("AnimationNumber", 0);
    }

    public void PlayStepsSound(float value)
    {
        audioSource.Play();
    }
}
