//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class SysVar : SysVar<SysVar, VarName, @string>
    {
        public SysVar(VarName name)
            : base(name)
        {
        }

        public SysVar(VarName name, string value)
            : base(name,value)
        {

        }
    }
}