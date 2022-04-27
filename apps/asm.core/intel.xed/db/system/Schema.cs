//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedDb
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