//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;
    using System.Reflection.Metadata;
    using System.Reflection.PortableExecutable;

    using static Root;

    public sealed class CliDataSource : DataSource<CliDataSource>
    {
        public CliReader Reader {get;}

        internal CliDataSource(Assembly src)
        {
            Reader = CliReader.read(src);
        }

        internal CliDataSource(MetadataReader src)
        {
            Reader = CliReader.read(src);
        }

        internal CliDataSource(MemorySeg src)
        {
            Reader = CliReader.read(src);
        }

        internal CliDataSource(PEMemoryBlock src)
        {
            Reader = CliReader.read(src);
        }

        public CliTableSource<T> TableSouce<T>()
            where T : struct, IRecord<T>
                => new CliTableSource<T>(Reader);
    }
}