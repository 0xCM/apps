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

        Type SourceType {get;}

        Index<FieldInfo> Fields {get;}
    }

    [Free]
    public interface ICmdDescriptor<T> : ICmdTypeInfo
        where T : struct, ICmd<T>
    {
        CmdId ICmdTypeInfo.CmdId
            => CmdId.from<T>();

        Type ICmdTypeInfo.SourceType
            => typeof(T);

        Index<FieldInfo> ICmdTypeInfo.Fields
            => typeof(T).DeclaredInstanceFields();
    }

    [Free]
    public interface ICmdTypeInfo<H,T> : ICmdDescriptor<T>
        where T : struct, ICmd<T>
        where H : struct, ICmdTypeInfo<H,T>
    {

    }
}