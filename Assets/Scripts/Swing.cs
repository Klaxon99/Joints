using UnityEngine;

public class Swing : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _torqueForce;
    [SerializeField] private PlayerInput _playerInput;

    private void OnEnable()
    {
        _playerInput.SwingKeyPressed += OnSwingKeyPressed;
    }

    private void OnDisable()
    {
        _playerInput.SwingKeyPressed -= OnSwingKeyPressed;
    }

    private void OnSwingKeyPressed()
    {
        _rigidbody.AddForce(transform.right * _torqueForce);
    }
}