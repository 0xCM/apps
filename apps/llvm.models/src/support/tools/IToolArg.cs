//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    public interface IToolArg
    {
        string ArgName {get;}

        dynamic ArgValue {get;}
    }


    public interface IToolArg<T> : IToolArg
    {
        new T ArgValue {get;}

        dynamic IToolArg.ArgValue
            => ArgValue;
    }
}