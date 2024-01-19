using RazorSharedLib.States.GameAssets;

namespace RazorSharedLib.Interface;

public interface IDiceGeneratorService
{
    IDiceGeneratorState State { get; set; }

    void OneD6();
    void TwoD6();
    void ThreeD6();
    void FourD6();

    void ClearArray();
}