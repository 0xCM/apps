//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct BitFormatOptions
    {
        [MethodImpl(Inline), Op]
        public static BitFormat bits(bool tlz = false)
            => define(tlz:tlz, specifier:false, blockWidth:null, blocksep:null, rowWidth:null, maxbits:null,zpad:null);

        [MethodImpl(Inline), Op]
        public static BitFormat bitmax(uint maxbits, int? zpad = null, bool specifier = false)
            => define(tlz:true, maxbits: maxbits, zpad:zpad, specifier:specifier);

        [MethodImpl(Inline), Op]
        public static BitFormat bitblock(int width, char? sep = null, uint? maxbits = null, bool specifier = false)
            => define(tlz:false, blockWidth: width, blocksep: sep, maxbits:maxbits, specifier: specifier);

        [MethodImpl(Inline), Op]
        public static BitFormat bitrows(int blockWidth, int rowWidth, char? blockSep = null)
            => define(tlz:false, blockWidth: blockWidth, rowWidth:rowWidth, blocksep: blockSep);

        [MethodImpl(Inline), Op]
        public static BitFormat define(bool tlz, bool specifier = false, int? blockWidth = null, char? blocksep = null, int? rowWidth = null, uint? maxbits = null, int? zpad = null)
            => new BitFormat(tlz, specifier, blockWidth, blocksep, rowWidth, maxbits, zpad);
    }
}