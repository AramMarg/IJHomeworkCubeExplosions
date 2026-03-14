using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    public Collider[] CreateCubes(Collider cubeCollider)
    {
            int minCountCubes = 2;
            int maxCountCubes = 6;
            int tempForMaxRandomBoard = 1;

            int countCubes = Utils.ReturnRandomInt(minCountCubes, maxCountCubes + tempForMaxRandomBoard);

            Collider[] createdCubes = new Collider[countCubes];

            for (int i = 0; i < countCubes; i++)
            {
                createdCubes[i] = Instantiate(cubeCollider, cubeCollider.transform.position, Quaternion.identity);

                SetShance(createdCubes[i], cubeCollider.GetComponent<Cube>().CountOfShance);

                PaintCube(createdCubes[i]);

                DecreaseScale(createdCubes[i]);
            }

        return createdCubes;
    }

    private void PaintCube(Collider createdCube)
    {
        if (createdCube.TryGetComponent<Renderer>(out Renderer component))
        {
            component.material.color = new Color(Random.value, Random.value, Random.value);
        }
    }

    private void DecreaseScale(Collider collider)
    {
        int desreaseScale = 2;

        collider.transform.localScale /= desreaseScale;
    }

    private void SetShance(Collider collider, int shance)
    {
        collider.GetComponent<Cube>().SetShance(shance);
    }
}
