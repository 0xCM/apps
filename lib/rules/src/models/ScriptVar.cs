//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using api = RuleModels;

    /// <summary>
    /// Defines a script variable
    /// </summary>
    public struct ScriptVar : IScriptVar
    {
        /// <summary>
        /// The variable symbol
        /// </summary>
        public VarSymbol Symbol {get;}

        /// <summary>
        /// The variable value, possibly empty
        /// </summary>
        public string Value {get;}

        [MethodImpl(Inline)]
        public ScriptVar(VarSymbol name, string value)
        {
            Symbol = name;
            Value = value;
        }

        [MethodImpl(Inline)]
        public ScriptVar(VarSymbol name)
        {
            Symbol = name;
            Value = EmptyString;
        }

        [MethodImpl(Inline)]
        public string Format()
            => api.format(this);

        [MethodImpl(Inline)]
        public string Format(VarContextKind vck)
            => api.format(vck, this);

        public override string ToString()
            => Format();

        public string Resolve(VarContextKind vck)
            => api.resolve(vck, this);

        [MethodImpl(Inline)]
        public static implicit operator ScriptVar((VarSymbol symbol, string value) src)
            => new ScriptVar(src.symbol, src.value);
    }
}