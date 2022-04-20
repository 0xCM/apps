//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static core;

    partial struct XedModels
    {
        public readonly record struct FormSyntaxPart : IEquatable<FormSyntaxPart>, IComparable<FormSyntaxPart>
        {
            public readonly asci16 Name;

            [MethodImpl(Inline)]
            public FormSyntaxPart(asci16 name)
            {
                Name = name;
            }

            [MethodImpl(Inline)]
            public int CompareTo(FormSyntaxPart src)
                => Name.CompareTo(src.Name);

            [MethodImpl(Inline)]
            public bool Equals(FormSyntaxPart src)
                => Name.Equals(src.Name);

            public override int GetHashCode()
                => Name.GetHashCode();

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator FormSyntaxPart(asci16 name)
                => new FormSyntaxPart(name);
        }

        [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
        public record struct FormSyntax
        {
            static Index<string> SubParts = new string[]{"AVX", "GPR", "IMM", "MASK", "PTR", "MEM", "MMX", "Oe", "Or", "RELBR", "REP", "REPE", "TMM", "VGPR", "VL", "XMM", "YMM", "ZMM", };

            static HashSet<string> Ignore = hashset<string>(
                "INSB", "INSD", "INSQ",
                "CMPSB", "CMPSD", "CMPSQ", "CMPSW",
                "LODSB", "LODSD", "LODSQ", "LODSW",
                "MOVSB", "MOVSD", "MOVSQ", "MOVSW",
                "STOSB", "STOSD", "STOSQ", "STOSW",
                "OUTSB", "OUTSD", "OUTSQ", "OUTSW",
                "SCASB", "SCASD", "SCASQ", "SCASW",
                "XCRYPTCBC", "XCRYPTCFB", "XCRYPTCTR", "XCRYPTECB", "XCRYPTOFB",
                "XSHA1","XSHA256", "XSTORE"
                );

            public static Index<FormSyntaxPart> parts()
            {
                var src = Symbols.index<IFormType>().Kinds;
                var dst = hashset<string>();
                iter(SubParts,  sp => dst.Add(sp));
                for(var i=1; i<src.Length; i++)
                {
                    ref readonly var form = ref skip(src,i);
                    var parts = text.split(form.ToString(), Chars.Underscore);
                    for(var j=1; j<parts.Length; j++)
                    {
                        ref readonly var part = ref skip(parts,j);
                        if(Ignore.Contains(part))
                            continue;

                        var length = part.Length;
                        var subparted = false;
                        for(var k=0; k<SubParts.Count; k++)
                        {
                            ref readonly var subpart = ref SubParts[k];
                            if(part.StartsWith(subpart))
                            {
                                var remainder = part.Remove(subpart);
                                if(text.nonempty(remainder))
                                    dst.Add(remainder);
                                subparted = true;
                                break;
                            }

                        }

                        if(!subparted)
                            dst.Add(part);
                    }
                }

                return dst.Array().Sort().Select(x => new FormSyntaxPart(x));
            }

            public const string TableId = "xed.iform.syntax";

            public InstForm Form;

            public InstClass Class;

            public LockIndicator Lock;

            public static FormSyntax Empty => default;
        }

        public static FormSyntax syntax(InstForm src)
        {
            var dst = FormSyntax.Empty;
            var parts = text.split(src.Format(), Chars.Underscore);
            for(var i=0; i<parts.Length; i++)
            {
                ref readonly var part = ref skip(parts,i);
            }
            return dst;
        }
    }
}