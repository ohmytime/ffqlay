using System;
using System.Text;
using System.Runtime.InteropServices;

namespace ffqlayDemo
{
	/// <summary>
	/// Summary description for FLVPlayerLib.
	/// </summary>
	public class FFQlay
	{
		public enum PlayState {None, Playing, Paused, Abort, Stopped};
		//
		[DllImport("ffqlay.dll")]
		public static extern int FFQLAY_start(int argc, [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStr)] IntPtr[] argv, IntPtr hwndParent, int width, int height);
		[DllImport("ffqlay.dll")]
		public static extern int FFQLAY_pause();
		[DllImport("ffqlay.dll")]
		public static extern int FFQLAY_stop();
		[DllImport("ffqlay.dll")]
		public static extern double FFQLAY_get_duration();
		[DllImport("ffqlay.dll")]
		public static extern double FFQLAY_get_position();
		[DllImport("ffqlay.dll")]
		public static extern int FFQLAY_set_position(double position);
		[DllImport("ffqlay.dll")]
		public static extern int FFQLAY_resize(int width, int height);
		[DllImport("ffqlay.dll")]
		public static extern int FFQLAY_get_play_state();
        //by liqingyu 2013.04.11 start
        [DllImport("ffqlay.dll")]
		public static extern int FFQLAY_quit();
        //by end 
		//
		public static void FFQLAY_start(string fileName, IntPtr hwndParent, int width, int height)
		{
			IntPtr[] argv = new IntPtr[2];
			argv[0] = Marshal.StringToHGlobalAnsi("ffqlay.exe");
			argv[1] = Marshal.StringToHGlobalAnsi(fileName);
			FFQLAY_start(2, argv, hwndParent, width, height);
		}
	}
}
