using UnityEngine;

public class Catapult : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Transform _projectileSpawnPoint;
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private Spade _spade;

    private void Start()
    {
        _playerInput.ReloadKeyPressed += OnReload;
        _playerInput.ShootKeyPressed += OnShoot;
        _spade.ReadyShoot += OnReadyShoot;

        Instantiate(_projectilePrefab, _projectileSpawnPoint.position, Quaternion.identity);
    }

    private void OnDisable()
    {
        _playerInput.ShootKeyPressed -= OnShoot;
        _playerInput.ReloadKeyPressed -= OnReload;
        _spade.ReadyShoot -= OnReadyShoot;
    }

    private void OnReload()
    {
        _spade.ReturnToStartPosition();
    }

    private void OnShoot()
    {
        _spade.Rotate();
    }

    private void OnReadyShoot()
    {
        Instantiate(_projectilePrefab, _projectileSpawnPoint.position, Quaternion.identity);
    }
}