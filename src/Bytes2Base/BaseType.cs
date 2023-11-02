namespace Bytes2Base;

public class BaseType
{
    public static readonly BaseType Base62 = new( 62, CharacterSets.Base62 );
    public static readonly BaseType Base58 = new( 58, CharacterSets.Base58 );
    public static readonly BaseType Base36 = new( 36, CharacterSets.Base36 );

    public int Base { get; }
    public string CharacterSet { get; }
		
    private BaseType( int @base, string characterSet )
    {
        Base = @base;
        CharacterSet = characterSet;
    }
		
    public static class Inverted
    {
        public static readonly BaseType Base62 = new( 62, CharacterSets.Inverted.Base62 );
        public static readonly BaseType Base58 = new( 58, CharacterSets.Inverted.Base58 );
        public static readonly BaseType Base36 = new( 36, CharacterSets.Inverted.Base36 );
    }
}