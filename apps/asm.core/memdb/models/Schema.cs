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
            public ref readonly DbObjects Objects
            {
                [MethodImpl(Inline)]
                get => ref _DbObjects;
            }

            DbObjects _DbObjects;

            public DbSchema(DbObjects objects)
            {
                _DbObjects = objects;
            }
        }
    }
}