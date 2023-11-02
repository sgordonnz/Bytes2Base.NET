namespace Bytes2Base;

public static class CharacterSets
{
    public const string Base62 = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
    public const string Base58 = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";
    public const string Base36 = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public static class Inverted
    {
        public const string Base62 = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string Base58 = "123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ";
        public const string Base36 = "0123456789abcdefghijklmnopqrstuvwxyz";
    }
}