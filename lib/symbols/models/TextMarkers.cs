//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct TextMarkers
    {
        readonly Index<TextMarker> Data;

        [MethodImpl(Inline)]
        public TextMarkers(TextMarker[] src)
        {
            Data = src;
        }

        public ReadOnlySpan<TextMarker> View
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ref readonly TextMarker this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref readonly TextMarker this[long index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        [MethodImpl(Inline)]
        public static implicit operator TextMarkers(TextMarker[] src)
            => new TextMarkers(src);

        public static TextMarkers Empty
            => new TextMarkers(sys.empty<TextMarker>());
    }
}