//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IVertex : IExpr
    {
        object Value {get;}

        DataList<Vertex> Targets {get;}
    }


}