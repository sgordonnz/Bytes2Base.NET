namespace Bytes2Base;

public sealed partial class Bytes2BaseEncoder
{
    public const int SourceBase = 256;
    private readonly BaseType _baseType;
    public int TargetBase => _baseType.Base;
    public string CharacterSet => _baseType.CharacterSet;

    public Bytes2BaseEncoder(BaseType baseType)
    {
        _baseType = baseType;
    }

    public string Encode(ReadOnlySpan<byte> source)
    {
        Span<byte> destination = stackalloc byte[ExpandLengthForWrite(source.Length)];
        var start = Convert(source, SourceBase, TargetBase, destination);
        Span<char> characters = stackalloc char[destination.Length - start];
        for (var i = 0; i < characters.Length; i++)
            characters[i] = CharacterSet[destination[i + start]];
        return characters.ToString();
    }

    public byte[] Decode(string encoded)
    {
        Span<byte> source = stackalloc byte[encoded.Length];
        for (var i = 0; i < encoded.Length; i++)
            source[i] = (byte)CharacterSet.IndexOf(encoded[i]);

        Span<byte> destination = stackalloc byte[encoded.Length];
        var start = Convert(source, TargetBase, SourceBase, destination);
        return destination[start..].ToArray();
    }

    private int ExpandLengthForWrite(int sourceLength)
        => (int)Math.Ceiling(sourceLength * 8 / Math.Floor(Math.Log2(TargetBase)));

    private static int Convert(ReadOnlySpan<byte> source, int sourceBase, int targetBase, Span<byte> destination)
    {
        Span<int> workingSource = stackalloc int[source.Length];
        var leadingZeros = 0;
        var foundNonZero = false;

        for (var i = 0; i < source.Length; i++)
        {
            workingSource[i] = source[i];
            if (foundNonZero) continue;
            if (workingSource[i] == 0) leadingZeros++;
            else foundNonZero = true;
        }

        var readIdx = 0;
        var writeIdx = destination.Length - 1;
        while (foundNonZero)
        {
            foundNonZero = false;
            var r = 0;
            for (var i = readIdx; i < workingSource.Length; i++)
            {
                var a = workingSource[i] + r * sourceBase;
                workingSource[i] = a / targetBase;
                r = a % targetBase;
                if (foundNonZero || workingSource[i] == 0) continue;
                foundNonZero = true;
                readIdx = i;
            }

            if (writeIdx == -1) break; // TODO throw exception
            destination[writeIdx--] = (byte)r;
            if (readIdx >= workingSource.Length) break;
        }

        return Math.Max(writeIdx - leadingZeros + 1, 0);
    }
}