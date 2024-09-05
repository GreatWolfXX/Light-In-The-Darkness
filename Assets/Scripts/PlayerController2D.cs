using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public Transform target;

    private Rigidbody2D _rb;
    public float speedFront = 2f;
    public float speedBack = 1f;
    private float _speed;
    private float _moveInput;

    private Animator _animator;

    private bool _isFacingRight = true;
    private bool _isWalkBack;
    
    public Camera mainCamera;
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int IsWalkBack = Animator.StringToHash("isWalkBack");

    private Vector2 _tempMousePosition;

    private AudioSource _soundSteps;
    
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _soundSteps = GetComponents<AudioSource>()[0];
    }

    private void Update()
    {
        MouseMovement();
        Movement();
        MuteStepSound();
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_moveInput, _rb.velocity.y);
    }

    private void Movement()
    {
        _moveInput = Input.GetAxisRaw("Horizontal") * _speed;
        
        if(_isFacingRight && _moveInput < 0f || !_isFacingRight && _moveInput > 0f)
        {
            _isWalkBack = true; 
            _speed = speedBack;
        } else
        {
            _isWalkBack = false;
            _speed = speedFront;
        }
        
        _animator.SetFloat(Speed, Mathf.Abs(_moveInput));
        _animator.SetBool(IsWalkBack, _isWalkBack);
    }

    private void MouseMovement()
    {
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        
        var mouseHorizontalPosition = transform.position.x - mousePosition.x;
        if (mouseHorizontalPosition > 0.1f || mouseHorizontalPosition < -0.1f)
        {
            var transform1 = transform;
            var localeScale1 = transform1.localScale;
            target.position = mousePosition;
            _tempMousePosition = mousePosition;
            if (mouseHorizontalPosition > 0.1f && _isFacingRight)
            {
                _isFacingRight = false;
                localeScale1.x *= -1f;
            } else if(mouseHorizontalPosition < -0.1f && !_isFacingRight)
            {
                _isFacingRight = true;
                localeScale1.x *= -1f;
            }
            transform.localScale = localeScale1;
        }
        else
        {
            target.position = _tempMousePosition;
        }
    }

    private void MuteStepSound()
    {
        _soundSteps.mute = _moveInput == 0f;
    }
}