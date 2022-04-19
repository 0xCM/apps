//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    /// <summary>
    /// Identifies a tool
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class ToolAttribute : Attribute
    {

        public ToolId Id {get;}

        public ToolAttribute(string id)
        {
            Id = id;
        }
    }
}