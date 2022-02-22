//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NativeLiteral : INativeLiteral
    {
        public readonly Label Name;

        public readonly MemorySeg Source;

        [MethodImpl(Inline)]
        public NativeLiteral(Label name, MemorySeg src)
        {
            Name = name;
            Source = src;
        }

        public ReadOnlySpan<byte> Data
        {
            [MethodImpl(Inline)]
            get => Source.View;
        }

        Label INativeLiteral.Name
            => Name;

        public static implicit operator NativeLiteral((Label name, MemorySeg value) src)
            => new NativeLiteral(src.name, src.value);
    }
}