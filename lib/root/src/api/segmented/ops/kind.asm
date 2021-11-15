0000h nop dword ptr [rax+rax]                 ; NOP r/m32                        | o32 0F 1F /0                     | 5   | 0f 1f 44 00 00
0005h movzx eax,cx                            ; MOVZX r32, r/m16                 | o32 0F B7 /r                     | 3   | 0f b7 c1
0008h cmp eax,40h                             ; CMP r/m32, imm8                  | o32 83 /7 ib                     | 3   | 83 f8 40
000bh ja short 0029h                          ; JA rel8                          | 77 cb                            | 2   | 77 1c
000dh cmp eax,10h                             ; CMP r/m32, imm8                  | o32 83 /7 ib                     | 3   | 83 f8 10
0010h je short 004fh                          ; JE rel8                          | 74 cb                            | 2   | 74 3d
0012h cmp eax,20h                             ; CMP r/m32, imm8                  | o32 83 /7 ib                     | 3   | 83 f8 20
0015h je near ptr 009eh                       ; JE rel32                         | 0F 84 cd                         | 6   | 0f 84 83 00 00 00
001bh cmp eax,40h                             ; CMP r/m32, imm8                  | o32 83 /7 ib                     | 3   | 83 f8 40
001eh je near ptr 0124h                       ; JE rel32                         | 0F 84 cd                         | 6   | 0f 84 00 01 00 00
0024h jmp near ptr 0421h                      ; JMP rel32                        | E9 cd                            | 5   | e9 f8 03 00 00
0029h cmp eax,80h                             ; CMP EAX, imm32                   | o32 3D id                        | 5   | 3d 80 00 00 00
002eh je near ptr 01e4h                       ; JE rel32                         | 0F 84 cd                         | 6   | 0f 84 b0 01 00 00
0034h cmp eax,100h                            ; CMP EAX, imm32                   | o32 3D id                        | 5   | 3d 00 01 00 00
0039h je near ptr 02a4h                       ; JE rel32                         | 0F 84 cd                         | 6   | 0f 84 65 02 00 00
003fh cmp eax,200h                            ; CMP EAX, imm32                   | o32 3D id                        | 5   | 3d 00 02 00 00
0044h je near ptr 0364h                       ; JE rel32                         | 0F 84 cd                         | 6   | 0f 84 1a 03 00 00
004ah jmp near ptr 0421h                      ; JMP rel32                        | E9 cd                            | 5   | e9 d2 03 00 00
004fh cmp edx,20000h                          ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 02 00
0055h ja short 0069h                          ; JA rel8                          | 77 cb                            | 2   | 77 12
0057h cmp edx,10000h                          ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 01 00
005dh je short 007bh                          ; JE rel8                          | 74 cb                            | 2   | 74 1c
005fh cmp edx,20000h                          ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 02 00
0065h je short 0082h                          ; JE rel8                          | 74 cb                            | 2   | 74 1b
0067h jmp short 0097h                         ; JMP rel8                         | EB cb                            | 2   | eb 2e
0069h cmp edx,40000h                          ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 04 00
006fh je short 0090h                          ; JE rel8                          | 74 cb                            | 2   | 74 1f
0071h cmp edx,80000h                          ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 08 00
0077h je short 0089h                          ; JE rel8                          | 74 cb                            | 2   | 74 10
0079h jmp short 0097h                         ; JMP rel8                         | EB cb                            | 2   | eb 1c
007bh mov eax,20010018h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 18 00 01 20
0080h jmp short 0099h                         ; JMP rel8                         | EB cb                            | 2   | eb 17
0082h mov eax,80020018h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 18 00 02 80
0087h jmp short 0099h                         ; JMP rel8                         | EB cb                            | 2   | eb 10
0089h mov eax,80080010h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 10 00 08 80
008eh jmp short 0099h                         ; JMP rel8                         | EB cb                            | 2   | eb 09
0090h mov eax,20040010h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 10 00 04 20
0095h jmp short 0099h                         ; JMP rel8                         | EB cb                            | 2   | eb 02
0097h xor eax,eax                             ; XOR r32, r/m32                   | o32 33 /r                        | 2   | 33 c0
0099h jmp near ptr 0423h                      ; JMP rel32                        | E9 cd                            | 5   | e9 85 03 00 00
009eh cmp edx,40000h                          ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 04 00
00a4h ja short 00c0h                          ; JA rel8                          | 77 cb                            | 2   | 77 1a
00a6h cmp edx,10000h                          ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 01 00
00ach je short 00ech                          ; JE rel8                          | 74 cb                            | 2   | 74 3e
00aeh cmp edx,20000h                          ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 02 00
00b4h je short 00f3h                          ; JE rel8                          | 74 cb                            | 2   | 74 3d
00b6h cmp edx,40000h                          ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 04 00
00bch je short 0101h                          ; JE rel8                          | 74 cb                            | 2   | 74 43
00beh jmp short 011dh                         ; JMP rel8                         | EB cb                            | 2   | eb 5d
00c0h cmp edx,100000h                         ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 10 00
00c6h ja short 00dah                          ; JA rel8                          | 77 cb                            | 2   | 77 12
00c8h cmp edx,80000h                          ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 08 00
00ceh je short 00fah                          ; JE rel8                          | 74 cb                            | 2   | 74 2a
00d0h cmp edx,100000h                         ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 10 00
00d6h je short 010fh                          ; JE rel8                          | 74 cb                            | 2   | 74 37
00d8h jmp short 011dh                         ; JMP rel8                         | EB cb                            | 2   | eb 43
00dah cmp edx,200000h                         ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 20 00
00e0h je short 0108h                          ; JE rel8                          | 74 cb                            | 2   | 74 26
00e2h cmp edx,2000000h                        ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 00 02
00e8h je short 0116h                          ; JE rel8                          | 74 cb                            | 2   | 74 2c
00eah jmp short 011dh                         ; JMP rel8                         | EB cb                            | 2   | eb 31
00ech mov eax,20010028h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 28 00 01 20
00f1h jmp short 011fh                         ; JMP rel8                         | EB cb                            | 2   | eb 2c
00f3h mov eax,80020028h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 28 00 02 80
00f8h jmp short 011fh                         ; JMP rel8                         | EB cb                            | 2   | eb 25
00fah mov eax,80080030h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 30 00 08 80
00ffh jmp short 011fh                         ; JMP rel8                         | EB cb                            | 2   | eb 1e
0101h mov eax,20040030h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 30 00 04 20
0106h jmp short 011fh                         ; JMP rel8                         | EB cb                            | 2   | eb 17
0108h mov eax,80200020h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 20 00 20 80
010dh jmp short 011fh                         ; JMP rel8                         | EB cb                            | 2   | eb 10
010fh mov eax,20100020h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 20 00 10 20
0114h jmp short 011fh                         ; JMP rel8                         | EB cb                            | 2   | eb 09
0116h mov eax,42000020h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 20 00 00 42
011bh jmp short 011fh                         ; JMP rel8                         | EB cb                            | 2   | eb 02
011dh xor eax,eax                             ; XOR r32, r/m32                   | o32 33 /r                        | 2   | 33 c0
011fh jmp near ptr 0423h                      ; JMP rel32                        | E9 cd                            | 5   | e9 ff 02 00 00
0124h cmp edx,100000h                         ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 10 00
012ah ja short 0163h                          ; JA rel8                          | 77 cb                            | 2   | 77 37
012ch cmp edx,20000h                          ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 02 00
0132h ja short 0149h                          ; JA rel8                          | 77 cb                            | 2   | 77 15
0134h cmp edx,10000h                          ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 01 00
013ah je short 0197h                          ; JE rel8                          | 74 cb                            | 2   | 74 5b
013ch cmp edx,20000h                          ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 02 00
0142h je short 019eh                          ; JE rel8                          | 74 cb                            | 2   | 74 5a
0144h jmp near ptr 01ddh                      ; JMP rel32                        | E9 cd                            | 5   | e9 94 00 00 00
0149h cmp edx,40000h                          ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 04 00
014fh je short 01a5h                          ; JE rel8                          | 74 cb                            | 2   | 74 54
0151h cmp edx,80000h                          ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 08 00
0157h je short 01ach                          ; JE rel8                          | 74 cb                            | 2   | 74 53
0159h cmp edx,100000h                         ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 10 00
015fh je short 01b3h                          ; JE rel8                          | 74 cb                            | 2   | 74 52
0161h jmp short 01ddh                         ; JMP rel8                         | EB cb                            | 2   | eb 7a
0163h cmp edx,400000h                         ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 40 00
0169h ja short 017dh                          ; JA rel8                          | 77 cb                            | 2   | 77 12
016bh cmp edx,200000h                         ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 20 00
0171h je short 01bah                          ; JE rel8                          | 74 cb                            | 2   | 74 47
0173h cmp edx,400000h                         ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 40 00
0179h je short 01c1h                          ; JE rel8                          | 74 cb                            | 2   | 74 46
017bh jmp short 01ddh                         ; JMP rel8                         | EB cb                            | 2   | eb 60
017dh cmp edx,800000h                         ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 80 00
0183h je short 01c8h                          ; JE rel8                          | 74 cb                            | 2   | 74 43
0185h cmp edx,2000000h                        ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 00 02
018bh je short 01cfh                          ; JE rel8                          | 74 cb                            | 2   | 74 42
018dh cmp edx,4000000h                        ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 00 04
0193h je short 01d6h                          ; JE rel8                          | 74 cb                            | 2   | 74 41
0195h jmp short 01ddh                         ; JMP rel8                         | EB cb                            | 2   | eb 46
0197h mov eax,20010048h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 48 00 01 20
019ch jmp short 01dfh                         ; JMP rel8                         | EB cb                            | 2   | eb 41
019eh mov eax,80020048h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 48 00 02 80
01a3h jmp short 01dfh                         ; JMP rel8                         | EB cb                            | 2   | eb 3a
01a5h mov eax,20040050h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 50 00 04 20
01aah jmp short 01dfh                         ; JMP rel8                         | EB cb                            | 2   | eb 33
01ach mov eax,80080050h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 50 00 08 80
01b1h jmp short 01dfh                         ; JMP rel8                         | EB cb                            | 2   | eb 2c
01b3h mov eax,80200060h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 60 00 20 80
01b8h jmp short 01dfh                         ; JMP rel8                         | EB cb                            | 2   | eb 25
01bah mov eax,80200060h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 60 00 20 80
01bfh jmp short 01dfh                         ; JMP rel8                         | EB cb                            | 2   | eb 1e
01c1h mov eax,20400040h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 40 00 40 20
01c6h jmp short 01dfh                         ; JMP rel8                         | EB cb                            | 2   | eb 17
01c8h mov eax,80800040h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 40 00 80 80
01cdh jmp short 01dfh                         ; JMP rel8                         | EB cb                            | 2   | eb 10
01cfh mov eax,42000060h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 60 00 00 42
01d4h jmp short 01dfh                         ; JMP rel8                         | EB cb                            | 2   | eb 09
01d6h mov eax,44000040h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 40 00 00 44
01dbh jmp short 01dfh                         ; JMP rel8                         | EB cb                            | 2   | eb 02
01ddh xor eax,eax                             ; XOR r32, r/m32                   | o32 33 /r                        | 2   | 33 c0
01dfh jmp near ptr 0423h                      ; JMP rel32                        | E9 cd                            | 5   | e9 3f 02 00 00
01e4h cmp edx,100000h                         ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 10 00
01eah ja short 0223h                          ; JA rel8                          | 77 cb                            | 2   | 77 37
01ech cmp edx,20000h                          ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 02 00
01f2h ja short 0209h                          ; JA rel8                          | 77 cb                            | 2   | 77 15
01f4h cmp edx,10000h                          ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 01 00
01fah je short 0257h                          ; JE rel8                          | 74 cb                            | 2   | 74 5b
01fch cmp edx,20000h                          ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 02 00
0202h je short 025eh                          ; JE rel8                          | 74 cb                            | 2   | 74 5a
0204h jmp near ptr 029dh                      ; JMP rel32                        | E9 cd                            | 5   | e9 94 00 00 00
0209h cmp edx,40000h                          ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 04 00
020fh je short 0265h                          ; JE rel8                          | 74 cb                            | 2   | 74 54
0211h cmp edx,80000h                          ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 08 00
0217h je short 026ch                          ; JE rel8                          | 74 cb                            | 2   | 74 53
0219h cmp edx,100000h                         ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 10 00
021fh je short 0273h                          ; JE rel8                          | 74 cb                            | 2   | 74 52
0221h jmp short 029dh                         ; JMP rel8                         | EB cb                            | 2   | eb 7a
0223h cmp edx,400000h                         ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 40 00
0229h ja short 023dh                          ; JA rel8                          | 77 cb                            | 2   | 77 12
022bh cmp edx,200000h                         ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 20 00
0231h je short 027ah                          ; JE rel8                          | 74 cb                            | 2   | 74 47
0233h cmp edx,400000h                         ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 40 00
0239h je short 0281h                          ; JE rel8                          | 74 cb                            | 2   | 74 46
023bh jmp short 029dh                         ; JMP rel8                         | EB cb                            | 2   | eb 60
023dh cmp edx,800000h                         ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 80 00
0243h je short 0288h                          ; JE rel8                          | 74 cb                            | 2   | 74 43
0245h cmp edx,2000000h                        ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 00 02
024bh je short 028fh                          ; JE rel8                          | 74 cb                            | 2   | 74 42
024dh cmp edx,4000000h                        ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 00 04
0253h je short 0296h                          ; JE rel8                          | 74 cb                            | 2   | 74 41
0255h jmp short 029dh                         ; JMP rel8                         | EB cb                            | 2   | eb 46
0257h mov eax,20010088h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 88 00 01 20
025ch jmp short 029fh                         ; JMP rel8                         | EB cb                            | 2   | eb 41
025eh mov eax,80020088h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 88 00 02 80
0263h jmp short 029fh                         ; JMP rel8                         | EB cb                            | 2   | eb 3a
0265h mov eax,20040090h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 90 00 04 20
026ah jmp short 029fh                         ; JMP rel8                         | EB cb                            | 2   | eb 33
026ch mov eax,80080090h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 90 00 08 80
0271h jmp short 029fh                         ; JMP rel8                         | EB cb                            | 2   | eb 2c
0273h mov eax,802000a0h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 a0 00 20 80
0278h jmp short 029fh                         ; JMP rel8                         | EB cb                            | 2   | eb 25
027ah mov eax,802000a0h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 a0 00 20 80
027fh jmp short 029fh                         ; JMP rel8                         | EB cb                            | 2   | eb 1e
0281h mov eax,204000c0h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 c0 00 40 20
0286h jmp short 029fh                         ; JMP rel8                         | EB cb                            | 2   | eb 17
0288h mov eax,808000c0h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 c0 00 80 80
028dh jmp short 029fh                         ; JMP rel8                         | EB cb                            | 2   | eb 10
028fh mov eax,420000a0h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 a0 00 00 42
0294h jmp short 029fh                         ; JMP rel8                         | EB cb                            | 2   | eb 09
0296h mov eax,440000c0h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 c0 00 00 44
029bh jmp short 029fh                         ; JMP rel8                         | EB cb                            | 2   | eb 02
029dh xor eax,eax                             ; XOR r32, r/m32                   | o32 33 /r                        | 2   | 33 c0
029fh jmp near ptr 0423h                      ; JMP rel32                        | E9 cd                            | 5   | e9 7f 01 00 00
02a4h cmp edx,100000h                         ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 10 00
02aah ja short 02e3h                          ; JA rel8                          | 77 cb                            | 2   | 77 37
02ach cmp edx,20000h                          ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 02 00
02b2h ja short 02c9h                          ; JA rel8                          | 77 cb                            | 2   | 77 15
02b4h cmp edx,10000h                          ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 01 00
02bah je short 0317h                          ; JE rel8                          | 74 cb                            | 2   | 74 5b
02bch cmp edx,20000h                          ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 02 00
02c2h je short 031eh                          ; JE rel8                          | 74 cb                            | 2   | 74 5a
02c4h jmp near ptr 035dh                      ; JMP rel32                        | E9 cd                            | 5   | e9 94 00 00 00
02c9h cmp edx,40000h                          ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 04 00
02cfh je short 0325h                          ; JE rel8                          | 74 cb                            | 2   | 74 54
02d1h cmp edx,80000h                          ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 08 00
02d7h je short 032ch                          ; JE rel8                          | 74 cb                            | 2   | 74 53
02d9h cmp edx,100000h                         ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 10 00
02dfh je short 0333h                          ; JE rel8                          | 74 cb                            | 2   | 74 52
02e1h jmp short 035dh                         ; JMP rel8                         | EB cb                            | 2   | eb 7a
02e3h cmp edx,400000h                         ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 40 00
02e9h ja short 02fdh                          ; JA rel8                          | 77 cb                            | 2   | 77 12
02ebh cmp edx,200000h                         ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 20 00
02f1h je short 033ah                          ; JE rel8                          | 74 cb                            | 2   | 74 47
02f3h cmp edx,400000h                         ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 40 00
02f9h je short 0341h                          ; JE rel8                          | 74 cb                            | 2   | 74 46
02fbh jmp short 035dh                         ; JMP rel8                         | EB cb                            | 2   | eb 60
02fdh cmp edx,800000h                         ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 80 00
0303h je short 0348h                          ; JE rel8                          | 74 cb                            | 2   | 74 43
0305h cmp edx,2000000h                        ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 00 02
030bh je short 034fh                          ; JE rel8                          | 74 cb                            | 2   | 74 42
030dh cmp edx,4000000h                        ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 00 04
0313h je short 0356h                          ; JE rel8                          | 74 cb                            | 2   | 74 41
0315h jmp short 035dh                         ; JMP rel8                         | EB cb                            | 2   | eb 46
0317h mov eax,20010108h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 08 01 01 20
031ch jmp short 035fh                         ; JMP rel8                         | EB cb                            | 2   | eb 41
031eh mov eax,80020108h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 08 01 02 80
0323h jmp short 035fh                         ; JMP rel8                         | EB cb                            | 2   | eb 3a
0325h mov eax,20040110h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 10 01 04 20
032ah jmp short 035fh                         ; JMP rel8                         | EB cb                            | 2   | eb 33
032ch mov eax,80080110h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 10 01 08 80
0331h jmp short 035fh                         ; JMP rel8                         | EB cb                            | 2   | eb 2c
0333h mov eax,80200120h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 20 01 20 80
0338h jmp short 035fh                         ; JMP rel8                         | EB cb                            | 2   | eb 25
033ah mov eax,80200120h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 20 01 20 80
033fh jmp short 035fh                         ; JMP rel8                         | EB cb                            | 2   | eb 1e
0341h mov eax,20400140h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 40 01 40 20
0346h jmp short 035fh                         ; JMP rel8                         | EB cb                            | 2   | eb 17
0348h mov eax,80800140h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 40 01 80 80
034dh jmp short 035fh                         ; JMP rel8                         | EB cb                            | 2   | eb 10
034fh mov eax,42000120h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 20 01 00 42
0354h jmp short 035fh                         ; JMP rel8                         | EB cb                            | 2   | eb 09
0356h mov eax,44000140h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 40 01 00 44
035bh jmp short 035fh                         ; JMP rel8                         | EB cb                            | 2   | eb 02
035dh xor eax,eax                             ; XOR r32, r/m32                   | o32 33 /r                        | 2   | 33 c0
035fh jmp near ptr 0423h                      ; JMP rel32                        | E9 cd                            | 5   | e9 bf 00 00 00
0364h cmp edx,100000h                         ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 10 00
036ah ja short 03a3h                          ; JA rel8                          | 77 cb                            | 2   | 77 37
036ch cmp edx,20000h                          ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 02 00
0372h ja short 0389h                          ; JA rel8                          | 77 cb                            | 2   | 77 15
0374h cmp edx,10000h                          ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 01 00
037ah je short 03d7h                          ; JE rel8                          | 74 cb                            | 2   | 74 5b
037ch cmp edx,20000h                          ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 02 00
0382h je short 03deh                          ; JE rel8                          | 74 cb                            | 2   | 74 5a
0384h jmp near ptr 041dh                      ; JMP rel32                        | E9 cd                            | 5   | e9 94 00 00 00
0389h cmp edx,40000h                          ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 04 00
038fh je short 03e5h                          ; JE rel8                          | 74 cb                            | 2   | 74 54
0391h cmp edx,80000h                          ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 08 00
0397h je short 03ech                          ; JE rel8                          | 74 cb                            | 2   | 74 53
0399h cmp edx,100000h                         ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 10 00
039fh je short 03f3h                          ; JE rel8                          | 74 cb                            | 2   | 74 52
03a1h jmp short 041dh                         ; JMP rel8                         | EB cb                            | 2   | eb 7a
03a3h cmp edx,400000h                         ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 40 00
03a9h ja short 03bdh                          ; JA rel8                          | 77 cb                            | 2   | 77 12
03abh cmp edx,200000h                         ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 20 00
03b1h je short 03fah                          ; JE rel8                          | 74 cb                            | 2   | 74 47
03b3h cmp edx,400000h                         ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 40 00
03b9h je short 0401h                          ; JE rel8                          | 74 cb                            | 2   | 74 46
03bbh jmp short 041dh                         ; JMP rel8                         | EB cb                            | 2   | eb 60
03bdh cmp edx,800000h                         ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 80 00
03c3h je short 0408h                          ; JE rel8                          | 74 cb                            | 2   | 74 43
03c5h cmp edx,2000000h                        ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 00 02
03cbh je short 040fh                          ; JE rel8                          | 74 cb                            | 2   | 74 42
03cdh cmp edx,4000000h                        ; CMP r/m32, imm32                 | o32 81 /7 id                     | 6   | 81 fa 00 00 00 04
03d3h je short 0416h                          ; JE rel8                          | 74 cb                            | 2   | 74 41
03d5h jmp short 041dh                         ; JMP rel8                         | EB cb                            | 2   | eb 46
03d7h mov eax,20010208h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 08 02 01 20
03dch jmp short 041fh                         ; JMP rel8                         | EB cb                            | 2   | eb 41
03deh mov eax,80020208h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 08 02 02 80
03e3h jmp short 041fh                         ; JMP rel8                         | EB cb                            | 2   | eb 3a
03e5h mov eax,20040210h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 10 02 04 20
03eah jmp short 041fh                         ; JMP rel8                         | EB cb                            | 2   | eb 33
03ech mov eax,80080210h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 10 02 08 80
03f1h jmp short 041fh                         ; JMP rel8                         | EB cb                            | 2   | eb 2c
03f3h mov eax,80200220h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 20 02 20 80
03f8h jmp short 041fh                         ; JMP rel8                         | EB cb                            | 2   | eb 25
03fah mov eax,80200220h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 20 02 20 80
03ffh jmp short 041fh                         ; JMP rel8                         | EB cb                            | 2   | eb 1e
0401h mov eax,20400240h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 40 02 40 20
0406h jmp short 041fh                         ; JMP rel8                         | EB cb                            | 2   | eb 17
0408h mov eax,80800240h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 40 02 80 80
040dh jmp short 041fh                         ; JMP rel8                         | EB cb                            | 2   | eb 10
040fh mov eax,42000220h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 20 02 00 42
0414h jmp short 041fh                         ; JMP rel8                         | EB cb                            | 2   | eb 09
0416h mov eax,44000240h                       ; MOV r32, imm32                   | o32 B8+rd id                     | 5   | b8 40 02 00 44
041bh jmp short 041fh                         ; JMP rel8                         | EB cb                            | 2   | eb 02
041dh xor eax,eax                             ; XOR r32, r/m32                   | o32 33 /r                        | 2   | 33 c0
041fh jmp short 0423h                         ; JMP rel8                         | EB cb                            | 2   | eb 02
0421h xor eax,eax                             ; XOR r32, r/m32                   | o32 33 /r                        | 2   | 33 c0
0423h ret                                     ; RET                              | C3                               | 1   | c3