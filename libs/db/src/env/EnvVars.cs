//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct EnvVars
    {
        public static EnvVars load()
            => new (Environs.vars().ToArray());

        public static EnvSet set(FS.FilePath src, char sep)
            => Environs.set(src, sep);

        Index<EnvVar> Data {get;}

        [MethodImpl(Inline)]
        public EnvVars(EnvVar[] src)
        {
            Data = src;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public EnvVar[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public Span<EnvVar> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public ReadOnlySpan<EnvVar> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public ref EnvVar this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref EnvVar this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public string Format()
        {
            var dst = text.buffer();
            var src = View;
            var count = src.Length;
            for(var i=0; i<count; i++)
                dst.AppendLine(skip(src,i));
            return dst.Emit();
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator EnvVars(EnvVar[] src)
            => new EnvVars(src);

        [MethodImpl(Inline)]
        public static implicit operator EnvVars(List<EnvVar> src)
            => new EnvVars(src.ToArray());

        [MethodImpl(Inline)]
        public static implicit operator EnvVar[](EnvVars src)
            => src.Storage;
    }
}