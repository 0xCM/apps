//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct EnvDirVar : IEnvVar<FS.FolderPath>
    {
        public readonly VarSymbol Name {get;}

        public readonly FS.FolderPath Value {get;}

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

        public static EnvDirVar Empty => new EnvDirVar(VarSymbol.Empty, FS.FolderPath.Empty);
    }
}