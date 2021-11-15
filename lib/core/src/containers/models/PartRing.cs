//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    /// <summary>
    /// Defines a mutable circular S-cell buffer partitioned into T-cell parts
    /// </summary>
    public ref struct PartRing<S,T>
        where T : unmanaged
    {
        readonly Span<S> Buffer;

        readonly int parts;

        readonly int partwidth;

        int CurrentPart;

        internal PartRing(Span<S> src)
        {
            Buffer = src;
            partwidth = (int)size<T>();
            parts = src.Length/partwidth;
            CurrentPart = 0;
        }

        public ref T Next
        {
            [MethodImpl(Inline)]
            get
            {
                if(CurrentPart == parts)
                    CurrentPart = 0;

                ref var next = ref seek(first(Buffer), CurrentPart*partwidth);
                CurrentPart++;
                return ref @as<S,T>(next);
            }
        }

        public ReadOnlySpan<S> Data
        {
            [MethodImpl(Inline)]
            get => Buffer;
        }
    }
}