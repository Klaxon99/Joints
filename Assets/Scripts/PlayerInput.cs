using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private readonly KeyCode ShootKey = KeyCode.Space;
    private readonly KeyCode ReloadKey = KeyCode.R;
    private readonly KeyCode SwingKey = KeyCode.Mouse0;

    public event Action ShootKeyPressed;
    public event Action ReloadKeyPressed;
    public event Action SwingKeyPressed;

    private void Update()
    {
        if (Input.GetKeyDown(ShootKey))
        {
            ShootKeyPressed?.Invoke();
        }

        if (Input.GetKeyUp(ReloadKey))
        {
            ReloadKeyPressed?.Invoke();
        }

        if (Input.GetKeyDown(SwingKey))
        {
            SwingKeyPressed?.Invoke();
        }
    }
}