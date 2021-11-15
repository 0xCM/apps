//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ILineRelations
    {
        LineNumber SourceLine {get;}

        Identifier Name {get;}

        void Specify(LineNumber line, Identifier name, Lineage ancestors);

    }

    public interface ILineRelations<T> : ILineRelations,  IRecord<T>
        where T : struct, ILineRelations<T>
    {
    }
}