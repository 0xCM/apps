//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public record struct LayoutVector
        {
            readonly SegRef<LayoutComponent> Components;

            [MethodImpl(Inline)]
            public LayoutVector(SegRef<LayoutComponent> src)
            {
                Components = src;
            }
        }

        public class LayoutVectors : IDisposable
        {
            readonly NativeCells<LayoutVector> Data;

            public LayoutVectors(NativeCells<LayoutVector> src)
            {
                Data = src;
            }

            public void Dispose()
            {

            }
        }
    }
}