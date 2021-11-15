; ----------------------------------------------------------------------------------------------------------------------------------------------------------------
; IntPtr func_32i_32i_32i(void* f)::located://asmrun/sigs?func_32i_32i_32i#func_32i_32i_32i_(void~ptr)
; public static ReadOnlySpan<byte> func_32i_32i_32i_ᐤvoidᕀptrᐤ => new byte[223]{0xe9,0xc3,0xe4,0x20,0x04,0x5f,0x00,0x01,0xe9,0xdb,0xe9,0x20,0x04,0x5f,0x03,0x00,0x50,0x40,0xbf,0xa4,0xfa,0x7f,0x00,0x00,0xe8,0x8b,0xeb,0xb4,0x5f,0x5e,0x00,0x03,0xe8,0x83,0xeb,0xb4,0x5f,0x5e,0x03,0x02,0xe8,0x7b,0xeb,0xb4,0x5f,0x5e,0x06,0x01,0xe9,0x13,0x77,0x20,0x04,0x5f,0x09,0x00,0x18,0x41,0xbf,0xa4,0xfa,0x7f,0x00,0x00,0xe8,0x63,0xeb,0xb4,0x5f,0x5e,0x00,0x01,0xe8,0x5b,0xeb,0xb4,0x5f,0x5e,0x04,0x00,0x10,0x42,0xbf,0xa4,0xfa,0x7f,0x00,0x00,0xe8,0x4b,0xeb,0xb4,0x5f,0x5e,0x00,0x00,0x40,0x43,0xbf,0xa4,0xfa,0x7f,0x00,0x00,0xe8,0x3b,0xeb,0xb4,0x5f,0x5e,0x00,0x0c,0xe8,0x33,0xeb,0xb4,0x5f,0x5e,0x02,0x0b,0xe8,0x2b,0xeb,0xb4,0x5f,0x5e,0x04,0x0a,0xe8,0x23,0xeb,0xb4,0x5f,0x5e,0x06,0x09,0xe8,0x1b,0xeb,0xb4,0x5f,0x5e,0x08,0x08,0xe8,0x13,0xeb,0xb4,0x5f,0x5e,0x0a,0x07,0xe8,0x0b,0xeb,0xb4,0x5f,0x5e,0x0c,0x06,0xe8,0x03,0xeb,0xb4,0x5f,0x5e,0x0e,0x05,0xe8,0xfb,0xea,0xb4,0x5f,0x5e,0x10,0x04,0xe8,0xf3,0xea,0xb4,0x5f,0x5e,0x12,0x03,0xe8,0xeb,0xea,0xb4,0x5f,0x5e,0x14,0x02,0xe8,0xe3,0xea,0xb4,0x5f,0x5e,0x16,0x01,0xe8,0xdb,0xea,0xb4,0x5f,0x5e,0x18,0x00,0x60,0x44,0xbf,0xa4,0xfa,0x7f,0x00,0x00,0xe9,0xeb,0x42,0x00,0x00,0x5f,0x00};
; BaseAddress = 7ffaa499ac98h
; TermCode = CTC_Zx7
; 00007FFAA499AC93 E9 E8 EA B4 5F       jmp         CLRStub[MethodDescPrestub]@7ffaa499ac94 (00h)
; 00007FFAA499AC98 E9 C3 E4 20 04       jmp         Z0.Sigs.func_32i_32i_32i(Int32, Int32) func_32i_32i_32i(Void*) (07FFAA8BA9160h)
; 00007FFAA499AC9D 5F                   pop         rdi
0000h jmp near ptr 420e4c8h                         ; JMP rel32                        | E9 cd                            | 5   | e9 c3 e4 20 04

; 00007FFAA8BA9160 48 8B C1             mov         rax,rcx
; 00007FFAA8BA9163 C3                   ret

; ----------------------------------------------------------------------------------------------------------------------------------------------------------------
; int invoke(IntPtr f, int a, int b)::located://asmrun/sigs?invoke#invoke_(IntPtr,32i,32i)
; public static ReadOnlySpan<byte> invoke_ᐤIntPtrㆍ32iㆍ32iᐤ => new byte[215]{0xe9,0xdb,0xe9,0x20,0x04,0x5f,0x03,0x00,0x50,0x40,0xbf,0xa4,0xfa,0x7f,0x00,0x00,0xe8,0x8b,0xeb,0xb4,0x5f,0x5e,0x00,0x03,0xe8,0x83,0xeb,0xb4,0x5f,0x5e,0x03,0x02,0xe8,0x7b,0xeb,0xb4,0x5f,0x5e,0x06,0x01,0xe9,0x13,0x77,0x20,0x04,0x5f,0x09,0x00,0x18,0x41,0xbf,0xa4,0xfa,0x7f,0x00,0x00,0xe8,0x63,0xeb,0xb4,0x5f,0x5e,0x00,0x01,0xe8,0x5b,0xeb,0xb4,0x5f,0x5e,0x04,0x00,0x10,0x42,0xbf,0xa4,0xfa,0x7f,0x00,0x00,0xe8,0x4b,0xeb,0xb4,0x5f,0x5e,0x00,0x00,0x40,0x43,0xbf,0xa4,0xfa,0x7f,0x00,0x00,0xe8,0x3b,0xeb,0xb4,0x5f,0x5e,0x00,0x0c,0xe8,0x33,0xeb,0xb4,0x5f,0x5e,0x02,0x0b,0xe8,0x2b,0xeb,0xb4,0x5f,0x5e,0x04,0x0a,0xe8,0x23,0xeb,0xb4,0x5f,0x5e,0x06,0x09,0xe8,0x1b,0xeb,0xb4,0x5f,0x5e,0x08,0x08,0xe8,0x13,0xeb,0xb4,0x5f,0x5e,0x0a,0x07,0xe8,0x0b,0xeb,0xb4,0x5f,0x5e,0x0c,0x06,0xe8,0x03,0xeb,0xb4,0x5f,0x5e,0x0e,0x05,0xe8,0xfb,0xea,0xb4,0x5f,0x5e,0x10,0x04,0xe8,0xf3,0xea,0xb4,0x5f,0x5e,0x12,0x03,0xe8,0xeb,0xea,0xb4,0x5f,0x5e,0x14,0x02,0xe8,0xe3,0xea,0xb4,0x5f,0x5e,0x16,0x01,0xe8,0xdb,0xea,0xb4,0x5f,0x5e,0x18,0x00,0x60,0x44,0xbf,0xa4,0xfa,0x7f,0x00,0x00,0xe9,0xeb,0x42,0x00,0x00,0x5f,0x00};
; BaseAddress = 7ffaa499aca0h
; TermCode = CTC_Zx7
0000h jmp near ptr 420e9e0h                         ; JMP rel32                        | E9 cd                            | 5   | e9 db e9 20 04
0005h pop rdi                                       ; POP r64                          | 58 +ro                           | 1   | 5f


; 00007FFAA499ACA0 E9 DB E9 20 04       jmp         Z0.Sigs.invoke(Int32 (Int32, Int32), Int32, Int32) (07FFAA8BA9680h)
; 00007FFAA499ACA5 5F                   pop         rdi

; 00007FFAA8BA9680 55                   push        rbp
; 00007FFAA8BA9681 41 57                push        r15
; 00007FFAA8BA9683 41 56                push        r14
; 00007FFAA8BA9685 41 55                push        r13
; 00007FFAA8BA9687 41 54                push        r12
; 00007FFAA8BA9689 57                   push        rdi
; 00007FFAA8BA968A 56                   push        rsi
; 00007FFAA8BA968B 53                   push        rbx
; 00007FFAA8BA968C 48 83 EC 68          sub         rsp,68h
; 00007FFAA8BA9690 48 8D AC 24 A0 00 00 00 lea         rbp,[rsp+0A0h]
; 00007FFAA8BA9698 48 8B F1             mov         rsi,rcx
; 00007FFAA8BA969B 8B FA                mov         edi,edx
; 00007FFAA8BA969D 41 8B D8             mov         ebx,r8d
; 00007FFAA8BA96A0 48 8D 4D 88          lea         rcx,[rbp-78h]
; 00007FFAA8BA96A4 49 8B D2             mov         rdx,r10
; 00007FFAA8BA96A7 E8 04 1E 8E 5B       call        JIT_InitPInvokeFrame (07FFB0448B4B0h)
; 00007FFAA8BA96AC 4C 8B F0             mov         r14,rax
; 00007FFAA8BA96AF 48 8B CC             mov         rcx,rsp
; 00007FFAA8BA96B2 48 89 4D A8          mov         qword ptr [rbp-58h],rcx
; 00007FFAA8BA96B6 48 8B CD             mov         rcx,rbp
; 00007FFAA8BA96B9 48 89 4D B8          mov         qword ptr [rbp-48h],rcx
; 00007FFAA8BA96BD 8B CF                mov         ecx,edi
; 00007FFAA8BA96BF 8B D3                mov         edx,ebx
; 00007FFAA8BA96C1 48 8D 05 13 00 00 00 lea         rax,[Z0.Sigs.invoke(Int32 (Int32, Int32), Int32, Int32)+05Bh (07FFAA8BA96DBh)]
; 00007FFAA8BA96C8 48 89 45 B0          mov         qword ptr [rbp-50h],rax
; 00007FFAA8BA96CC 48 8D 45 88          lea         rax,[rbp-78h]
; 00007FFAA8BA96D0 49 89 46 10          mov         qword ptr [r14+10h],rax
; 00007FFAA8BA96D4 41 C6 46 0C 00       mov         byte ptr [r14+0Ch],0
; 00007FFAA8BA96D9 FF D6                call        rsi
; 00007FFAA8BA96DB 41 C6 46 0C 01       mov         byte ptr [r14+0Ch],1
; 00007FFAA8BA96E0 83 3D 95 49 CB 5B 00 cmp         dword ptr [g_TrapReturningThreads (07FFB0485E07Ch)],0
; 00007FFAA8BA96E7 74 06                je          Z0.Sigs.invoke(Int32 (Int32, Int32), Int32, Int32)+06Fh (07FFAA8BA96EFh)
; 00007FFAA8BA96E9 FF 15 79 6C CA 5B    call        qword ptr [hlpDynamicFuncTable+0A8h (07FFB04850368h)]
; 00007FFAA8BA96EF 48 8B 55 90          mov         rdx,qword ptr [rbp-70h]
; 00007FFAA8BA96F3 49 89 56 10          mov         qword ptr [r14+10h],rdx
; 00007FFAA8BA96F7 48 8D 65 C8          lea         rsp,[rbp-38h]
; 00007FFAA8BA96FB 5B                   pop         rbx
; 00007FFAA8BA96FC 5E                   pop         rsi
; 00007FFAA8BA96FD 5F                   pop         rdi
; 00007FFAA8BA96FE 41 5C                pop         r12
; 00007FFAA8BA9700 41 5D                pop         r13
; 00007FFAA8BA9702 41 5E                pop         r14
; 00007FFAA8BA9704 41 5F                pop         r15
; 00007FFAA8BA9706 5D                   pop         rbp
; 00007FFAA8BA9707 C3                   ret


; --- D:\workspace\_work\1\s\src\coreclr\src\vm\jithelpers.cpp -------------------
; 00007FFB0448B4B0 44 8B 05 79 8A 3C 00 mov         r8d,dword ptr [_tls_index (07FFB04853F30h)]
; 00007FFB0448B4B7 4C 8B C9             mov         r9,rcx
; 00007FFB0448B4BA 65 48 8B 04 25 58 00 00 00 mov         rax,qword ptr gs:[58h]
; 00007FFB0448B4C3 B9 30 01 00 00       mov         ecx,130h
; 00007FFB0448B4C8 4A 8B 04 C0          mov         rax,qword ptr [rax+r8*8]
; 00007FFB0448B4CC 48 8B 04 01          mov         rax,qword ptr [rcx+rax]
; 00007FFB0448B4D0 48 8D 0D 61 87 33 00 lea         rcx,[InlinedCallFrame::`vftable' (07FFB047C3C38h)]
; 00007FFB0448B4D7 49 89 09             mov         qword ptr [r9],rcx
; 00007FFB0448B4DA 33 C9                xor         ecx,ecx
; 00007FFB0448B4DC 4C 8B 05 DD 63 32 00 mov         r8,qword ptr [s_gsCookie (07FFB047B18C0h)]
; 00007FFB0448B4E3 4D 89 41 F8          mov         qword ptr [r9-8],r8
; 00007FFB0448B4E7 49 89 49 10          mov         qword ptr [r9+10h],rcx
; 00007FFB0448B4EB 49 89 49 20          mov         qword ptr [r9+20h],rcx
; 00007FFB0448B4EF 49 89 49 28          mov         qword ptr [r9+28h],rcx
; 00007FFB0448B4F3 49 89 51 18          mov         qword ptr [r9+18h],rdx
; 00007FFB0448B4F7 48 8B 48 10          mov         rcx,qword ptr [rax+10h]
; 00007FFB0448B4FB 49 89 49 08          mov         qword ptr [r9+8],rcx
; 00007FFB0448B4FF C3                   ret

; ----------------------------------------------------------------------------------------------------------------------------------------------------------------
; int run1(in CodeBuffers src)::located://asmrun/sigclient?run1#run1_(CodeBuffers~in)
; public static ReadOnlySpan<byte> run1_ᐤCodeBuffersᕀinᐤ => new byte[191]{0xe9,0xa3,0xca,0x23,0x04,0x5f,0x03,0x02,0xe9,0x5b,0xcb,0x23,0x04,0x5f,0x06,0x01,0xe9,0x13,0x77,0x20,0x04,0x5f,0x09,0x00,0x18,0x41,0xbf,0xa4,0xfa,0x7f,0x00,0x00,0xe8,0x63,0xeb,0xb4,0x5f,0x5e,0x00,0x01,0xe8,0x5b,0xeb,0xb4,0x5f,0x5e,0x04,0x00,0x10,0x42,0xbf,0xa4,0xfa,0x7f,0x00,0x00,0xe8,0x4b,0xeb,0xb4,0x5f,0x5e,0x00,0x00,0x40,0x43,0xbf,0xa4,0xfa,0x7f,0x00,0x00,0xe8,0x3b,0xeb,0xb4,0x5f,0x5e,0x00,0x0c,0xe8,0x33,0xeb,0xb4,0x5f,0x5e,0x02,0x0b,0xe8,0x2b,0xeb,0xb4,0x5f,0x5e,0x04,0x0a,0xe8,0x23,0xeb,0xb4,0x5f,0x5e,0x06,0x09,0xe8,0x1b,0xeb,0xb4,0x5f,0x5e,0x08,0x08,0xe8,0x13,0xeb,0xb4,0x5f,0x5e,0x0a,0x07,0xe8,0x0b,0xeb,0xb4,0x5f,0x5e,0x0c,0x06,0xe8,0x03,0xeb,0xb4,0x5f,0x5e,0x0e,0x05,0xe8,0xfb,0xea,0xb4,0x5f,0x5e,0x10,0x04,0xe8,0xf3,0xea,0xb4,0x5f,0x5e,0x12,0x03,0xe8,0xeb,0xea,0xb4,0x5f,0x5e,0x14,0x02,0xe8,0xe3,0xea,0xb4,0x5f,0x5e,0x16,0x01,0xe8,0xdb,0xea,0xb4,0x5f,0x5e,0x18,0x00,0x60,0x44,0xbf,0xa4,0xfa,0x7f,0x00,0x00,0xe9,0xeb,0x42,0x00,0x00,0x5f,0x00};
; BaseAddress = 7ffaa499acb8h
; TermCode = CTC_Zx7
0000h jmp near ptr 423caa8h                         ; JMP rel32                        | E9 cd                            | 5   | e9 a3 ca 23 04
0005h pop rdi                                       ; POP r64                          | 58 +ro                           | 1   | 5f

; 00007FFAA499ACB8 E9 A3 CA 23 04       jmp         Z0.SigClient.run1(Z0.CodeBuffers ByRef) (07FFAA8BD7760h)
; 00007FFAA499ACBD 5F                   pop         rdi

; 00007FFAA8BD7760 55                   push        rbp
; 00007FFAA8BD7761 41 57                push        r15
; 00007FFAA8BD7763 41 56                push        r14
; 00007FFAA8BD7765 41 55                push        r13
; 00007FFAA8BD7767 41 54                push        r12
; 00007FFAA8BD7769 57                   push        rdi
; 00007FFAA8BD776A 56                   push        rsi
; 00007FFAA8BD776B 53                   push        rbx
; 00007FFAA8BD776C 48 83 EC 68          sub         rsp,68h
; 00007FFAA8BD7770 48 8D AC 24 A0 00 00 00 lea         rbp,[rsp+0A0h]
; 00007FFAA8BD7778 48 8D 4D 88          lea         rcx,[rbp-78h]
; 00007FFAA8BD777C 49 8B D2             mov         rdx,r10
; 00007FFAA8BD777F E8 2C 3D 8B 5B       call        JIT_InitPInvokeFrame (07FFB0448B4B0h)
; 00007FFAA8BD7784 48 8B F0             mov         rsi,rax
; 00007FFAA8BD7787 48 8B CC             mov         rcx,rsp
; 00007FFAA8BD778A 48 89 4D A8          mov         qword ptr [rbp-58h],rcx
; 00007FFAA8BD778E 48 8B CD             mov         rcx,rbp
; 00007FFAA8BD7791 48 89 4D B8          mov         qword ptr [rbp-48h],rcx
; 00007FFAA8BD7795 B9 2A 00 00 00       mov         ecx,2Ah
; 00007FFAA8BD779A BA 7A 01 00 00       mov         edx,17Ah
; 00007FFAA8BD779F 48 8D 05 1C 00 00 00 lea         rax,[Z0.SigClient.run1(Z0.CodeBuffers ByRef)+062h (07FFAA8BD77C2h)]
; 00007FFAA8BD77A6 48 89 45 B0          mov         qword ptr [rbp-50h],rax
; 00007FFAA8BD77AA 48 8D 45 88          lea         rax,[rbp-78h]
; 00007FFAA8BD77AE 48 89 46 10          mov         qword ptr [rsi+10h],rax
; 00007FFAA8BD77B2 C6 46 0C 00          mov         byte ptr [rsi+0Ch],0
; 00007FFAA8BD77B6 48 B8 B0 13 19 02 FB 7F 00 00 mov         rax,7FFB021913B0h
; 00007FFAA8BD77C0 FF D0                call        rax
; 00007FFAA8BD77C2 C6 46 0C 01          mov         byte ptr [rsi+0Ch],1
; 00007FFAA8BD77C6 83 3D AF 68 C8 5B 00 cmp         dword ptr [g_TrapReturningThreads (07FFB0485E07Ch)],0
; 00007FFAA8BD77CD 74 06                je          Z0.SigClient.run1(Z0.CodeBuffers ByRef)+075h (07FFAA8BD77D5h)
; 00007FFAA8BD77CF FF 15 93 8B C7 5B    call        qword ptr [hlpDynamicFuncTable+0A8h (07FFB04850368h)]
; 00007FFAA8BD77D5 48 8B 55 90          mov         rdx,qword ptr [rbp-70h]
; 00007FFAA8BD77D9 48 89 56 10          mov         qword ptr [rsi+10h],rdx
; 00007FFAA8BD77DD 48 8D 65 C8          lea         rsp,[rbp-38h]
; 00007FFAA8BD77E1 5B                   pop         rbx
; 00007FFAA8BD77E2 5E                   pop         rsi
; 00007FFAA8BD77E3 5F                   pop         rdi
; 00007FFAA8BD77E4 41 5C                pop         r12
; 00007FFAA8BD77E6 41 5D                pop         r13
; 00007FFAA8BD77E8 41 5E                pop         r14
; 00007FFAA8BD77EA 41 5F                pop         r15
; 00007FFAA8BD77EC 5D                   pop         rbp
; 00007FFAA8BD77ED C3                   ret
