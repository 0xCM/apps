//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Applied to a structural artifact or member field, method or property to indicate that the target provides some sort of literal data
    /// </summary>
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class)]
    public class LiteralProviderAttribute : Attribute
    {
        public LiteralProviderAttribute()
        {
            Name = EmptyString;
            Kind = 0;
        }

        public LiteralProviderAttribute(string name)
        {
            Name = name;
            Kind = 0;
        }

        public LiteralProviderAttribute(ClrLiteralKind kind)
        {
            Name = EmptyString;
            Kind = (byte)kind;
        }

        public LiteralProviderAttribute(ClrEnumKind kind)
        {
            Name = EmptyString;
            Kind = (uint)kind << 8;
        }

        public LiteralProviderAttribute(string name, ClrLiteralKind kind)
        {
            Name = name;
            Kind = (byte)kind;
        }

        public LiteralProviderAttribute(string name, ClrEnumKind kind)
        {
            Name = name;
            Kind = (uint)kind << 8;
        }

        public string Name {get;}

        public uint Kind {get;}
    }
}