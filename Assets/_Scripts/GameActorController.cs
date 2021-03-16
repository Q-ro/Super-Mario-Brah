/*
    
Author : Andres Mrad
Date : Tuesday 02/March/2021 @ 08:15:54 
Description : Base class for that defines the behavior of the game actors    
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class GameActorController : MonoBehaviour
{

    #region Inspector Properties

    [SerializeField] protected float movementSpeed = 2f; // Defines the movement speed for the current actor
    [SerializeField] protected float jumpForce = 2f; // Defines the jump force
    [SerializeField] protected float bounceForce = 2f; // Defines the bounce force

    [Range(0, 2)]
    [SerializeField] protected float groundCheckDistance = 0f; // Defines the jump force

    [Tooltip("Define la capa que es el suelo del juego")]
    [SerializeField] protected LayerMask whatIsGround;

    #endregion

    #region Private Properties

    protected Rigidbody2D _rigidBody2D; //Stores a reference to the rigidbody2D
    protected Transform _tranform; //Stores a reference to the tranform
    protected Animator _animator; //Stores a reference to the animator
    protected AudioSource _audiosource; //Stores a reference to the audioSource
    protected BoxCollider2D _collider; //Stores a reference to the collider
    protected SpriteRenderer _sprite; //Stores a reference to the SpriteRenderer
    protected bool _isGrounded = true;
    protected bool _isRunning = false;
    protected bool _isJumping = false;
    protected bool _isAttacking = false;
    protected bool _isFacingRight = true;

    // Store the movement for the current timestep 
    protected float _vx;
    protected float _vy;

    #endregion


    void Awake()
    {
        _tranform = GetComponent<Transform>();
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _audiosource = GetComponent<AudioSource>();
        _collider = GetComponent<BoxCollider2D>();
        _sprite = GetComponent<SpriteRenderer>();

        if (_tranform == null)
            Debug.LogError("Missing component !");
        if (_rigidBody2D == null)
            Debug.LogError("Missing component !");
        if (_animator == null)
            Debug.LogError("Missing component !");
        if (_audiosource == null)
            Debug.LogError("Missing component !");
        if (_collider == null)
            Debug.LogError("Missing component !");
        if (_sprite == null)
            Debug.LogError("Missing component !");

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    protected void Update()
    {

        // Comprobar si estamos "grounded" (es decir si estamos tocando el suelo)
        DoGroundCheck(_tranform.position, new Vector2(_tranform.position.x, _tranform.position.y - groundCheckDistance));
        _vy = _rigidBody2D.velocity.y;

        DoAnimation();

    }

    protected void FixedUpdate()
    {
        DoMove();
        if (_isJumping && _isGrounded)
            DoJump();
    }

    // Makes the character jump
    void DoJump()
    {
        AddVerticalForce(jumpForce);
        _isJumping = false;
    }

    public void DoBounce()
    {
        AddVerticalForce(bounceForce);
    }

    private void AddVerticalForce(float force)
    {
        _vy = 0;
        _rigidBody2D.AddForce(new Vector2(0, force));
    }

    void DoMove()
    {
        _rigidBody2D.velocity = new Vector2(_vx * movementSpeed * Time.fixedDeltaTime, _vy);

        if (_vx != 0)
            _isRunning = true;
        else
            _isRunning = false;
    }

    void DoAnimation()
    {
        Flip();
        _animator.SetBool("IsRunning", _isRunning);
        // if (_isJumping)
        if (!_isGrounded)
            _animator.SetTrigger("IsJumping");
        _animator.SetBool("IsGrounded", _isGrounded);
    }

    void Flip()
    {
        if (_vx < 0 && _isFacingRight)
        // if (_vx < 0)
        {
            _sprite.flipX = true;
            _isFacingRight = false;
        }
        else if (_vx > 0 && !_isFacingRight)
        // else if (_vx > 0)
        {
            _sprite.flipX = false;
            _isFacingRight = true;
        }
    }

    // checks for ground under game actor, draws line gizmo
    void DoGroundCheck(Vector3 start, Vector3 end)
    {
        _isGrounded = Physics2D.Linecast(start, end, whatIsGround);
        Debug.DrawLine(start, end, Color.cyan);
    }

    // void OnDrawGizmosSelected()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawLine(transform.position, new Vector2(_tranform.position.x, _tranform.position.y - 1.15f));
    // }
}
