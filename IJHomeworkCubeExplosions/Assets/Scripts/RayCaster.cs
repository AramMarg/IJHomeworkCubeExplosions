using System;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    private readonly float _maxDistanceRay = 30;

    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Camera _camera;
    [SerializeField] private Ray _ray;
    [SerializeField] private LayerMask _layerMask;

    public event Action<Collider> CubeFinded;

    private void OnEnable()
    {
        _inputReader.MouseButtonClicked += OnMouseButtonClicked;
    }

    private void OnDisable()
    {
        _inputReader.MouseButtonClicked -= OnMouseButtonClicked;
    }

    private void OnMouseButtonClicked(Vector3 mousePossition)
    {
        _ray = _camera.ScreenPointToRay(mousePossition);

        Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.red);

        if (Physics.Raycast(_ray.origin, _ray.direction, out RaycastHit hit, _maxDistanceRay, _layerMask))
        {
            if (hit.collider.TryGetComponent<Cube>(out _))
            {
                CubeFinded?.Invoke(hit.collider);
            }
        }
    }
}
