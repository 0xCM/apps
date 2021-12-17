//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct VarSymbol : IVarSymbol
    {
        public Name Name {get;}

        [Op]
        public static string format(IExprVar var, char assign)
            => string.Format("{0}{1}{2}", format(var.Symbol), assign, var.Value);

        [Op]
        public static string format(IExprVar var)
            => format(var, Chars.Eq);

        [Op]
        public static string format(VarContextKind vck, IExprVar var, char assign)
            => string.Format("{0}{1}{2}", format(vck, var.Symbol), assign, var.Value);

        [Op]
        public static string format(VarSymbol src)
            => format(VarContextKind.Workflow, src);

        public static string format<T>(VarSymbol<T> src)
            => format(VarContextKind.Workflow, src);

        public static string format<T>(VarContextKind vck, VarSymbol<T> src)
            => string.Format(RP.pattern(vck), src.Name);

        [Op]
        public static string format(VarContextKind vck, VarSymbol src)
            => string.Format(RP.pattern(vck), src.Name);

        [Op]
        public static string format(VarContextKind vck, IExprVar var)
            => format(vck,var, Chars.Eq);

        [MethodImpl(Inline)]
        public VarSymbol(string name)
            => Name = name;

        [MethodImpl(Inline)]
        public VarSymbol(char name)
            => Name = name.ToString();

        public string Format()
            => Format(VarContextKind.Workflow);

        public string Format(VarContextKind vck)
            => string.Format(RP.pattern(vck), Name);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator VarSymbol(string name)
            => new VarSymbol(name);

        [MethodImpl(Inline)]
        public static implicit operator VarSymbol(char name)
            => new VarSymbol(name);
    }
}