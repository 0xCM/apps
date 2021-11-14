//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class IntelSdm
    {
        public Outcome EmitSdmSplits()
            => DocServices.Split(SdmPaths.SplitSpecs());
    }
}