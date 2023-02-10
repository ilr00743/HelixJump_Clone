using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    private readonly Vector3 _localGravity = new Vector3(0,-30,0);
    
    [SerializeField] private MapGenerator _mapGenerator;
    [SerializeField] private float _fallSpeed;
    [SerializeField] private float _bounceSpeed;

    private Rigidbody _rigidbody;

    public event Action Failed;
    public event Action Finished;

    [ContextMenu(nameof(PlaceOnTop))]
    private void PlaceOnTop()
    {
        var offsetY = new Vector3(transform.position.x,5,transform.position.z);
        var startPosition = _mapGenerator.GetLastCirclePosition() + offsetY;
        transform.position = startPosition;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var currentVelocity = _rigidbody.velocity;
        currentVelocity.y = Mathf.Clamp(_rigidbody.velocity.y, -_fallSpeed, _bounceSpeed);
        _rigidbody.velocity = currentVelocity + _localGravity * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Bounce();
    }

    private void Bounce()
    {
        _rigidbody.velocity = new Vector3(0, _bounceSpeed, 0);   

    }

    public void StopMovement()
    {
        _rigidbody.velocity = Vector3.zero;
    }

    public void Finish()
    {
        Finished?.Invoke();
    }

    public void Fail()
    {
        Failed?.Invoke();
    }
}