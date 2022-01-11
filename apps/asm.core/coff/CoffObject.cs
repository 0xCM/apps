//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct CoffObject
    {
        public FS.FilePath Source;

        public BinaryCode Data;

        public static CoffObject Empty
        {
            get
            {
                var dst = new CoffObject();
                dst.Source = FS.FilePath.Empty;
                dst.Data = BinaryCode.Empty;
                return dst;
            }
        }
    }
}