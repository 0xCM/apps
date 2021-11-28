//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct CmdFlows<T> : IIndex<CmdFlow<T>>
    {
        readonly Index<CmdFlow<T>> Data;

        [MethodImpl(Inline)]
        public CmdFlows(CmdFlow<T>[] src)
        {
            Data = src;
        }

        public CmdFlow<T>[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public ref CmdFlow<T> this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref CmdFlow<T> this[int i]
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

        public string Format()
            => Cmd.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CmdFlows<T>(CmdFlow<T>[] src)
            => new CmdFlows<T>(src);

        public static CmdFlows<T> Empty => new CmdFlows<T>(sys.empty<CmdFlow<T>>());
    }
}