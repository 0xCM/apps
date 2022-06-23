//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ICmdTypeInfo
    {
        CmdId CmdId {get;}

        Type Source {get;}

        Index<CmdField> Fields {get;}
    }

    [Free]
    public interface ICmdDescriptor<T> : ICmdTypeInfo
        where T : struct, ICmd<T>
    {
        CmdId ICmdTypeInfo.CmdId
            => CmdTypes.identify<T>();

        Type ICmdTypeInfo.Source
            => typeof(T);
    }

    [Free]
    public interface ICmdTypeInfo<H,T> : ICmdDescriptor<T>
        where T : struct, ICmd<T>
        where H : struct, ICmdTypeInfo<H,T>
    {

    }
}