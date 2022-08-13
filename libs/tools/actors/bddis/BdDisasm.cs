//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = ToolNames;

    partial class Tools
    {
        public sealed class BdDisasm : Tool<BdDisasm>
        {
            public BdDisasm()
                : base(N.bddisasm)
            {

            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();
        }
    }
}