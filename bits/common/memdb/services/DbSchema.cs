//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class MemDb
    {
        public class DbSchema
        {
            Index<ObjectKind> _ObjKinds;

            public ref readonly Index<ObjectKind> ObjKinds
            {
                [MethodImpl(Inline)]
                get => ref _ObjKinds;
            }

            static Index<ObjectKind> CalcObjKinds()
            {
                Index<ObjectKind> dst = alloc<ObjectKind>(DbObjects.ObjTypeCount);
                var kinds = Symbols.kinds<ObjectKind>();
                for(var i=0; i<kinds.Length; i++)
                    dst[i] = skip(kinds,i);
                return dst;
            }

            public DbSchema(DbObjects objects)
            {
                _ObjKinds = CalcObjKinds();

            }
        }
    }
}