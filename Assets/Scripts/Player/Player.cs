using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : DamageableUnit, IPlayerDamageable
{
    [SerializeField] private float movementSmoothTime = 0.05f;
    [SerializeField] private float speed = 5;

    [Inject] private InputActions _inputActions;

    private Rigidbody2D _rigidbody2d;

    private Vector2 _smoothedMoveInputVelocity;
    private Vector2 _smoothedMoveInputNormalized;

    protected override void Awake()
    {
        base.Awake();

        _rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public Vector2 GetMovementVectorNormalized()
        => _inputActions.Player.Move.ReadValue<Vector2>();

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        var moveInputNormalized = GetMovementVectorNormalized();

        _smoothedMoveInputNormalized = Vector2.SmoothDamp(
            _smoothedMoveInputNormalized,
            moveInputNormalized,
            ref _smoothedMoveInputVelocity,
            movementSmoothTime);

        _rigidbody2d.velocity = _smoothedMoveInputNormalized * speed;
    }
}
