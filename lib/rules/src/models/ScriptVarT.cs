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
    public struct ScriptVar<T> : IScriptVar<T>
    {
        /// <summary>
        /// The variable symbol
        /// </summary>
        public VarSymbol Symbol {get;}

        /// <summary>
        /// The variable value, possibly empty
        /// </summary>
        public T Value {get;}

        [MethodImpl(Inline)]
        public ScriptVar(VarSymbol name, T value)
        {
            Symbol = name;
            Value = value;
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
        public static implicit operator ScriptVar<T>((VarSymbol symbol, T value) src)
            => new ScriptVar<T>(src.symbol, src.value);
    }
}