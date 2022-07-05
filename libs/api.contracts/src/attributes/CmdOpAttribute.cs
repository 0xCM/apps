//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CmdOpAttribute : Attribute
    {
        public string CommandName {get;}

        public CmdOpAttribute(string name)
        {
            CommandName = name;
        }
    }
}