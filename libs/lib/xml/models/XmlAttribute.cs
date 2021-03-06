//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;
    using System.Xml;

    using static Root;

    partial struct XmlParts
    {
        public readonly struct XmlAttribute : IXmlAttribute<string>, IXmlPart<string>
        {
            public NameOld Name {get;}

            public string Value {get;}

            [MethodImpl(Inline)]
            public XmlAttribute(string name, string value)
            {
                Name = name;
                Value = value;
            }

            public XmlNodeType Kind
                => XmlNodeType.Attribute;

            public string Format()
                => string.Format("{0}={1}", Name, Value);
        }
    }
}