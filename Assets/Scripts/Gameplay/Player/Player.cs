using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
public class Player : MonoBehaviour
{
    private protected HashAnimationsNames _animBase = new HashAnimationsNames();

    private PlayerInput _input;

    [Header ("Player Parameters")]
    [SerializeField] private float _moveSpeed = 10;
    [Space (height: 5f)]

    [SerializeField] private bool _facingRight = false;

    #region Components
    private Animator _animator;
    private Transform _transform;
    private Rigidbody2D _rigidbody2D;
    #endregion
    

    private void Awake()
    {
        _input = new PlayerInput();

        _input.Player.Shot.performed += context => Shotting();
    }


    private void Start()
    {
        #region GetComponents
        _animator = GetComponent<Animator>();
        _transform = GetComponent<Transform>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        #endregion
    }


    private void OnEnable()
    {
        _input.Enable();
    }


    private void OnDisable()
    {
        _input.Disable();
    }


    private void Update()
    {
        Vector2 moveDirecion = _input.Player.Move.ReadValue<Vector2>();

        Moving(moveDirecion);
    }


    private void Moving(Vector2 direcion)
    {
        float scaledMovement = _moveSpeed * Time.deltaTime;

        //с прыжками
        //Vector3 moveDirection = new Vector3(direcion.x, direcion.y, 0);

        //без прыжков
        Vector3 moveDirection = new Vector3(direcion.x, 0, 0);

        _transform.position += moveDirection * scaledMovement;

        #region Flip
        if (_facingRight == false && direcion.x > 0)
        {
            Flip();
        }
        else if (_facingRight == true && direcion.x < 0)
        {
            Flip();
        }
        #endregion

        Animations(direcion);
    }


    private void Shotting()
    {
        Debug.Log("Shot!");
    }


    private void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 Scaler = _transform.localScale;
        Scaler.x *= -1;
        _transform.localScale = Scaler;
    }


    #region Animations
    private void Animations(Vector2 direcion)
    {
        if (direcion.x != 0)
        {
            _animator.SetBool(_animBase.RunBoolHash, true);
        }
        else
        {
            _animator.SetBool(_animBase.RunBoolHash, false);
        }
    }
    #endregion
}