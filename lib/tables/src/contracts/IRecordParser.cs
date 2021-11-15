//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IRecordParser
    {

    }

    public interface IRecordParser<T> : IRecordParser
        where T : struct
    {
        Outcome ParseHeader(TextLine src, out RowHeader dst);

        Outcome ParseRow(TextLine src, out T dst);
    }

    public class RecordParserAtribute : Attribute
    {
        public RecordParserAtribute(Type record)
        {
            RecordType = record;
        }

        public Type RecordType {get;}
    }
}