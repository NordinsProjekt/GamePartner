using RazorSharedLib.Api;

namespace RazorSharedLib.States.Buffer;

public class MagicBufferState : IMagicBufferState
{
    private bool _isInitialized;

    private List<MtGSetRecordDTO> _magicSetRecords;

    public MagicBufferState()
    {
        _magicSetRecords = new List<MtGSetRecordDTO>();
    }

    public async Task InitializeAsync(ApiClient client)
    {
        if (!_isInitialized)
        {
            var magicset = await client.GetSetListAsync(CancellationToken.None);
            _magicSetRecords = magicset.Sets.ToList();

            _isInitialized = true;
        }
    }

    public List<MtGSetRecordDTO> GetMagicSetList()
    {
        return _magicSetRecords.ToList();
    }
}