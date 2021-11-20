using UnityEngine;

public class Player_InputSystem : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private PlayerInput _input;


    private void Awake()
    {
        _input = new PlayerInput();

        _input.Player.Shot.performed += context => Shot();
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

        Movement(moveDirecion);
    }


    private void Movement(Vector2 direcion)
    {
        float scaledMovement = _moveSpeed * Time.deltaTime;

        Vector3 moveDirection = new Vector3(direcion.x, direcion.y, 0);

        transform.position += moveDirection * scaledMovement;
    }


    private void Shot()
    {
        Debug.Log("SHOOOT");
    }
}
