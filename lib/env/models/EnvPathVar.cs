//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct EnvPathVar : IEnvVar<FS.FilePath>
    {
        public readonly VarSymbol Name {get;}

        public readonly FS.FilePath Value {get;}

        [MethodImpl(Inline)]
        public EnvPathVar(VarSymbol name, FS.FilePath value)
        {
            Name = name;
            Value = value;
        }

        public string Format()
            => ExprFormatters.format(this);

        public string Format(VarContextKind vck)
            => ExprFormatters.format(vck, this);

        [MethodImpl(Inline)]
        public static implicit operator EnvPathVar((VarSymbol symbol, FS.FilePath value) src)
            => new EnvPathVar(src.symbol, src.value);

        [MethodImpl(Inline)]
        public static implicit operator CmdScriptVar(EnvPathVar src)
            => new EnvPathVar(src.Name, src.Value);

        [MethodImpl(Inline)]
        public static implicit operator FS.FilePath(EnvPathVar src)
            => src.Value;
    }
}