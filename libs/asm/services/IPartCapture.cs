//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IPartCapture
    {

        Index<CollectedEncoding> Capture(IApiCatalog src, ICompositeDispenser dispenser, bool pll);
    }
}