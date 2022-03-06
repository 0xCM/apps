//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public class CallResolvers : NameResolver<CallResolvers, NameResolver> { }

        public class CallResolver : NameResolver<CallResolver>
        {
            public CallResolver()
                : base(-1)
            {

            }

            public CallResolver(int id)
                : base(id)
            {


            }

            public override string Format()
                => string.Format("{0}()", Name);
        }
    }
}