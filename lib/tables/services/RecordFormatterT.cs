//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using api = Tables;

    public struct RecordFormatter<T> : IRecordFormatter<T>
        where T : struct
    {
        public RowFormatSpec FormatSpec {get;}

        internal RowAdapter<T> Adapter;

        [MethodImpl(Inline)]
        internal RecordFormatter(RowFormatSpec spec, RowAdapter<T> adapter)
        {
            FormatSpec = spec;
            Adapter = adapter;
        }

        public string Format(in T src)
            => api.format(ref this, src);

        public string Format(in T src, RecordFormatKind kind)
            => api.format(ref this, src, kind);

        public string FormatHeader()
            => FormatSpec.Header.Format();
    }
}