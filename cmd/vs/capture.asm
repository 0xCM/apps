--- d:\views\dev\z0\libs\asm\legacy\capture\Capture.cs -------------------------
     5: namespace Z0
     6: {
     7:     using Z0.Asm;
     8:
     9:     [ApiHost]
    10:     public readonly struct Capture
    11:     {
    12:
    13:         [MethodImpl(Inline),Op]
    14:         public static CaptureExchange exchange(byte[] buffer)
    15:             => new CaptureExchange(buffer);
00007FFE185BBF80 57                   push        rdi
00007FFE185BBF81 56                   push        rsi
00007FFE185BBF82 55                   push        rbp
00007FFE185BBF83 53                   push        rbx
00007FFE185BBF84 48 83 EC 18          sub         rsp,18h
00007FFE185BBF88 C5 F8 77             vzeroupper
00007FFE185BBF8B 33 C0                xor         eax,eax
00007FFE185BBF8D 48 89 44 24 08       mov         qword ptr [rsp+8],rax
00007FFE185BBF92 48 8B D9             mov         rbx,rcx
00007FFE185BBF95 48 85 D2             test        rdx,rdx
00007FFE185BBF98 74 37                je          Z0.Capture.exchange(Byte[])+051h (07FFE185BBFD1h)
00007FFE185BBF9A 48 8D 42 10          lea         rax,[rdx+10h]
00007FFE185BBF9E 8B 6A 08             mov         ebp,dword ptr [rdx+8]
00007FFE185BBFA1 C5 F8 57 C0          vxorps      xmm0,xmm0,xmm0
00007FFE185BBFA5 C5 FA 7F 44 24 08    vmovdqu     xmmword ptr [rsp+8],xmm0
00007FFE185BBFAB 48 8D 54 24 08       lea         rdx,[rsp+8]
00007FFE185BBFB0 48 89 02             mov         qword ptr [rdx],rax
00007FFE185BBFB3 89 6A 08             mov         dword ptr [rdx+8],ebp
00007FFE185BBFB6 48 8B FB             mov         rdi,rbx
00007FFE185BBFB9 48 8D 74 24 08       lea         rsi,[rsp+8]
00007FFE185BBFBE E8 9D EF CE 5B       call        JIT_ByRefWriteBarrier (07FFE742AAF60h)
00007FFE185BBFC3 48 A5                movs        qword ptr [rdi],qword ptr [rsi]
00007FFE185BBFC5 48 8B C3             mov         rax,rbx
00007FFE185BBFC8 48 83 C4 18          add         rsp,18h
00007FFE185BBFCC 5B                   pop         rbx
00007FFE185BBFCD 5D                   pop         rbp
00007FFE185BBFCE 5E                   pop         rsi
00007FFE185BBFCF 5F                   pop         rdi
00007FFE185BBFD0 C3                   ret
00007FFE185BBFD1 33 C0                xor         eax,eax
00007FFE185BBFD3 33 ED                xor         ebp,ebp
00007FFE185BBFD5 EB CA                jmp         Z0.Capture.exchange(Byte[])+021h (07FFE185BBFA1h)
00007FFE185BBFD7 CC                   int         3
00007FFE185BBFD8 CC                   int         3
00007FFE185BBFD9 00 00                add         byte ptr [rax],al
00007FFE185BBFDB 00 19                add         byte ptr [rcx],bl
00007FFE185BBFDD 08 05 00 08 22 04    or          byte ptr [7FFE1C7DC7E3h],al
00007FFE185BBFE3 30 03                xor         byte ptr [rbx],al
00007FFE185BBFE5 50                   push        rax
00007FFE185BBFE6 02 60 01             add         ah,byte ptr [rax+1]
00007FFE185BBFE9 70 00                jo          Z0.Capture.exchange(Byte[])+06Bh (07FFE185BBFEBh)
00007FFE185BBFEB 00 00                add         byte ptr [rax],al
00007FFE185BBFED 00 00                add         byte ptr [rax],al
00007FFE185BBFEF 00 02                add         byte ptr [rdx],al
00007FFE185BBFF1 00 00                add         byte ptr [rax],al
00007FFE185BBFF3 00 00                add         byte ptr [rax],al
00007FFE185BBFF5 00 00                add         byte ptr [rax],al
00007FFE185BBFF7 00 E8                add         al,ch
00007FFE185BBFF9 93                   xchg        eax,ebx
00007FFE185BBFFA E7 CE                out         0CEh,eax
00007FFE185BBFFC 5B                   pop         rbx
00007FFE185BBFFD 5E                   pop         rsi
00007FFE185BBFFE 00 1B                add         byte ptr [rbx],bl
00007FFE185BC000 E8 8B E7 CE 5B       call        PrecodeFixupThunk (07FFE742AA790h)
00007FFE185BC005 5E                   pop         rsi
00007FFE185BC006 02 1A                add         bl,byte ptr [rdx]
00007FFE185BC008 E8 83 E7 CE 5B       call        PrecodeFixupThunk (07FFE742AA790h)
00007FFE185BC00D 5E                   pop         rsi