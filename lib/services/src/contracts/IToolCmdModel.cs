//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IToolCmdModel
    {
        Type ModelType {get;}
    }

    [Free]
    public interface IToolCmdModel<T> : IToolCmdModel
        where T : struct, IToolCmdModel<T>
    {
        Type IToolCmdModel.ModelType
            => typeof(T);
    }
}