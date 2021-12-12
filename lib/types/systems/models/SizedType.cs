//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class SizedType : ISizedType
    {
        public Identifier Name {get;}

        public Identifier Class {get;}

        public ulong Kind {get;}

        public BitWidth ContentWidth {get;}

        public BitWidth StorageWidth {get;}

        public SizedType(string name, Identifier @class, ulong kind, BitWidth content, BitWidth storage)
        {
            Name = name;
            Class = @class;
            Kind = kind;
            ContentWidth = content;
            StorageWidth = storage;
        }
        public string Format()
            => Name;
    }
}