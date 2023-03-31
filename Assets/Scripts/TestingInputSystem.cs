using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class TestingInputSystem : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float slowDownSpeed = 0.2f;

    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private int shootCooldown;

    [SerializeField] private float bulletSpeed;

    private float lastShotTime;
    private AudioSource audioSource;
    private Rigidbody2D squareRigidbody;
    private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;
    private Animator animator;
    private Vector2 lastDirection;
    private static readonly int AnimationNumber = Animator.StringToHash("AnimationNumber");

    public void Awake()
    {
        squareRigidbody = GetComponent<Rigidbody2D>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Movement.performed  += Movement;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        lastShotTime = Time.time - shootCooldown;
    }
    public void FixedUpdate()
    {
        
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        if (inputVector != Vector2.zero)
        {
            SpeedUp(inputVector);
            lastDirection = inputVector;
        }
        else SlowDown();
        CheckAnimation();
    }
    
    private void Movement(InputAction.CallbackContext context)
    {
        Vector2 inputVector = context.ReadValue<Vector2>();
        if(context.performed) squareRigidbody.AddForce(inputVector * speed, ForceMode2D.Force);
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("PRESSED");
            if (Time.time > lastShotTime + shootCooldown)
            {
                Debug.Log(lastShotTime);
                Debug.Log("SHOOT");
                lastShotTime = Time.time;
                Debug.Log(lastShotTime);
                Vector3 currDirection = lastDirection.normalized;
                Vector3 spawnLocation = transform.position + currDirection * 0.4f;
                Vector2 bulletVelocity = new Vector2(currDirection.x, currDirection.y) * bulletSpeed;
                Instantiate(bulletPrefab, spawnLocation, Quaternion.identity).GetComponent<Rigidbody2D>().velocity =
                    bulletVelocity;
            }
        }
    }
    private void SpeedUp(Vector2 inputVector)
    {
        
        squareRigidbody.velocity = inputVector * Mathf.Lerp(squareRigidbody.velocity.magnitude, speed, 0.2f);
    }

    private void SlowDown()
    {
        Vector2 velocity = squareRigidbody.velocity;
        squareRigidbody.velocity = new Vector2(Mathf.Lerp(velocity.x, 0, slowDownSpeed), Mathf.Lerp(velocity.y, 0, slowDownSpeed));
    }
    
    private void CheckAnimation()
    {
        if (squareRigidbody.velocity.normalized.x > 0) animator.SetInteger(AnimationNumber, 1);
        else if (squareRigidbody.velocity.normalized.x < 0) animator.SetInteger(AnimationNumber, 2);
        else animator.SetInteger(AnimationNumber, 0);
    }

    public void PlayStepsSound(float value)
    {
        audioSource.Play();
    }
}
