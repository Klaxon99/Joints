using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public event Action ShootKeyPressed;
    public event Action ReloadKeyPressed;
    public event Action SwingKeyPressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootKeyPressed?.Invoke();
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            ReloadKeyPressed?.Invoke();
        }

        if (Input.GetMouseButtonDown(0))
        {
            SwingKeyPressed?.Invoke();
        }
    }
}