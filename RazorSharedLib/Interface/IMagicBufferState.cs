using RazorSharedLib.Api;

namespace RazorSharedLib.States.Buffer;

public interface IMagicBufferState
{
    Task InitializeAsync(ApiClient client);
    List<MtGSetRecordDTO> GetMagicSetList();
}