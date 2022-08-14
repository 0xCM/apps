//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Types
{

    public abstract record class Literal<T>
        where T : Literal<T>, new()
    {

    }

    public sealed record class StringLiteral : Literal<StringLiteral>
    {


    }

    public sealed record class NumericLiteral : Literal<NumericLiteral>
    {

        
    }
}