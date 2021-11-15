//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class Sym : ISym
    {
        public const string RenderPattern = "{0,-8} | {1,-32} | {2,-32} | {3,-32} | {4,-8:d} | {5}";

        public SymIdentity Identity {get;}

        public SymClass Class {get;}

        public SymKey Key {get;}

        public Identifier Type {get;}

        public ulong Kind {get;}

        public Identifier Name {get;}

        public SymExpr Expr {get;}

        public TextBlock Description {get;}

        public bool Hidden {get;}

        Sym()
        {
            Identity = SymIdentity.Empty;
            Key = default;
            Class = SymClass.Empty;
            Name = Identifier.Empty;
            Kind = default;
            Expr = SymExpr.Empty;
            Description = TextBlock.Empty;
            Hidden = true;
        }

        [MethodImpl(Inline)]
        public Sym(SymIdentity id, SymClass @class, SymKey index, Identifier type, ulong kind, Identifier name, SymExpr symbol, TextBlock? description = null, bool hidden = false)
        {
            Identity = id;
            Class = @class;
            Key = index;
            Type = type;
            Kind = kind;
            Name = name;
            Expr = symbol;
            Description = description ?? TextBlock.Empty;
            Hidden = hidden;
        }

        public ulong Value
        {
            [MethodImpl(Inline)]
            get => Kind;
        }

        public string Format()
            => string.Format(Sym.RenderPattern, Key, Type, Name, Expr, Kind, Description);

        public override string ToString()
            => Format();

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsNonEmpty;
        }

        public static Sym Empty
        {
            [MethodImpl(Inline)]
            get => new Sym();
        }
    }
}