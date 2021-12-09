//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CoffObjFile : CoffObj
    {
        public CoffObjFile(FS.FilePath src)
            :base(src.ReadBytes())
        {
            Path = src;
        }

        public FS.FilePath Path {get;}
    }
}