//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITextTemplate : ITextual
    {
        TextBlock Pattern {get;}

        object[] Parameters {get;}

        uint ParameterCount {get;}
    }
}