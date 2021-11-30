//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IRowType : ITextual
    {
        TableId Table {get;}

        string ITextual.Format()
            => Table.Format();
    }

    public interface IRowType<T> : IRowType
        where T : struct, IRecord<T>
    {
        new TableId<T> Table {get;}

        TableId IRowType.Table
            => Table;
    }
}