//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct ExecToken
    {
        public ulong StartSeq;

        public Timestamp Started;

        public Timestamp? Finished;

        public ulong EndSeq;

        [MethodImpl(Inline)]
        public ExecToken(ulong seq)
        {
            StartSeq = seq;
            Started = Timestamp.now();
            Finished = null;
            EndSeq = 0;
        }

        [MethodImpl(Inline)]
        public ExecToken Complete(ulong seq)
        {
            EndSeq = seq;
            Finished = Timestamp.now();
            return this;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => StartSeq == 0 || StartSeq == ulong.MaxValue;
        }

        public static ExecToken Empty
        {
            [MethodImpl(Inline)]
            get => new ExecToken(ulong.MaxValue);
        }

        public string Format()
            => string.Format("{0} | {1} | {2}", string.Format("{0:D4}:{1:D4}", StartSeq, EndSeq), Started, Finished ?? Timestamp.Zero);

        public override string ToString()
            => Format();
    }
}