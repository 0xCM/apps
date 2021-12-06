//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
[assembly: PartId(PartId.AsmCases)]
namespace Z0.Parts
{
    public sealed class AsmCases : Part<AsmCases>
    {
        public static AsmCaseAssets Assets => new AsmCaseAssets();
    }
}

namespace Z0
{
    [ApiHost]
    public static partial class XTend
    {

    }

    [ApiComplete]
    partial struct Msg
    {

    }
}