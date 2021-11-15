//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct TableId : ITableId
    {
        /// <summary>
        /// Computes the <see cref='TableId'/> of a parametrically-identified record
        /// </summary>
        /// <typeparam name="T">The record type</typeparam>
        [MethodImpl(Inline)]
        public static TableId identify<T>()
            where T : struct
                => identify(typeof(T));

        [MethodImpl(Inline)]
        public static TableId identify<T>(string name)
            where T : struct
                => identify(typeof(T), name);

        /// <summary>
        /// Computes the <see cref='TableId'/> of a specified record type
        /// </summary>
        /// <param name="src">The record type</typeparam>
        [MethodImpl(Inline)]
        public static TableId identify(Type src)
            => src.Tag<RecordAttribute>().MapValueOrElse(
                    a => new TableId(a.TableId, src.FullName),
                    () => new TableId(src.Name, src.FullName));

        [MethodImpl(Inline)]
        public static TableId identify(Type src, string name)
            => new TableId(name, src.FullName);

        [MethodImpl(Inline)]
        public static TableId define(string identity, string name)
            => new TableId(name, identity);

        [MethodImpl(Inline)]
        public static TableId define(string name)
            => new TableId(name, EmptyString);

        public Name Identifier {get;}

        public Name Identity {get;}

        [MethodImpl(Inline)]
        TableId(string name, string identity)
        {
            Identifier = name;
            Identity = identity;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Identifier.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Identifier.Format();

        public override string ToString()
            => Format();
    }
}