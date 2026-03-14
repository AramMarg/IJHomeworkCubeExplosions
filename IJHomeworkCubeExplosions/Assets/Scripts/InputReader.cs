using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const int MouseButton = 0;

    public event Action<Vector3> MouseButtonClicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(MouseButton))
        {
            MouseButtonClicked?.Invoke(Input.mousePosition);
        }
    }
}
