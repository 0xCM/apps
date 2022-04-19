//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    /// <summary>
    /// Identifies a concreate <see cref='ICmdSpec'/> realization
    /// </summary>
    [AttributeUsage(AttributeTargets.Struct)]
    public class CmdAttribute : Attribute
    {
        public CmdAttribute()
        {
            Name = "";
        }

        public CmdAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        /// The commoan name that serves as a contextual identifier
        /// </summary>
        public string Name {get;}
    }
}