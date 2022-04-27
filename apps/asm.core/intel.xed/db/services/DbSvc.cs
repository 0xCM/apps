//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDb
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