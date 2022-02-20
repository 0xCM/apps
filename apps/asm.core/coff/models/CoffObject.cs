//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CoffObject
    {
        public readonly FS.FilePath Path;

        public readonly BinaryCode Data;

        internal CoffObject(FS.FilePath path, BinaryCode data)
        {
            Path = path;
            Data = data;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Data.Size;
        }

        public ref readonly byte this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref readonly byte this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public static CoffObject Empty
            => new CoffObject(FS.FilePath.Empty, BinaryCode.Empty);
    }
}