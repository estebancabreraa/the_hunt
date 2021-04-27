using System;

public class _HelperFunctions
{
    public static float GetPercentage(int over, int under)
    {
        var percentage = over / (float) under;
        percentage = (float) Math.Round(percentage, 2);
        return percentage;
    }
}
