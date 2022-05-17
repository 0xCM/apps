//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface ICliRecord : IRecord
    {
        CliTableKind TableKind {get;}
    }

    public interface ICliRecord<T> : ICliRecord, IRecord<T>
        where T : unmanaged, ICliRecord<T>
    {
        CliTableKind ICliRecord.TableKind
            => typeof(T).Tag<CliRecordAttribute>().MapValueOrDefault(x => x.TableKind, CliTableKind.Invalid);

        TableId IRecord.TableId
            => TableId.identify<T>(TableKind.ToString());
    }
}