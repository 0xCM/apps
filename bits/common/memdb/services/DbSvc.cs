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
            readonly DbObjects _Objects;

            readonly MemDb Db;

            DbSvc(MemDb db)
            {
                Db = db;
            }
        }
    }
}