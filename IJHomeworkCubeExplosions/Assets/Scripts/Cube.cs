using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    private readonly int _chanceReduction = 2;

    public int CountOfShance { get; private set; } = 100;

    public bool HaveChance()
    {
        bool  isSeparated = Utils.HaveShance(CountOfShance);

        CountOfShance /= _chanceReduction;

        return isSeparated;
    }

    public void SetShance(int chance)
    {
        CountOfShance = chance;
    }
}
