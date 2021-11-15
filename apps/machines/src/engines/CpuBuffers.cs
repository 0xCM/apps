//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Machines
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public struct CpuBuffers
    {
        [MethodImpl(Inline), Op]
        public static CpuBuffers create(uint size)
            => new CpuBuffers(size);

        [MethodImpl(Inline)]
        static CpuBuffer<N,W,T> buffer<N,W,T>()
            where N : unmanaged, ITypeNat
            where W : unmanaged, ITypeWidth
            where T : unmanaged
                => new CpuBuffer<N,W,T>(new T[nat64u<N>()]);

        readonly CpuBuffer<N64,W8,HexDigitCode> step;

        readonly CpuBuffer<N64,W8,HexDigitCode> run;

        readonly char[] log;

        [MethodImpl(Inline)]
        internal CpuBuffers(uint size)
        {
            log = alloc<char>(size);
            step = buffer<N64,W8,HexDigitCode>();
            run = buffer<N64,W8,HexDigitCode>();
        }

        [MethodImpl(Inline), Op]
        public Span<HexDigitCode> Step()
        {
            step.Clear(w128);
            return step.Edit;
        }

        [MethodImpl(Inline), Op]
        public Span<HexDigitCode> Run()
            => run.Edit;

        [MethodImpl(Inline), Op]
        public Span<char> Log()
        {
            Span<char> buffer = log;
            buffer.Clear();
            return buffer;
        }
    }
}