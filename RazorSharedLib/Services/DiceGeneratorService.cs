using RazorSharedLib.Interface;
using RazorSharedLib.States.GameAssets;
using System;

namespace RazorSharedLib.Services;

public class DiceGeneratorService : IDiceGeneratorService
{
    public IDiceGeneratorState State { get; set; }

    private readonly Random _random = new();

    public DiceGeneratorService(IDiceGeneratorState state)
    {
        State = state;
    }

    public void OneD6()
    {
        State.DiceArray = GetDiceArray(6, 1);
    }

    public void TwoD6()
    {
        State.DiceArray = GetDiceArray(6, 2);
    }

    public void ThreeD6()
    {
        State.DiceArray = GetDiceArray(6, 3);
    }

    public void FourD6()
    {
        State.DiceArray = GetDiceArray(6, 4);
    }

    public void ClearArray()
    {
        State.DiceArray = null;
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