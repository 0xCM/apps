//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CmdTypeInfo : ICmdTypeInfo, IComparable<CmdTypeInfo>
    {
        public readonly CmdId CmdId;

        public readonly Type Source;

        public readonly Index<CmdField> Fields;

        [MethodImpl(Inline)]
        public CmdTypeInfo(CmdId name, Type type, CmdField[] fields)
        {
            CmdId = name;
            Source = Require.notnull(type);
            Fields = fields;
        }

        public string TypeName
        {
            [MethodImpl(Inline)]
            get => Source.DisplayName();
        }

        public uint FieldCount
        {
            [MethodImpl(Inline)]
            get => Fields.Count;
        }

        CmdId ICmdTypeInfo.CmdId
            => CmdId;

        Type ICmdTypeInfo.Source
            => Source;

        Index<CmdField> ICmdTypeInfo.Fields
            => Fields;

        public int CompareTo(CmdTypeInfo src)
            => CmdId.CompareTo(src.CmdId);

        public string Format()
            => CmdTypes.format(this);

        public override string ToString()
            => Format();
    }
}