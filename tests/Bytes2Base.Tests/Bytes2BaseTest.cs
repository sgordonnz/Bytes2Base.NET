namespace Bytes2Base.Tests;

public class Bytes2BaseTest
{
    private static readonly byte[] TestBytes =
    {
        199, 181, 60, 79, 25, 93, 77, 47, 222, 11, 27, 154, 61, 148, 114, 246, 11, 226, 150, 23, 43, 249, 121, 112,
        241, 103, 157, 41, 162, 6, 110, 224,
    };

    [Fact]
    public void EncodeDecodeBase62()
    {
        var encoded = Bytes2BaseEncoder.Base62.Encode(TestBytes);
        var decoded = Bytes2BaseEncoder.Base62.Decode(encoded);
        Assert.Equal(TestBytes, decoded);
    }

    [Fact]
    public void EncodeDecodeBase58()
    {
        var bytes = new byte[64];
        var encoded = Bytes2BaseEncoder.Base58.Encode(TestBytes);
        var decoded = Bytes2BaseEncoder.Base58.Decode(encoded);
        Assert.Equal(TestBytes, decoded);
    }

    [Fact]
    public void EncodeDecodeBase36()
    {
        var encoded = Bytes2BaseEncoder.Base36.Encode(TestBytes);
        var decoded = Bytes2BaseEncoder.Base36.Decode(encoded);
        Assert.Equal(TestBytes, decoded);
    }
}