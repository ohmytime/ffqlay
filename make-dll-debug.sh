rm ffplay.d ffplay.o
rm ffqlay.dll
gcc -I. -I./ -D_ISOC99_SOURCE -D_FILE_OFFSET_BITS=64 \
-D_LARGEFILE_SOURCE -U__STRICT_ANSI__ -I/pluginlibs/include -g -std=c99 \
-I/mingw/include/SDL -D_GNU_SOURCE=1 -Dmain=SDL_main -g -Wdeclaration-after-statement \
-Wall -Wno-parentheses -Wno-switch -Wno-format-zero-length -Wdisabled-optimization \
-Wpointer-arith -Wredundant-decls -Wno-pointer-sign -Wwrite-strings -Wtype-limits \
-Wundef -Wmissing-prototypes -Wno-pointer-to-int-cast -Wstrict-prototypes  -fno-math-errno \
-fno-signed-zeros -fno-tree-vectorize -Werror=implicit-function-declaration \
-Werror=missing-prototypes -Werror=return-type -Werror=vla  -I/mingw/include/SDL \
-D_GNU_SOURCE=1 -Dmain=SDL_main -MMD -MF ffplay.d -MT ffplay.o -c -o ffplay.o ffplay.c
gcc -Llibavcodec -Llibavdevice -Llibavfilter -Llibavformat -Llibavresample -Llibavutil \
-Llibpostproc -Llibswscale -Llibswresample -L/pluginlibs/lib -g  -Wl,--as-needed -Wl,--warn-common \
-Wl,-rpath-link=libpostproc:libswresample:libswscale:libavfilter:libavdevice:libavformat:libavcodec:libavutil:libavresample \
-o ffqlay.dll ffplay.o cmdutils.o -s -shared -Wl,--subsystem,windows \
-lavdevice -lavfilter -lavformat -lavcodec -lpostproc -lswresample -lswscale \
-lavutil -lavicap32 -lws2_32 -L/mingw/lib -lmingw32 -lSDLmain -lSDL -lx264 -lm -lbz2 -lz -lpsapi -ladvapi32 -lshell32  \
-L/mingw/lib -lmingw32 -lSDLmain -lSDL
cp -f ffqlay.dll /e/know-how/ffmpeg/ffqlayDemo/bin/Debug