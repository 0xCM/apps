//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines a script variable
    /// </summary>
    public struct CmdScriptVar : ICmdScriptVar
    {
        /// <summary>
        /// The variable symbol
        /// </summary>
        public VarSymbol Symbol {get;}

        /// <summary>
        /// The variable value, possibly empty
        /// </summary>
        public string Value {get;set;}

        [MethodImpl(Inline)]
        public CmdScriptVar(VarSymbol name, string value)
        {
            Symbol = name;
            Value = value;
        }

        [MethodImpl(Inline)]
        public CmdScriptVar(VarSymbol name)
        {
            Symbol = name;
            Value = EmptyString;
        }

        [MethodImpl(Inline)]
        public string Format()
            => ExprFormatters.format(this);

        [MethodImpl(Inline)]
        public string Format(VarContextKind vck)
            => ExprFormatters.format(vck, this);

        public override string ToString()
            => Format();

        public string Resolve(VarContextKind vck)
            => string.Format(RP.pattern(vck), Value);

        [MethodImpl(Inline)]
        public static implicit operator CmdScriptVar((VarSymbol symbol, string value) src)
            => new CmdScriptVar(src.symbol, src.value);
    }
}