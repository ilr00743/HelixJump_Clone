using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    [SerializeField] private MapGenerator _mapGenerator;
    [SerializeField] private float _fallSpeed;
    [SerializeField] private float _bounceSpeed;
    [SerializeField] private int _gravityMultiplier = 10;
    [SerializeField] private Splash _splash;
    private MeshRenderer _renderer;
    private Rigidbody _rigidbody;
    private Vector3 _startPosition;

    public event Action Failed;
    public event Action Finished;

    [ContextMenu(nameof(PlaceOnTop))]
    private void PlaceOnTop()
    {
        var offsetY = new Vector3(transform.position.x,5,transform.position.z);
        var startPosition = _mapGenerator.GetStartCirclePosition() + offsetY;
        transform.position = startPosition;
    }

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        ClampVelocity();
        _rigidbody.AddForce(Physics.gravity * _gravityMultiplier, ForceMode.Acceleration);
    }

    private void ClampVelocity()
    {
        var currentVelocity = _rigidbody.velocity;
        currentVelocity.y = Mathf.Clamp(_rigidbody.velocity.y, -_fallSpeed, _bounceSpeed);
        _rigidbody.velocity = currentVelocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _splash.Generate(collision.contacts[0].point, collision.transform, _renderer.material.color);
        Bounce();
    }

    private void Bounce()
    {
        _rigidbody.velocity = Vector3.up * _bounceSpeed;
    }

    public void StopMovement()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.isKinematic = true;
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