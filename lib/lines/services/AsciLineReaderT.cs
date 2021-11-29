//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.IO;

    using static Root;
    using static core;

    using api = Lines;

    public ref struct AsciLineReader<T>
        where T : unmanaged
    {
        Span<byte> _Buffer;

        LineReaderState State;

        public AsciLineReader(StreamReader src)
        {
            _Buffer = alloc<byte>(1024);
            State = new LineReaderState(src);
        }

        [MethodImpl(Inline)]
        Span<byte> Buffer()
        {
            _Buffer.Clear();
            return _Buffer;
        }


        public void Dispose()
        {
            State.Source?.Dispose();
        }

        public bool NextT(out AsciLine<T> dst)
            => api.next(ref State, Buffer(), out dst);

        public bool Next(out AsciLine<byte> dst)
            => api.next(ref State, out dst);

        public bool Next(out AsciLine<char> dst)
            => api.next(ref State, out dst);
    }
}