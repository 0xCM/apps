//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct CmdTypes : IIndex<CmdTypeInfo>
    {
        [Op]
        public static CmdTypeInfo cmdtype(Type src)
            => new CmdTypeInfo(src, src.DeclaredInstanceFields());

        [Op]
        public static Index<CmdTypeInfo> cmdtypes(Assembly[] src)
            => src.Types().Tagged<CmdAttribute>().Select(cmdtype);

        Index<CmdTypeInfo> Data;

        [MethodImpl(Inline)]
        public CmdTypes(CmdTypeInfo[] src)
            => Data = src;

        public CmdTypeInfo[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        [MethodImpl(Inline)]
        public static implicit operator CmdTypes(CmdTypeInfo[] src)
            => new CmdTypes(src);
    }
}