//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CliHeapKey : ICliHeapKey<CliHeapKey>
    {
        public readonly CliHeapKind HeapKind {get;}

        public readonly uint Value {get;}

        [MethodImpl(Inline)]
        public CliHeapKey(CliHeapKind heap, uint value)
        {
            HeapKind = heap;
            Value = value;
        }
    }
}