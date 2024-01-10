using RazorSharedLib.Interface;

namespace RazorSharedLib.States.GameAssets;

public class DiceGeneratorState : IDiceGeneratorState
{
    private readonly Random _random = new();
    public int[]? DiceArray { get; set; }

    public void TwoD6()
    {
        DiceArray = GetDiceArray(6, 2);
    }

    public void ThreeD6()
    {
        DiceArray = GetDiceArray(6, 3);
    }

    public void ClearArray()
    {
        DiceArray = null;
    }

    private int[] GetDiceArray(int diceSize, int numOfDices, int? modifier = null)
    {
        var dices = new int[numOfDices];

        for (int i = 0; i < numOfDices; i++)
        {
            var dice = (_random.Next(diceSize) + 1);
            if (modifier is not null)
            {
                dice += modifier.Value;
            }

            dices[i] = dice;
        }

        return dices;
    }
}