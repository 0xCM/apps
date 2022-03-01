//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static XedModels;
    using static core;

    partial class XedRules
    {
        OpCodeKinds EmitOpCodeKinds()
        {
            var src = CalcOpCodeKinds();
            TableEmit(src.Records, OcMapKind.RenderWidths, XedPaths.DocTarget(XedDocKind.OpCodeKinds));
            return src;
        }
    }
}