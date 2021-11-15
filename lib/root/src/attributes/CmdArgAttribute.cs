//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class CmdArgAttribute : Attribute
    {
        public CmdArgAttribute(string expr)
        {
            Position = 0;
            Expression = expr;
        }

        public CmdArgAttribute(int pos, string expr)
        {
            Position = pos;
            Expression = expr;
        }

        public CmdArgAttribute(int pos)
        {
            Expression = string.Empty;
            Position = pos;
        }

        public CmdArgAttribute()
        {
            Position = 0;
            Expression = string.Empty;
        }

        public int Position {get;}

        public string Expression {get;}

        public virtual bool IsFlag {get;}
    }
}