using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForse;
    [SerializeField] private ParticleSystem _effect;

    private int _tempForControrForce = 1;

    public void RunExplode(Collider[] cubesExplosion, Vector3 explosionCentre)
    {
        foreach (var cube in cubesExplosion)
        {
            float tempForce = _explosionForse * (_tempForControrForce / cube.transform.localScale.magnitude);

            if (cube.attachedRigidbody != null)
            {
                cube.attachedRigidbody.AddExplosionForce(tempForce, explosionCentre, _explosionRadius);
            }
        }

        PlayEffect(explosionCentre);
    }

    private void PlayEffect(Vector3 explosionCentre)
    {
        Instantiate(_effect, explosionCentre, Quaternion.identity);
    }
}
