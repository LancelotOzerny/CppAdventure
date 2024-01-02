using UnityEngine;

public class CUnitMovement : CContactLayer
{
    [Header("Movement Speed")]
    [SerializeField] protected float movementSpeed = 4f;
    [SerializeField] protected float jumpPower = 12f;
    public Vector2 MoveDirection { get; protected set; }
    

    private Rigidbody2D rb = null;
    public Rigidbody2D Rigidbody2D 
    { 
        get => rb; 
        protected set => rb = value; 
    }


    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Скорость юнита
    /// </summary>
    public float MovementSpeed
    {
        get => movementSpeed;
        protected set => movementSpeed = value;
    }

    /// <summary>
    /// Сила прыжка
    /// </summary>
    public float JumpPower
    {
        get => jumpPower;
        protected set => jumpPower = value;
    }

    private void FixedUpdate()
    {
        if (rb == null)
        {
            return;
        }

        rb.velocity = new Vector2 (MoveDirection.x * MovementSpeed, rb.velocity.y);
    
        if (MoveDirection.x > 0)
        {
            Jump();
        }
    }

    /// <summary>
    /// Метод, который вызывает прыжок персонажа
    /// </summary>
    private void Jump()
    {
        if (IsGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }
}
