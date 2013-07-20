./configure --prefix=/FFmpeg/ffqlay-static \
--extra-cflags=-I/pluginlibs/include \
--extra-ldflags=-L/pluginlibs/lib \
--enable-gpl \
--enable-ffplay \
--enable-debug \
\
--disable-doc \
--disable-htmlpages \
--disable-manpages \
--disable-podpages \
--disable-txtpages \
\
--enable-bzlib \
--enable-zlib \
--enable-network \
--enable-libx264 \
\
--disable-parsers \
--enable-parser=h264 \
\
--disable-bsfs \
--enable-bsf=h264_mp4toannexb \
\
--disable-encoders \
--enable-encoder=libx264 \
--enable-encoder=aac \
\
--disable-decoders \
--enable-decoder=h264 \
--enable-decoder=aac \
--enable-decoder=adpcm_g726 \
\
--disable-protocols \
--enable-protocol=file \
--enable-protocol=http \
--enable-protocol=rtmp \
--enable-protocol=rtmpts \
--enable-protocol=tcp \
--enable-protocol=udp \
\
--disable-demuxers \
--enable-demuxer=rtsp \
--enable-demuxer=h264 \
--enable-demuxer=aac \
--enable-demuxer=avi \
--enable-demuxer=avisynth \
\
--disable-muxers \
--enable-muxer=mp4 \
--enable-muxer=avi \
--enable-muxer=h264 \
\
--disable-filters \
--enable-filter=aresample \
\
--enable-static \
--disable-shared > ffqlay-static.txt
