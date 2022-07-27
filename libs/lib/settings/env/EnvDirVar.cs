//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct EnvDirVar : IEnvVar<FS.FolderPath>
    {
        public readonly Name VarName {get;}

        public readonly FS.FolderPath VarValue {get;}

        [MethodImpl(Inline)]
        public EnvDirVar(Name name, FS.FolderPath value)
        {
            VarName = name;
            VarValue = value;
        }

        public string Format()
            => ExprFormatters.format(this);

        public string Format(VarContextKind vck)
            => ExprFormatters.format(vck, this);

        [MethodImpl(Inline)]
        public static implicit operator EnvDirVar((Name symbol, FS.FolderPath value) src)
            => new EnvDirVar(src.symbol, src.value);

        [MethodImpl(Inline)]
        public static implicit operator CmdScriptVar(EnvDirVar src)
            => new EnvDirVar(src.VarName, src.VarValue);

        [MethodImpl(Inline)]
        public static implicit operator FS.FolderPath(EnvDirVar src)
            => src.VarValue;

        public static EnvDirVar Empty => new EnvDirVar(default, FS.FolderPath.Empty);
    }
}