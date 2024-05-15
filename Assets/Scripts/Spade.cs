using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Spade : MonoBehaviour
{
    [SerializeField] private float _returnSpeed;
    [SerializeField] private SpringJoint _springJoint;

    public event Action ReadyShoot;

    private Quaternion _startRotation;
    private Rigidbody _rigidBody;
    private float _minSpring = 0;
    private float _maxSpring = 50;

    private void Start()
    {
        _startRotation = transform.rotation;
        _springJoint.spring = _minSpring;
        _rigidBody = GetComponent<Rigidbody>();
    }

    public void Rotate()
    {
        _rigidBody.WakeUp();
        _springJoint.spring = _maxSpring;
    }

    public void ReturnToStartPosition()
    {
        StartCoroutine(RotateRoutine());
    }

    private IEnumerator RotateRoutine()
    {
        _springJoint.spring = _minSpring;

        while (transform.rotation != _startRotation)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, _startRotation, _returnSpeed * Time.deltaTime);

            yield return null;
        }

        ReadyShoot?.Invoke();
    }
}