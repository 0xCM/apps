//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class XedDisasm : AppService<XedDisasm>
    {
        XedRuntime Xed;

        public XedDisasm With(XedRuntime xed)
        {
            Xed = xed;

            return this;
        }

        XedPaths XedPaths => Xed.Paths;
    }
}