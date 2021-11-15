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

    public class Sym8<T> : ISym<W8,T>
        where T : unmanaged
    {
        public SymKey Key {get;}

        public SymIdentity Identity {get;}

        public Identifier Name {get;}

        public T Kind {get;}

        public SymExpr Expr {get;}

        public TextBlock Description {get;}

        public bool Hidden {get;}

        Sym8()
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
        public Sym8(SymIdentity id, SymKey key, Identifier name, T value, SymExpr expr, TextBlock? description = null, bool hidden = false)
        {
            Identity = id;
            Key = key;
            Name = name;
            Kind = value;
            Expr = expr;
            Description = description ?? TextBlock.Empty;
            Hidden = hidden;
        }

        public Identifier Type
            => typeof(T).Name;

        public byte Value
        {
            [MethodImpl(Inline)]
            get => bw8(Kind);
        }
        public string Format()
            => string.Format(Sym.RenderPattern, Key, Type, Name, Expr, Kind, Description);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Sym8(Sym8<T> src)
            => new Sym8(src.Identity, src.Key, src.Type, src.Name, bw8(src.Kind), src.Expr, src.Description, src.Hidden);

        [MethodImpl(Inline)]
        public static implicit operator Sym<T>(Sym8<T> src)
            => new Sym<T>(src.Identity, src.Key.Value, src.Name, src.Kind, src.Expr, src.Description, src.Hidden);
    }
}