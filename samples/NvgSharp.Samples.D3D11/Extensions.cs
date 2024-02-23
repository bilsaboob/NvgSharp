using System;

namespace NvgSharp.Samples.D3D11;

public static class RandomExtensions
{
    public static float NextFloat(this Random random)
    {
        return (float) random.NextDouble();
    }

    public static float NextFloat(this Random random, int min, int max)
    {
        return (float) random.NextDouble()*(max - min) + min;
    }
}