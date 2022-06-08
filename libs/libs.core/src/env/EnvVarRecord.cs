//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public struct EnvVarRecord
    {
        const string TableId = "env.vars";

        [Render(64)]
        public VarSymbol Name;

        [Render(1)]
        public string Value;

        [MethodImpl(Inline)]
        public EnvVarRecord(VarSymbol name, string value)
        {
            Name = name;
            Value = value;
        }

        public EnvVar Source
        {
            [MethodImpl(Inline)]
            get => new EnvVar(Name,Value);
        }
    }
}