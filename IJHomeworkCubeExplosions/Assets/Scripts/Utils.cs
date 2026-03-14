using System;
using Random = System.Random;

public static class Utils 
{
    private static Random s_random = new();

    public static int ReturnRandomInt(int minRandom = 0, int maxRandom = 101)
        => s_random.Next(minRandom, maxRandom);

    public static bool HaveShance(int minForShance = 50)
        => ReturnRandomInt() < minForShance;
}
