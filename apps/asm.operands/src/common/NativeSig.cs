//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NativeSig
    {
        public readonly text31 Name;

        readonly ByteBlock32 OpData;

        public readonly NativeCellType ReturnType;

        public ref readonly byte OperandCount
        {
            [MethodImpl(Inline)]
            get => ref OpData[31];
        }
    }
}

