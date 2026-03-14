using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    private readonly int _chanceReduction = 2;

    private int _countOfShance = 100;

    public bool HaveChance()
    {
        if ((_countOfShance /= _chanceReduction) > 0)
            return Utils.HaveShance();

        return false;
    }
}
