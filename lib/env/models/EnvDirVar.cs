//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct EnvDirVar : IEnvVar<FS.FolderPath>
    {
        public VarSymbol Name {get;}

        public FS.FolderPath Value {get;}

        [MethodImpl(Inline)]
        public EnvDirVar(VarSymbol name, FS.FolderPath value)
        {
            Name = name;
            Value = value;
        }

        public string Format()
            => ExprFormatters.format(this);

        public string Format(VarContextKind vck)
            => ExprFormatters.format(vck, this);

        [MethodImpl(Inline)]
        public static implicit operator EnvDirVar((VarSymbol symbol, FS.FolderPath value) src)
            => new EnvDirVar(src.symbol, src.value);

        [MethodImpl(Inline)]
        public static implicit operator CmdScriptVar(EnvDirVar src)
            => new EnvDirVar(src.Name, src.Value);

        [MethodImpl(Inline)]
        public static implicit operator FS.FolderPath(EnvDirVar src)
            => src.Value;
    }
}