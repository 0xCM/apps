//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct EnvPathVar : IEnvVar<FS.FilePath>
    {
        public VarSymbol Symbol {get;}

        public FS.FilePath Value {get;}

        [MethodImpl(Inline)]
        public EnvPathVar(VarSymbol name, FS.FilePath value)
        {
            Symbol = name;
            Value = value;
        }

        public string Format()
            => RuleModels.format(this);

        public string Format(VarContextKind vck)
            => RuleModels.format(vck, this);

        [MethodImpl(Inline)]
        public static implicit operator EnvPathVar((VarSymbol symbol, FS.FilePath value) src)
            => new EnvPathVar(src.symbol, src.value);

        [MethodImpl(Inline)]
        public static implicit operator ScriptVar(EnvPathVar src)
            => new EnvPathVar(src.Symbol, src.Value);

        [MethodImpl(Inline)]
        public static implicit operator FS.FilePath(EnvPathVar src)
            => src.Value;
    }
}