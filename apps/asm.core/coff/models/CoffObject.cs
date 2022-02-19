//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CoffObject
    {
        public uint DocId;

        public Identifier SrcId;

        public FS.FilePath Path;

        public BinaryCode Data;

        internal CoffObject(uint docid, Identifier id, FS.FilePath path, BinaryCode data)
        {
            DocId = docid;
            SrcId = id;
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
            => new CoffObject(0,Identifier.Empty, FS.FilePath.Empty, BinaryCode.Empty);
    }
}