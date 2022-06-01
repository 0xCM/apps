//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Specifies the content of a <see cref='CompilationLiteral'/> at runtime
    /// </summary>
    /// <remarks>
    /// The <see cref='decimal'/> type is not supported; the <see cref='string'/> type is supported via addressing
    /// </remarks>
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct RuntimeLiteral : ITextual, IRuntimeLiteral, IComparableRecord<RuntimeLiteral>
    {
        public readonly PartId Part;

        public readonly StringAddress Group;

        public readonly StringAddress Type;

        public readonly StringAddress Name;

        public readonly ulong Data;

        public readonly ClrLiteralKind Kind;

        [MethodImpl(Inline)]
        public RuntimeLiteral(PartId part, StringAddress group, StringAddress type, StringAddress name, ulong content, ClrLiteralKind clr)
        {
            Part = part;
            Group = group;
            Type = type;
            Name = name;
            Data = content;
            Kind = clr;
        }

        public RuntimeLiteralValue<string> Value()
            => Literals.value(this);

        public string Format()
            => Literals.format(this);

        public override string ToString()
            => Format();

        public int CompareTo(RuntimeLiteral src)
            => Format().CompareTo(src.Format());

        StringAddress IRuntimeLiteral.Source
            => Type;

        StringAddress IRuntimeLiteral.Name
            => Name;

        ClrLiteralKind IKinded<ClrLiteralKind>.Kind
            => Kind;
    }
}