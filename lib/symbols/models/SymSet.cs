//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    /// <summary>
    /// Defines a collection of symbols
    /// </summary>
    public class SymSet
    {
        public static SymSet create(uint count)
            => new SymSet(count);

        internal SymSet(uint count)
        {
            Symbols = alloc<SymExpr>(count);
            Names = alloc<Identifier>(count);
            Values = alloc<SymVal>(count);
            Descriptions = alloc<string>(count);
            Name = Identifier.Empty;
            Description = TextBlock.Empty;
        }

        public Identifier Name;

        public ClrEnumKind DataType;

        public bool Flags;

        public Identifier SymbolKind;

        public TextBlock Description;

        public Index<Identifier> Names {get;}

        public Index<SymVal> Values {get;}

        public Index<SymExpr> Symbols {get;}

        public Index<string> Descriptions {get;}
    }
}