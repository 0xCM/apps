//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public class Sym16<T> : ISym<W16,T>
        where T : unmanaged
    {
        public SymKey Key {get;}

        public SymIdentity Identity {get;}

        public Identifier Name {get;}

        public T Kind {get;}

        public SymExpr Expr {get;}

        public TextBlock Description {get;}

        public bool Hidden {get;}

        Sym16()
        {
            Identity = SymIdentity.Empty;
            Key = default;
            Name = Identifier.Empty;
            Kind = default;
            Expr = SymExpr.Empty;
            Description = TextBlock.Empty;
            Hidden = true;
        }

        [MethodImpl(Inline)]
        public Sym16(SymIdentity id, SymKey index, Identifier name, T kind, SymExpr expr, TextBlock? description = null, bool hidden = false)
        {
            Identity = id;
            Key = index;
            Name = name;
            Kind = kind;
            Expr = expr;
            Description = description ?? TextBlock.Empty;
            Hidden = hidden;
        }

        public ushort Value
        {
            [MethodImpl(Inline)]
            get => bw16(Kind);
        }

        public Identifier Type
            => typeof(T).Name;

        public string Format()
            => string.Format(Sym.RenderPattern, Key, Type, Name, Expr, Kind, Description);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Sym16(Sym16<T> src)
            => new Sym16(src.Identity, src.Key, src.Type, src.Name, bw16(src.Kind), src.Expr, src.Description, src.Hidden);

        [MethodImpl(Inline)]
        public static implicit operator Sym<T>(Sym16<T> src)
            => new Sym<T>(src.Identity, src.Key.Value, src.Name, src.Kind, src.Expr, src.Description, src.Hidden);
    }
}