#ifndef _FFQLAY_H_
#define _FFQLAY_H_

#define FFQLAY_ERROR_NONE	0
#define FFQLAY_ERROR_SDL	1
#define FFQLAY_ERROR_SWS	2
#define FFQLAY_ERROR_OPTION	3

#define FFQLAY_PLAY_STATE_NONE		0
#define FFQLAY_PLAY_STATE_PLAYING	1
#define FFQLAY_PLAY_STATE_PAUSED	2
#define FFQLAY_PLAY_STATE_ABORT		3
#define FFQLAY_PLAY_STATE_STOPPED	4

__declspec (dllexport) int FFQLAY_start(int argc, char **argv, HWND hwndParent, int width, int height);
__declspec (dllexport) int FFQLAY_add(int a,int b);

__declspec (dllexport) int FFQLAY_pause(void);

__declspec (dllexport) int FFQLAY_stop(void);
__declspec (dllexport) double FFQLAY_get_position(void);
__declspec (dllexport) int FFQLAY_set_position(double position);
__declspec (dllexport) double FFQLAY_get_duration(void);
__declspec (dllexport) int FFQLAY_resize(int width, int height);
__declspec (dllexport) int FFQLAY_get_play_state(void);
__declspec (dllexport) int FFQLAY_get_volume(void);
__declspec (dllexport) int FFQLAY_set_volume(int volume);
__declspec (dllexport) int FFQLAY_quit(void);


#endif
