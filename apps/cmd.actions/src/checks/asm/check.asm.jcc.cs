//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    public readonly struct AsmAddressLabel
    {
        public static bool perhaps(string src)
        {
            var input = text.trim(src);
            return text.nonempty(input) && text.begins(input, Chars.Underscore) && text.ends(input, Chars.Colon);
        }

        public static bool parse(string src, out AsmAddressLabel dst)
        {
            var input = text.trim(src);
            dst = Empty;
            var result = false;
            if(perhaps(input))
            {
                var i = text.index(input, Chars.Amp);
                var j = text.index(input, Chars.Colon);
                if(DataParser.parse(text.inside(input, i, j), out MemoryAddress address))
                {
                    dst = address;
                    result = true;
                }
            }
            return result;
        }

        public readonly MemoryAddress Address;

        [MethodImpl(Inline)]
        public AsmAddressLabel(MemoryAddress address)
        {
            Address = address;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Address == ulong.MaxValue;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public string Format()
            => string.Format("_@{0}:", Address);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmAddressLabel(MemoryAddress src)
            => new AsmAddressLabel(src);

        [MethodImpl(Inline)]
        public static implicit operator MemoryAddress(AsmAddressLabel src)
            => src.Address;

        public static AsmAddressLabel Empty => new AsmAddressLabel(ulong.MaxValue);
    }

    partial class CheckCmdProvider
    {
        [CmdOp("check/asm/jcc")]
        Outcome CheckJcc(CmdArgs args)
        {
            var @case = AsmCaseAssets.create().Branches();
            Utf8.decode(@case.ResBytes, out var doc);
            using var symbols = SymbolDispenser.alloc();
            using var sources = SourceDispenser.alloc();

            // _@7ffb67de1520:

            var @base = AsmAddressLabel.Empty;
            var offset = z16;

            Lines.traverse(doc, line => {

                var content = line.Content;
                if(!text.begins(content, Chars.Hash))
                {
                    if(AsmAddressLabel.perhaps(content))
                    {
                        if(AsmAddressLabel.parse(content, out @base))
                        {

                            symbols.Dispense(@base, content);
                        }

                    }
                }

            });

            return true;
        }

    }
}