//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;
    using System.Linq;

    using static Root;

    public static class TaggedLiterals
    {
        public static Index<BinaryLiteral<T>> binary<E,T>()
            where E : unmanaged, Enum
            where T : unmanaged
                => from f in typeof(E).LiteralFields().ToArray()
                    where f.Tagged<BinaryLiteralAttribute>()
                    let a = f.Tag<BinaryLiteralAttribute>().Require()
                    select BinaryLiteral.define(base2, f.Name, Enums.scalar<E,T>((E)f.GetValue(null)), a.Text);

        public static NumericLiteral binaryliteral(FieldInfo target, object value)
        {
            if(!IsBinaryLiteral(target))
                return NumericLiteral.Empty;
            return Numeric.literal(base2, target.Name, value, target.Tag<BinaryLiteralAttribute>().Value.Text);
        }

        [MethodImpl(Inline), Op]
        public static LiteralInfo describe(string Name, object Data, string Text, TypeCode TypeCode, bool IsEnum, bool MultiLiteral)
            => new LiteralInfo(Name,Data, Text, TypeCode, IsEnum, MultiLiteral);

        [MethodImpl(Inline), Op]
        public static LiteralInfo polymorphic(FieldInfo target, string Text)
            => describe(
                Name: target.Name,
                Data: target.GetRawConstantValue(),
                Text: Text,
                TypeCode: Type.GetTypeCode(target.FieldType),
                IsEnum: target.FieldType.IsEnum,
                MultiLiteral: true
                );

        [Op]
        public static LiteralInfo polymorphic(FieldInfo target)
            => target.Tag<MultiLiteralAttribute>().MapValueOrDefault(tag => polymorphic(target, tag.Data), LiteralInfo.Empty);

        public static bool IsBinaryLiteral(FieldInfo target)
            => Attribute.IsDefined(target, typeof(BinaryLiteralAttribute));

        public static bool IsMultiLiteral(FieldInfo target)
            => Attribute.IsDefined(target, typeof(MultiLiteralAttribute));
    }
}