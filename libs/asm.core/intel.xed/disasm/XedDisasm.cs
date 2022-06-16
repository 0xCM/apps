//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class XedDisasm : WfSvc<XedDisasm>
    {
        const string disasm = "xed.disasm";

        XedRuntime Xed;

        XedPaths XedPaths => Xed.Paths;

        bool PllExec
        {
            [MethodImpl(Inline)]
            get => Xed.PllExec;
        }

        public XedDisasm With(XedRuntime xed)
        {
            Xed = xed;
            return this;
        }
    }
}