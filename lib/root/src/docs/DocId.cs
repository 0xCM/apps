//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct DocId : IDocLine
    {
        /// <summary>
        /// Computes the <see cref='DocId'/> of a parametrically-identified record
        /// </summary>
        /// <typeparam name="T">The record type</typeparam>
        [MethodImpl(Inline)]
        public static DocId identify<T>()
            where T : struct
                => identify(typeof(T));

        [MethodImpl(Inline)]
        public static DocId identify<T>(string name)
            where T : struct
                => identify(typeof(T), name);

        /// <summary>
        /// Computes the <see cref='DocId'/> of a specified record type
        /// </summary>
        /// <param name="src">The record type</typeparam>
        [MethodImpl(Inline)]
        public static DocId identify(Type src)
            => src.Tag<DocLineAttribute>().MapValueOrElse(
                    a => new DocId(a.DocId, src.FullName),
                    () => new DocId(src.Name, src.FullName));

        [MethodImpl(Inline)]
        public static DocId identify(Type src, string name)
            => new DocId(name, src.FullName);

        [MethodImpl(Inline)]
        public static DocId define(string identity, string name)
            => new DocId(name, identity);

        [MethodImpl(Inline)]
        public static DocId define(string name)
            => new DocId(name, EmptyString);

        public Name Identifier {get;}

        public Name Identity {get;}

        [MethodImpl(Inline)]
        DocId(string name, string identity)
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