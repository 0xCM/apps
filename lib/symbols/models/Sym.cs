//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class Sym : ISym
    {
        public const string RenderPattern = "{0,-8} | {1,-32} | {2,-32} | {3,-32} | {4,-8:d} | {5}";

        public SymIdentity Identity {get;}

        public SymClass Class {get;}

        public SymKey Key {get;}

        public Identifier Type {get;}

        public ulong Kind {get;}

        public SymVal Value {get;}

        public string Name {get;}

        public SymExpr Expr {get;}

        public TextBlock Description {get;}

        public bool Hidden {get;}

        public object FieldValue {get;}

        public readonly DataSize Size;

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
            Value = SymVal.Zero;
            FieldValue = 0ul;
            Size = DataSize.Zero;
        }

        [MethodImpl(Inline)]
        public Sym(SymIdentity id, SymClass @class, SymKey index, string type, ulong kind, string name, string symbol, TextBlock? description, bool hidden, object value, DataSize size)
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
            Value = kind;
            FieldValue = value;
            Size = size;
        }

        public string Format()
            => string.Format(Sym.RenderPattern, Key, Type, Name, Expr, Kind, Description);

        public override string ToString()
            => Format();

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => text.empty(Name);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => text.nonempty(Name);
        }

        public static Sym Empty
        {
            [MethodImpl(Inline)]
            get => new Sym();
        }
    }
}