namespace RazorSharedLib.States.GameAssets;

public interface IDiceGeneratorState
{
    int[]? DiceArray { get; set; }

    void TwoD6();
    void ThreeD6();
    void ClearArray();
}