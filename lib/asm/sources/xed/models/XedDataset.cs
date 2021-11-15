//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;
    using System.Reflection;
    using System.Linq;

    using static Root;

    public class XedDataset
    {
        readonly FieldInfo Field;

        readonly XedDatasetKind _Kind;

        readonly string _Name;

        public XedDataset(FieldInfo field)
        {
            Field = field;
            _Kind =  (XedDatasetKind)field.GetRawConstantValue();
            if(_Kind != 0)
                _Name = field.Tag<AliasAttribute>().Require().AliasList.First();
            else
                _Name = EmptyString;
        }

        public string Name
        {
            [MethodImpl(Inline)]
            get => _Name;
        }

        public string Identifier
        {
            [MethodImpl(Inline)]
            get => Field.Name;
        }

        public XedDatasetKind Kind
        {
            [MethodImpl(Inline)]
            get => _Kind;
        }
    }
}