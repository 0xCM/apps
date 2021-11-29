//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct DsId
    {
        public TableId Table {get;}
    }

    public readonly struct DsId<T>
        where T : struct, ITableSource, IRecord<T>
    {
        public TableId Table
        {
            [MethodImpl(Inline)]
            get => default(T).TableId;
        }
    }

    public interface IDataSource
    {

    }

    public abstract class DataSource<H>
        where H : DataSource<H>
    {

    }


    public interface ITableSource
    {
        Type RecordType {get;}
    }

    public interface ITableSource<T> : ITableSource
        where T : struct, IRecord<T>
    {
        Type ITableSource.RecordType
            => typeof(T);
    }

    public abstract class TableSource<T> : ITableSource<T>
        where T : struct, IRecord<T>
    {

    }

    public abstract class TableSource<H,T> : TableSource<T>
        where H : TableSource<H,T>
        where T : struct, IRecord<T>
    {

    }
}