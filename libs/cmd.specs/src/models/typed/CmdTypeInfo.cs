//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class CmdTypeInfo : ICmdTypeInfo
    {
        public readonly CmdId CmdId;

        public readonly Type SourceType;

        public readonly Index<FieldInfo> Fields;

        [MethodImpl(Inline)]
        public CmdTypeInfo(Type type, FieldInfo[] fields)
        {
            CmdId = CmdId.from(type);
            SourceType = type;
            Fields = fields;
        }

        public uint FieldCount
        {
            [MethodImpl(Inline)]
            get => Fields.Count;
        }

        CmdId ICmdTypeInfo.CmdId
            => CmdId;

        Type ICmdTypeInfo.SourceType
            => SourceType;

        Index<FieldInfo> ICmdTypeInfo.Fields
            => Fields;

        public string Format()
            => CmdSpecs.format(this);

        public override string ToString()
            => Format();

    }
}