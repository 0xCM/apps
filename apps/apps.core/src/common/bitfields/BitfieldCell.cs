//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public record struct BitfieldCell<T>
        where T : unmanaged
    {
        public readonly BitfieldInterval Interval;

        public T Value;

        [MethodImpl(Inline)]
        public BitfieldCell(BitfieldInterval a, T value)
        {
            Interval = a;
            Value = value;
        }

        public string Format()
            => BitfieldMechanics.format(this);

        public override string ToString()
            => Format();
    }
}