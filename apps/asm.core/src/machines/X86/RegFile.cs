//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Machines.X86
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    using Asm;

    /// <summary>
    /// Defines a squence of register seqeunces
    /// </summary>
    public readonly struct RegFile
    {
        static long FileSeqKeys;

        static long RegSeqKeys;

        [Op]
        public static RegFile intel64()
        {
            var gp64 = new RegSeqSpec((uint)inc(ref RegSeqKeys), 16, 8);
            var v512 = new RegSeqSpec((uint)inc(ref RegSeqKeys), 32, 64);
            var masks = new RegSeqSpec((uint)inc(ref RegSeqKeys), 8, 8);
            var system = new RegSeqSpec((uint)inc(ref RegSeqKeys), 8, 8);
            return new RegFile((uint)inc(ref FileSeqKeys),new RegSeqSpec[]{gp64,v512,masks,system});
        }

        /// <summary>
        /// A surrogate key
        /// </summary>
        public uint Id {get;}

        readonly Index<RegSeqSpec> Data;

        public uint SeqCount
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        [MethodImpl(Inline)]
        internal RegFile(uint seq, RegSeqSpec[] specs)
        {
            Id = seq;
            Data = specs;
        }

        public Span<RegSeqSpec> Specs
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        [MethodImpl(Inline)]
        public ref RegSeqSpec Spec(uint seq)
            => ref Data[seq];
    }
}