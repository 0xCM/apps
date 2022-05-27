//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a link between an identified resource and an emission target
    /// </summary>
    public readonly struct ResEmission
    {
        public readonly Asset Source;

        public readonly FS.FilePath Target;

        [MethodImpl(Inline)]
        public ResEmission(Asset src, FS.FilePath dst)
        {
            Source = src;
            Target = dst;
        }

        [MethodImpl(Inline)]
        public static implicit operator ResEmission(Arrow<Asset,FS.FilePath> link)
            => new ResEmission(link.Source, link.Target);

        [MethodImpl(Inline)]
        public static implicit operator Arrow<Asset,FS.FilePath>(ResEmission src)
            => new ResEmission(src.Source, src.Target);
    }
}