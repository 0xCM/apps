//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct DataParser
    {
        public static MsgPattern<NameOld,string> ParseFailure => "Parse failure {0}:{1}";

        public static Outcome asci<S,N>(string src, N n, out S dst)
            where S : struct, IAsciSeq<S,N>
            where N : unmanaged, ITypeNat
                => AsciG.parse(src, n, out dst);

        public static bool parse(string src, out DataSize dst)
            => Sizes.parse(src, out dst);

        public static bool parse(string src, out uint1 dst)
            => uint1.parse(src, out dst);

        public static bool parse(string src, out uint2 dst)
            => uint2.parse(src, out dst);

        public static bool parse(string src, out uint3 dst)
            => uint3.parse(src, out dst);

        public static bool parse(string src, out uint4 dst)
            => uint4.parse(src, out dst);

        public static bool parse(string src, out uint5 dst)
            => uint5.parse(src, out dst);

        public static bool parse(string src, out uint6 dst)
            => uint6.parse(src, out dst);

        public static bool parse(string src, out uint7 dst)
            => uint7.parse(src, out dst);

        public static bool parse(string src, out uint8b dst)
            => uint8b.parse(src, out dst);

        public static Outcome parse(string src, out Hex1 dst)
            => Hex1.parse(src, out dst);

        public static Outcome parse(string src, out Hex2 dst)
            => Hex2.parse(src, out dst);

        public static Outcome parse(string src, out Hex3 dst)
            => Hex3.parse(src, out dst);

        public static Outcome parse(string src, out Hex4 dst)
            => Hex4.parse(src, out dst);

        public static Outcome parse(string src, out Hex5 dst)
            => Hex5.parse(src, out dst);

        public static Outcome parse(string src, out Hex6 dst)
            => Hex6.parse(src, out dst);

        public static Outcome parse(string src, out Hex7 dst)
            => Hex7.parse(src, out dst);

        public static Outcome parse(string src, out Hex8 dst)
            => Hex8.parse(src, out dst);

        public static Outcome parse(string src, out Hex16 dst)
            => Hex16.parse(src, out dst);

        public static Outcome parse(string src, out Hex32 dst)
            => Hex32.parse(src, out dst);

        public static Outcome parse(string src, out Hex64 dst)
            => Hex64.parse(src, out dst);

        public static Outcome parse(ReadOnlySpan<char> src, out Hex8 dst)
            => Hex8.parse(src, out dst);

        public static Outcome parse(ReadOnlySpan<char> src, out Hex16 dst)
            => Hex16.parse(src, out dst);

        public static Outcome parse(ReadOnlySpan<char> src, out Hex32 dst)
            => Hex32.parse(src, out dst);

        public static Outcome parse(ReadOnlySpan<char> src, out Hex64 dst)
            => Hex64.parse(src, out dst);

        [Parser]
        public static Outcome parse(string src, out Hash8 dst)
            => Hash.parse(src, out dst);

        [Parser]
        public static Outcome parse(string src, out Hash16 dst)
            => Hash.parse(src, out dst);

        [Parser]
        public static Outcome parse(string src, out Hash32 dst)
            => Hash.parse(src, out dst);

        [Parser]
        public static Outcome parse(string src, out Hash64 dst)
            => Hash.parse(src, out dst);

        public static Outcome parse(string src, out SymKey dst)
            => SymKey.parse(src, out dst);

        public static Outcome parse(string src, out SymVal dst)
            => SymVal.parse(src, out dst);

        public static Outcome parse(string src, out SymClass dst)
            => SymClass.parse(src, out dst);

        public static Outcome parse(string src, out LineNumber dst)
            => LineNumber.parse(src, out dst);

        public static Outcome parse(string src, out MemoryAddress dst)
            => AddressParser.parse(src, out dst);

        public static Outcome parse(string src, out Address64 dst)
            => AddressParser.parse(src, out dst);

        public static Outcome parse(string src, out Address32 dst)
            => AddressParser.parse(src, out dst);

        public static Outcome parse(string src, out Address16 dst)
            => AddressParser.parse(src, out dst);

        public static Outcome parse(string src, out Address8 dst)
            => AddressParser.parse(src, out dst);

        public static Outcome eparse<T>(string src, out T dst)
            where T : unmanaged
                => Enums.parse(src, out dst);

        public static Outcome parse(string src, out ByteSize dst)
            => Sizes.parse(src, out dst);

        public static Outcome parse(string src, out BitWidth dst)
            => Sizes.parse(src, out dst);

        public static Outcome parse<T>(string src, out Size<T> dst)
            where T : unmanaged
                => Sizes.parse(src, out dst);

        public static Outcome parse(string src, out SymExpr dst)
            => SymExpr.parse(src, out dst);


        [Parser]
        public static Outcome parse(string src, out char dst)
        {
            if(text.nonempty(src))
            {
                if(src.Length == 1)
                {
                    dst = src[0];
                    return true;
                }
            }
            dst = AsciNull.Literal;
            return false;
        }

        [Parser]
        public static Outcome parse(string src, out string dst)
        {
            dst = src ?? EmptyString;
            return true;
        }

        [Parser]
        public static Outcome parse(string src, out @string dst)
        {
            dst = src ?? EmptyString;
            return true;
        }

        [Parser]
        public static Outcome parse(string src, out text7 dst)
        {
            dst = src ?? EmptyString;
            return true;
        }

        [Parser]
        public static Outcome parse(string src, out text15 dst)
        {
            dst = src ?? EmptyString;
            return true;
        }

        [Parser]
        public static Outcome parse(string src, out text31 dst)
        {
            dst = src ?? EmptyString;
            return true;
        }

        [Parser]
        public static Outcome parse(string src, out text47 dst)
        {
            dst = src ?? EmptyString;
            return true;
        }

        [Parser]
        public static Outcome parse(string src, out byte dst)
            => NumericParser.parse(src, out dst);

        [Parser]
        public static Outcome parse(string src, out sbyte dst)
            => NumericParser.parse(src, out dst);

        [Parser]
        public static Outcome parse(string src, out short dst)
            => NumericParser.parse(src, out dst);

        [Parser]
        public static Outcome parse(string src, out ushort dst)
            => NumericParser.parse(src, out dst);

        [Parser]
        public static Outcome parse(string src, out int dst)
            => NumericParser.parse(src, out dst);

        [Parser]
        public static Outcome parse(string src, out uint dst)
            => NumericParser.parse(src, out dst);

        [Parser]
        public static Outcome parse(string src, out long dst)
            => NumericParser.parse(src, out dst);

        [Parser]
        public static Outcome parse(string src, out ulong dst)
            => NumericParser.parse(src, out dst);

        [Parser]
        public static Outcome parse(string src, out float dst)
            => NumericParser.parse(src, out dst);

        [Parser]
        public static Outcome parse(string src, out double dst)
            => NumericParser.parse(src, out dst);

        [Parser]
        public static Outcome parse(string src, out bool dst)
        {
            dst = default;
            var result = BitParser.semantic(src, out var b);
            if(result)
                dst = b;
            return result;
        }

        public static Outcome parse(string src, out bit dst)
            => BitParser.parse(src, out dst);

        [Parser]
        public static Outcome numeric<T>(string src, out T dst)
            => NumericParser.parse(src, out dst);

        public static Outcome parse(string src, out Timestamp dst)
            => Time.parse(src,out dst);

        [Parser]
        public static Outcome parse(string src, out DateTime dst)
            => DateTime.TryParse(src, out dst);

        [Parser]
        public static Outcome parse(string src, out NameOld dst)
        {
            dst = text.trim(src ?? EmptyString);
            return true;
        }

        [Parser]
        public static Outcome parse(string src, out utf8 dst)
        {
            dst = src ?? utf8.Empty;
            return true;
        }

        [Parser]
        public static Outcome parse(string src, out Identifier dst)
        {
            dst = text.trim(src ?? EmptyString);
            return true;
        }

        [Parser]
        public static Outcome parse(string src, out SymIdentity dst)
        {
            dst = text.trim(src ?? EmptyString);
            return true;
        }

        [Parser]
        public static Outcome parse(string src, out TextBlock dst)
        {
            dst = src ?? EmptyString;
            return true;
        }

        [Parser]
        public static Outcome parse(string src, out ClrMemberName dst)
        {
            dst = Clr.membername(src);
            return true;
        }

        [Parser]
        public static Outcome parse(string src, out FS.FileName dst)
        {
            dst = FS.file(src);
            return true;
        }

        [Parser]
        public static Outcome parse(string src, out FS.FolderPath dst)
        {
            dst = FS.dir(src);
            return true;
        }

        [Parser]
        public static Outcome parse(string src, out FS.FilePath dst)
        {
            dst = FS.path(src);
            return true;
        }

        [Parser]
        public static Outcome parse(string src, out FS.FileExt dst)
        {
            dst = FS.ext(src);
            return true;
        }

        [Parser]
        public static Outcome parse(string src, out FS.FileUri dst)
        {
            dst = FS.path(src);
            return true;
        }

        [Parser]
        public static Outcome parse(string src, out BinaryCode dst)
        {
            var result = HexParser.hexdata(src, out var data);
            if(result)
            {
                dst = data;
                return result;
            }
            else
            {
                dst = BinaryCode.Empty;
                return (false, Msg.ParsingBytesFailed.Format(src));
            }
        }

        [Parser]
        public static Outcome parse(string src, out byte[] dst)
        {
            var result = HexParser.hexdata(src, out var data);
            if(result)
            {
                dst = data;
                return result;
            }
            else
            {
                dst = sys.empty<byte>();
                return result;
            }
        }

        public static Outcome parse(string src, out OpUri dst)
            => ApiUri.parse(src, out dst);

        public static Outcome parse(string src, out CliToken dst)
            => Clr.token(src, out dst);

        public static Outcome parse(string src, out MemoryRange dst)
            => AddressParser.range(src, out dst);

        [Parser]
        public static Outcome parse(string src, out ToolIdOld dst)
        {
            dst = src;
            return true;
        }

        [Parser]
        public static Outcome block<T>(string src, out T block)
            where T : unmanaged, ICharBlock<T>
        {
            CharBlocks.init(src, out block);
            return true;
        }

        public static Outcome numeric(string src, Type type, out dynamic dst)
            => Numeric.parse(src, type, out dst);

        public static Outcome parse(string s, out GridDim dst)
            => GridDim.parse(s, out dst);

        // public static Outcome setting(string src, Type type, out Setting dst, char delimiter = Chars.Colon)
        //     => Settings.parse(src,type, out dst, delimiter);

        // public static Outcome setting<T>(string src, out Setting<T> dst, char delimiter = Chars.Colon)
        //     => Settings.parse(src, out dst, delimiter);
     }

     partial struct Msg
     {
         public static MsgPattern<string> ParsingBytesFailed => "Parsing bytes from {0} failed";
     }
}