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
            internal static DbSvc create()
                => Instance;

            internal static DbRender Render
                => _Render;

            internal static DbObjects DbObj
                => _Objects;

            static DbObjects _Objects;

            static DbRender _Render;

            static DbSchema _Schema;

            public DbObjects Objects => _Objects;

            public DbRender ObjRender => _Render;

            public DbSchema Schema => _Schema;

            static DbSvc Instance;

            DbSvc()
            {
            }

            static DbSvc()
            {
                _Objects = DbObjects.create();
                _Render = new (_Objects);
                _Schema = new (_Objects);
                Instance = new();
            }
        }
    }
}