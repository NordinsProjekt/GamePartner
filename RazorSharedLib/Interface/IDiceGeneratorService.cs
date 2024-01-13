using RazorSharedLib.States.GameAssets;

namespace RazorSharedLib.Interface;

public interface IDiceGeneratorService
{
    IDiceGeneratorState State { get; set; }
    void TwoD6();
    void ThreeD6();
    void ClearArray();
}