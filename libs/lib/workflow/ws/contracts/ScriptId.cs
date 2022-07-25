//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Identifies an internal or external tool
    /// </summary>
    public struct ScriptId
    {
        public string Id {get;}

        [MethodImpl(Inline)]
        public ScriptId(string id)
        {
            Id = id;
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

        public static ScriptId Empty
        {
            [MethodImpl(Inline)]
            get => new ScriptId(EmptyString);
        }
    }
}