using System;
using System.Linq;

class HedgehogTest
{
    public int MinMeetingsToUnify(int targetColor , int[] population)
    {
        int sum = population[0] + population[1] + population[2];

        if (population[targetColor] == sum)
            return 0;

        int zeroCount = population.Count(x => x == 0);

        if (zeroCount >= 2)
            return -1; 

        int nonTargetColor1 = (targetColor + 1) % 3;
        int nonTargetColor2 = (targetColor + 2) % 3;

        if ((population[nonTargetColor1] + population[nonTargetColor2]) % 2 != 0)
            return -1;

        int steps = 0;

        while (population[nonTargetColor1] > 0 && population[nonTargetColor2] > 0)
        {
            int minPair = Math.Min(population[nonTargetColor1], population[nonTargetColor2]);
            population[targetColor] += minPair;
            population[nonTargetColor1] -= minPair;
            population[nonTargetColor2] -= minPair;
            steps += minPair;
        }

        if (population[nonTargetColor1] > 0 || population[nonTargetColor2] > 0)
            return -1;

        return steps;
    }
}