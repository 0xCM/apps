//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct AppSetting
    {
        public readonly VarName Name;

        public readonly dynamic Value;

        [MethodImpl(Inline)]
        public AppSetting(VarName name, dynamic value)
        {
            Name = name;
            Value = value;
        }
    }

    public readonly struct AppSetting<V>
    {
        public readonly VarName Name;

        public readonly V Value;

        [MethodImpl(Inline)]
        public AppSetting(VarName name, V value)
        {
            Name = name;
            Value = value;
        }

    }

    /// <summary>
    /// Defines a script variable
    /// </summary>
    public struct CmdScriptVar : IVarValue<string>
    {
        /// <summary>
        /// The variable symbol
        /// </summary>
        public VarName VarName {get;}

        /// <summary>
        /// The variable value, possibly empty
        /// </summary>
        public string VarValue {get;set;}

        [MethodImpl(Inline)]
        public CmdScriptVar(VarName name, string value)
        {
            VarName = name;
            VarValue = value;
        }

        [MethodImpl(Inline)]
        public CmdScriptVar(VarName name)
        {
            VarName = name;
            VarValue = EmptyString;
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
            => string.Format(RP.pattern(vck), VarValue);

        [MethodImpl(Inline)]
        public static implicit operator CmdScriptVar((VarName symbol, string value) src)
            => new CmdScriptVar(src.symbol, src.value);
    }
}