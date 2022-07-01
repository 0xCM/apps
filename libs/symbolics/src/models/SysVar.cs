//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class SysVar : SysVar<SysVar, Name, @string>
    {
        public SysVar(Name name)
            : base(name)
        {
        }

        public SysVar(Name name, string value)
            : base(name,value)
        {

        }
    }
}