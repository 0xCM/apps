//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static Root;

    public struct TableField<F>
        where F : unmanaged
    {
        public F Id {get;}

        public TableField Spec;

        public FieldInfo Definition
            => Spec.Definition;

        public RenderWidth Width {get;}

        [MethodImpl(Inline)]
        public TableField(F id, TableField spec, RenderWidth width)
        {
            Id = id;
            Spec = spec;
            Width = width;
        }

        public string Name
        {
            [MethodImpl(Inline)]
            get => Definition.Name;
        }

        public Type DataType
        {
            [MethodImpl(Inline)]
            get => Definition.FieldType;
        }
    }
}