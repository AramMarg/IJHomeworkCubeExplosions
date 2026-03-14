using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExplosionHandler : MonoBehaviour
{
    [SerializeField] private RayCaster _rayCaster;
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private Exploder _exploder;

    private void OnEnable()
    {
        _rayCaster.CubeFinded += OnCubeFinded;
    }

    private void OnDisable()
    {
        _rayCaster.CubeFinded -= OnCubeFinded;
    }

    private void OnCubeFinded(Collider findedCube)
    {
        if (findedCube.GetComponent<Cube>().HaveChance())
        {
            var cubesForExplosion = _cubeSpawner.CreateCubes(findedCube);

            if (cubesForExplosion.Length > 0)
            {
                _exploder.RunExplode(cubesForExplosion, findedCube.transform.position);
            }
        }
        else
        {
            float sphereRadius = 10;

            Collider[] hitCubes = Physics.OverlapSphere(findedCube.transform.position, sphereRadius);

            List<Rigidbody> exploadableCubes = new();

            foreach (Collider cube in hitCubes)
            {
                if (cube.attachedRigidbody != null)
                {
                    exploadableCubes.Add(cube.attachedRigidbody);
                }
            }

            Collider[] cubesForExplosion = exploadableCubes.Select(cube => cube.GetComponent<Collider>()).ToArray();

            _exploder.RunExplode(cubesForExplosion, findedCube.transform.position);
        }
    
        Destroy(findedCube.gameObject);
    }
}
