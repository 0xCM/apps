//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ISpanResSpec
    {
        Identifier Name {get;}

        bool IsStatic {get;}

        string CellType {get;}

        uint CellCount {get;}
    }
}