//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection.Metadata;
    using System.Reflection.PortableExecutable;
    using System.Reflection;

    partial struct Cli
    {
        /// <summary>
        /// Defines a parametric table source over a specified <see cref='Assembly'/>
        /// </summary>
        /// <param name="src">The origin</param>
        /// <typeparam name="T">The record type</typeparam>
        [Op]
        public static CliTableSource<T> source<T>(Assembly src)
            where T : struct, IRecord<T>
                => new CliTableSource<T>(src);

        /// <summary>
        /// Defines a parametric table source over a specified <see cref='MetadataReader'/>
        /// </summary>
        /// <param name="src">The origin</param>
        /// <typeparam name="T">The record type</typeparam>
        [Op]
        public static CliTableSource<T> source<T>(MetadataReader src)
            where T : struct, IRecord<T>
                => new CliTableSource<T>(src);

        /// <summary>
        /// Defines a parametric table source over a specified <see cref='MemorySeg'/>
        /// </summary>
        /// <param name="src">The origin</param>
        /// <typeparam name="T">The record type</typeparam>
        [Op]
        public static CliTableSource<T> source<T>(MemorySeg src)
            where T : struct, IRecord<T>
                => new CliTableSource<T>(src);

        /// <summary>
        /// Defines a parametric table source over a specified <see cref='PEMemoryBlock'/>
        /// </summary>
        /// <param name="src">The origin</param>
        /// <typeparam name="T">The record type</typeparam>
        [Op]
        public static CliTableSource<T> source<T>(PEMemoryBlock src)
            where T : struct, IRecord<T>
                => new CliTableSource<T>(src);

        /// <summary>
        /// Defines a <see cref='CliDataSource'/> over a specified <see cref='Assembly'/>
        /// </summary>
        /// <param name="src">The origin</param>
        [Op]
        public static CliDataSource source(Assembly src)
            => new CliDataSource(src);

        /// <summary>
        /// Defines a <see cref='CliDataSource'/> over a specified <see cref='MetadataReader'/>
        /// </summary>
        /// <param name="src">The origin</param>
        [Op]
        public static CliDataSource source(MetadataReader src)
            => new CliDataSource(src);

        /// <summary>
        /// Defines a <see cref='CliDataSource'/> over a specified <see cref='MemorySeg'/>
        /// </summary>
        /// <param name="src">The origin</param>
        [Op]
        public static CliDataSource source(MemorySeg src)
            => new CliDataSource(src);

        /// <summary>
        /// Defines a <see cref='CliDataSource'/> over a specified <see cref='PEMemoryBlock'/>
        /// </summary>
        /// <param name="src">The origin</param>
        [Op]
        public static CliDataSource source(PEMemoryBlock src)
            => new CliDataSource(src);
    }
}