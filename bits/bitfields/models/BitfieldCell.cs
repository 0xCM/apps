//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public record struct BitfieldCell<T>
        where T : unmanaged
    {
        public T Value;

        [MethodImpl(Inline)]
        public BitfieldCell(T value)
        {
            Value = value;
        }

        [MethodImpl(Inline)]
        public static implicit operator BitfieldCell<T>(T src)
            => new BitfieldCell<T>(src);
    }
}