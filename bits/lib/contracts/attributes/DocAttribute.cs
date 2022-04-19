//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    /// <summary>
    /// Describes anything, or at least something
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class DocAttribute : Attribute
    {
        public string Content {get;}

        public DocAttribute(string info)
        {
            Content = info;
        }
    }
}