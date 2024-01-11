using RazorSharedLib.Interface;

namespace RazorSharedLib.States.GameAssets;

public class DiceGeneratorState : IDiceGeneratorState
{
    public int[]? DiceArray { get; set; }
}