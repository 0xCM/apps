//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Identifies an internal or external tool
    /// </summary>
    public struct ScriptId : ITypedIdentity<ScriptId,string>
    {
        public string Id {get;}

        public string Token {get;}

        [MethodImpl(Inline)]
        public ScriptId(string id)
        {
            Id = id;
            Token = EmptyString;
        }

        [MethodImpl(Inline)]
        public ScriptId(string id, string token)
        {
            Id = id;
            Token = token;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => sys.empty(Id);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => sys.nonempty(Id);
        }

        public bool IsDiscriminated
        {
            [MethodImpl(Inline)]
            get => sys.nonempty(Token);
        }

        [MethodImpl(Inline)]
        public string Format()
            => Id;

        public override string ToString()
            => Id;

        [MethodImpl(Inline)]
        public bool Equals(ScriptId src)
            => Id.Equals(src.Id);

        public override int GetHashCode()
            => Id.GetHashCode();

        public override bool Equals(object src)
            => src is ScriptId x && Equals(x);

        [MethodImpl(Inline)]
        public static implicit operator ScriptId(string src)
            => new ScriptId(src);

        [MethodImpl(Inline)]
        public static implicit operator string(ScriptId src)
            => src.Id;

        [MethodImpl(Inline)]
        public static bool operator ==(ScriptId a, ScriptId b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(ScriptId a, ScriptId b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static implicit operator ScriptId((string name, string token) src)
            => new ScriptId(src.name, src.token);

        public static ScriptId Empty
        {
            [MethodImpl(Inline)]
            get => new ScriptId(EmptyString);
        }
    }
}