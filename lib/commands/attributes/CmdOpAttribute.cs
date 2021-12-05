//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [AttributeUsage(AttributeTargets.Method)]
    public class CmdOpAttribute : Attribute
    {
        public string CommandName {get;}

        public string Description {get;}

        public CmdOpAttribute(string name)
        {
            CommandName = name;
            Description = string.Empty;
        }

        public CmdOpAttribute(string name, string description)
        {
            CommandName = name;
            Description = description;
        }
    }
}