//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    [ApiHost]
    public partial class WinSdk : ToolService<WinSdk>
    {
        public WinSdkInfo Latest()
            => latest();
    }
}