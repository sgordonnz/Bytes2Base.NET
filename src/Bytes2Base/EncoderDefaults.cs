namespace Bytes2Base;

public partial class Bytes2BaseEncoder
{
    public static readonly Bytes2BaseEncoder Base62 = new(BaseType.Base62);
    public static readonly Bytes2BaseEncoder Base58 = new(BaseType.Base58);
    public static readonly Bytes2BaseEncoder Base36 = new(BaseType.Base36);

    public static class Inverted
    {
        public static readonly Bytes2BaseEncoder Base62 = new(BaseType.Inverted.Base62);
        public static readonly Bytes2BaseEncoder Base58 = new(BaseType.Inverted.Base58);
        public static readonly Bytes2BaseEncoder Base36 = new(BaseType.Inverted.Base36);
    }
}