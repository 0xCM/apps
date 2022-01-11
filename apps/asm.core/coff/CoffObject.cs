//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public struct CoffObject
    {
        public const string TableId = "coff.object";

        public Identifier SrcId;

        public FS.FilePath Path;

        public BinaryCode Data;

        public static CoffObject Empty
        {
            get
            {
                var dst = new CoffObject();
                dst.Path = FS.FilePath.Empty;
                dst.Data = BinaryCode.Empty;
                dst.SrcId = Identifier.Empty;
                return dst;
            }
        }
    }
}