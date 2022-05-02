//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDataTypes
    {
        [Free]
        public interface IRuleType
        {
            asci32 TypeName {get;}

            TypeKind TypeKind {get;}

            uint MetaWidth {get;}
        }

        [Free]
        public interface IRuleType<T> : IRuleType
            where T : unmanaged, IRuleType<T>
        {
            new uint MetaWidth
                => core.width<T>();

            uint IRuleType.MetaWidth
                => (byte)core.width<T>();
        }
    }
}