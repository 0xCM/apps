//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public class InstLayouts
        {
            readonly Index<InstLayout> Data;

            public InstLayouts(InstLayout[] src)
            {
                Data = src;
            }

            public uint Count
            {
                [MethodImpl(Inline)]
                get => Data.Count;
            }

            public ref InstLayout this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public ref InstLayout this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Data.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Data.IsNonEmpty;
            }

            public ReadOnlySpan<InstLayout> View
            {
                [MethodImpl(Inline)]
                get => Data;
            }

            public void Render(ITextEmitter dst)
            {
                for(var i=0; i<Count; i++)
                    dst.AppendLine(this[i]);
            }

            public string Format()
            {
                var dst = text.emitter();
                Render(dst);
                return dst.Emit();
            }

            public override string ToString()
                => Format();

            public static implicit operator InstLayouts(InstLayout[] src)
                => new InstLayouts(src);

            public static implicit operator InstLayouts(Index<InstLayout> src)
                => new InstLayouts(src);
        }
    }
}