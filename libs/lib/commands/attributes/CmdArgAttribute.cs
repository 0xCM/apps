//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class CmdArgAttribute : Attribute
    {
        public CmdArgAttribute(string expr, object missing = null)
        {
            Expression = expr;
            Missing = missing == null ? Option.none<object>() : missing;
        }

        public CmdArgAttribute()
        {
            Expression = string.Empty;
            Missing = Option.none<object>();
        }

        public Option<object> Missing {get;}

        public string Expression {get;}

        public virtual bool IsFlag {get;}
    }
}