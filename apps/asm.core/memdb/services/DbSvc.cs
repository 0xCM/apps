//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MemDb
    {
        public class DbSvc
        {
            internal static DbSvc create(MemDb db)
                => new DbSvc(db);

            readonly DbRender _Render;

            readonly DbSchema _Schema;

            readonly DbObjects _Objects;

            readonly MemDb Db;

            DbSvc(MemDb db)
            {
                Db = db;
                _Objects = DbObjects.create(db);
                _Schema = new (_Objects);
                _Render = new (_Schema);
            }

            public ref readonly DbObjects Objects
            {
                [MethodImpl(Inline)]
                get => ref _Objects;
            }

            public ref readonly DbRender ObjRender
            {
                [MethodImpl(Inline)]
                get => ref _Render;
            }

            public ref readonly DbSchema Schema
            {
                [MethodImpl(Inline)]
                get => ref _Schema;
            }
        }
    }
}