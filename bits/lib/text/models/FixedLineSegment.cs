//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential, Pack=4)]
    public readonly struct FixedLineSegment
    {
        public ushort Index {get;}

        public ushort Min {get;}

        public ushort Max {get;}

        [MethodImpl(Inline)]
        public FixedLineSegment(ushort index, ushort min, ushort max)
        {
            Index = index;
            Min = min;
            Max = max;
        }

        public ushort Length
        {
            [MethodImpl(Inline)]
            get => (ushort)(Max - Min);
        }

        public string Format()
            => string.Format("[{0}:({1},{2})]", Index, Min, Max);

        public override string ToString()
            => Format();
    }

}