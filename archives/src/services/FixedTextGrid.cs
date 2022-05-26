//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public ref struct FixedTextGrid
    {
        readonly ReadOnlySpan<char> Data;

        public readonly uint RowWidth;

        public readonly uint RowCount;

        public FixedTextGrid(uint width, ReadOnlySpan<char> data)
        {
            Data = data;
            RowWidth = width;
            Require.invariant(data.Length % width == 0);
            RowCount = (uint)data.Length % width;
        }

        [MethodImpl(Inline)]
        public ReadOnlySpan<char> Row(uint index)
            => index < RowCount ? slice(Data,index*RowWidth,RowWidth) : default;

        public ReadOnlySpan<char> this[int index]
        {
            [MethodImpl(Inline)]
            get => Row((uint)index);
        }

        public ReadOnlySpan<char> this[uint index]
        {
            [MethodImpl(Inline)]
            get => Row(index);
        }

        public void Render(ITextEmitter dst)
        {
            for(var i=0u; i<RowCount; i++)
                dst.AppendLine(new string(Row(i)));
        }

        public string Format()
        {
            var dst = text.emitter();
            Render(dst);
            return dst.Emit();
        }
    }
}