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
        public static string format(in RuntimeLiteral src)
            => string.Format("{0,-16} | {1,-16} | {2,-12} | {3}", src.Source, src.Name, src.Kind, value(src));

        [Op]
        public static RuntimeLiteralValue<string> value(in RuntimeLiteral src)
        {
            var value = EmptyString;
            if(src.Kind == ClrLiteralKind.String)
                value = ((StringAddress)src.Data).Format();
            else
                value = src.Data.ToString();
            return new RuntimeLiteralValue<string>(value);
        }

        [Op]
        public static CompilationLiteral specify(in RuntimeLiteral src)
        {
            var dst = default(CompilationLiteral);
            dst.Source = src.Source.Format();
            dst.Name = src.Name.Format();
            dst.Kind = src.Kind.ToString();
            dst.Value = src.Value();
            dst.Length = (uint)dst.Value.Data.Length;
            return dst;
        }

        public const string TableName = "literals.runtime";

        public readonly StringAddress Source;

        public readonly StringAddress Name;

        public readonly ulong Data;

        public readonly ClrLiteralKind Kind;

        [MethodImpl(Inline)]
        public RuntimeLiteral(StringAddress source, StringAddress name, ulong content, ClrLiteralKind clr)
        {
            Source = source;
            Name = name;
            Data = content;
            Kind = clr;
        }


        public RuntimeLiteralValue<string> Value()
            => value(this);

        public CompilationLiteral Specify()
            => specify(this);

        public string Format()
            => format(this);

        public override string ToString()
            => Format();

        public int CompareTo(RuntimeLiteral src)
            => Format().CompareTo(src.Format());

        StringAddress IRuntimeLiteral.Source
            => Source;

        StringAddress IRuntimeLiteral.Name
            => Name;

        ClrLiteralKind IKinded<ClrLiteralKind>.Kind
            => Kind;
    }
}