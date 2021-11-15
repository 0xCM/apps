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

    public sealed class CliTableSource<T> : TableSource<CliTableSource<T>,T>
        where T : struct, IRecord<T>
    {
        public CliReader Reader {get;}

        [MethodImpl(Inline)]
        internal CliTableSource(CliReader src)
        {
            Reader = src;
        }

        [MethodImpl(Inline)]
        internal CliTableSource(Assembly src)
        {
            Reader = CliReader.read(src);
        }

        [MethodImpl(Inline)]
        internal CliTableSource(MetadataReader src)
        {
            Reader = CliReader.read(src);
        }

        [MethodImpl(Inline)]
        internal CliTableSource(MemorySeg src)
        {
            Reader = CliReader.read(src);
        }

        [MethodImpl(Inline)]
        internal CliTableSource(PEMemoryBlock src)
        {
            Reader = CliReader.read(src);
        }
    }
}