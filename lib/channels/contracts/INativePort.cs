//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Flows;

    [Free]
    public interface INativePort
    {
        ReadOnlySpan<NativeChannel> Inputs {get;}

        ReadOnlySpan<NativeChannel> Outputs {get;}
    }
}