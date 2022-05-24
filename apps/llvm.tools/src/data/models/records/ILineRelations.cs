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
    }

    public interface ILineRelations<T> : ILineRelations
        where T : struct, ILineRelations<T>
    {
    }
}