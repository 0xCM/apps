//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct EncodedStream : IDisposable
    {
        readonly BinaryCode Store;

        readonly MemoryStream Stream;

        [MethodImpl(Inline)]
        public EncodedStream(BinaryCode src)
        {
            Store = src;
            Stream =  new MemoryStream(src.Storage);
        }

        public void Dispose()
            => Stream?.Dispose();
    }
}