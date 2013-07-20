using System;
using System.Text;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace ffqlayDemo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FFQlayerForm : System.Windows.Forms.Form
	{
        static string fileName = "";
		private System.Windows.Forms.PictureBox pbVideo;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		//
		private FFQlay.PlayState playState = FFQlay.PlayState.None;
		private Bitmap bmPlaying;
		private Bitmap bmPaused;
		private Bitmap bmStopped;
		private System.Timers.Timer timerProgress;
		private double clipDuration = 0.0;
		private FileInfo selectedVideo = null;
		private string basePath = ".\\";
		private System.Windows.Forms.TrackBar tbProgress;
		private System.Windows.Forms.Label lbProgress;
		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.Button btnPlay;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.Panel plToolbar;
		//
		public FFQlayerForm()
		{
			int p = Application.ExecutablePath.LastIndexOf("\\");
			if (p > 0)
			{
				basePath = Application.ExecutablePath.Substring(0, p + 1);
			}
            bmPlaying = Properties.Resources.btnPlayNormal;
            bmPaused = Properties.Resources.btnPauseNormal;
            bmStopped = Properties.Resources.btnStopNormal;
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			//
			btnPlay.Image = bmPlaying;
			btnStop.Image = bmStopped;
			//
			string[] args = System.Environment.GetCommandLineArgs();
			if( args.Length > 1 )
			{
				selectedVideo = new FileInfo(args[1]);
				PlaySelectedVideo();
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.pbVideo = new System.Windows.Forms.PictureBox();
            this.timerProgress = new System.Timers.Timer();
            this.tbProgress = new System.Windows.Forms.TrackBar();
            this.lbProgress = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.plToolbar = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbVideo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timerProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbProgress)).BeginInit();
            this.plToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbVideo
            // 
            this.pbVideo.BackColor = System.Drawing.SystemColors.ControlText;
            this.pbVideo.Location = new System.Drawing.Point(0, 0);
            this.pbVideo.Name = "pbVideo";
            this.pbVideo.Size = new System.Drawing.Size(514, 313);
            this.pbVideo.TabIndex = 0;
            this.pbVideo.TabStop = false;
            // 
            // timerProgress
            // 
            this.timerProgress.Interval = 500;
            this.timerProgress.SynchronizingObject = this;
            this.timerProgress.Elapsed += new System.Timers.ElapsedEventHandler(this.timerProgress_Elapsed);
            // 
            // tbProgress
            // 
            this.tbProgress.Location = new System.Drawing.Point(0, 15);
            this.tbProgress.Maximum = 100;
            this.tbProgress.Name = "tbProgress";
            this.tbProgress.Size = new System.Drawing.Size(434, 45);
            this.tbProgress.TabIndex = 4;
            this.tbProgress.TickFrequency = 5;
            this.tbProgress.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbProgress.Scroll += new System.EventHandler(this.tbProgress_Scroll);
            // 
            // lbProgress
            // 
            this.lbProgress.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbProgress.Location = new System.Drawing.Point(440, 19);
            this.lbProgress.Name = "lbProgress";
            this.lbProgress.Size = new System.Drawing.Size(88, 22);
            this.lbProgress.TabIndex = 5;
            this.lbProgress.Text = "00:00/00:00";
            // 
            // btnOpen
            // 
            this.btnOpen.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnOpen.Location = new System.Drawing.Point(465, 52);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(48, 30);
            this.btnOpen.TabIndex = 9;
            this.btnOpen.Text = "File";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(10, 60);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(28, 22);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(58, 60);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(28, 22);
            this.btnStop.TabIndex = 3;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // plToolbar
            // 
            this.plToolbar.AllowDrop = true;
            this.plToolbar.Controls.Add(this.tbProgress);
            this.plToolbar.Controls.Add(this.lbProgress);
            this.plToolbar.Controls.Add(this.btnOpen);
            this.plToolbar.Controls.Add(this.btnPlay);
            this.plToolbar.Controls.Add(this.btnStop);
            this.plToolbar.Location = new System.Drawing.Point(1, 321);
            this.plToolbar.Name = "plToolbar";
            this.plToolbar.Size = new System.Drawing.Size(522, 92);
            this.plToolbar.TabIndex = 10;
            // 
            // FFQlayerForm
            // 
            this.AllowDrop = true;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(530, 429);
            this.Controls.Add(this.plToolbar);
            this.Controls.Add(this.pbVideo);
            this.Name = "FFQlayerForm";
            this.Text = "ffqlayDemo";
            this.Closed += new System.EventHandler(this.FFQlayerForm_Closed);
            this.Resize += new System.EventHandler(this.FFQlayerForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbVideo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timerProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbProgress)).EndInit();
            this.plToolbar.ResumeLayout(false);
            this.plToolbar.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FFQlayerForm());
		}

		private void SetPlayStatePlaying()
		{
			playState = FFQlay.PlayState.Playing;
			btnPlay.Image = bmPaused;
			btnPlay.Enabled = true;
			btnStop.Enabled = true;
			btnOpen.Enabled = false;
			timerProgress.Enabled = true;
            tbProgress.Enabled = true;

		}
		private void SetPlayStateStopped()
		{
			playState = FFQlay.PlayState.Stopped;
			btnPlay.Image = bmPlaying;
			btnPlay.Enabled = true;
			btnStop.Enabled = false;
			btnOpen.Enabled = true;

            //by liqingyu 2013.04.11 start
            SetProgressString(0, 0);
            tbProgress.Value = 0;
			timerProgress.Enabled = false;
            clipDuration = 0.0;
            selectedVideo = null;
            GC.Collect();
            //by end
            
		}
		private void SetPlayStatePaused()
		{
			playState = FFQlay.PlayState.Paused;
			btnPlay.Image = bmPlaying;
			timerProgress.Enabled = false;
		}
		private string ConvertDurationString(double time)
		{
			int _time = (int) Math.Round(time);
			int min = _time/60;
			int sec = _time%60;
			StringBuilder sb = new StringBuilder();
			if( min < 10 )
				sb.Append("0");
			sb.Append(min);
			sb.Append(":");
			if( sec < 10 )
				sb.Append("0");
			sb.Append(sec);
			return sb.ToString();
		}
		private void SetProgressString(double progress, double duration)
		{
			lbProgress.Text = ConvertDurationString(progress)+"/"+ConvertDurationString(duration);
		}
		private int SelectVideo()
		{
            
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.ShowDialog();
            //by liqingyu 2013.04.12 start
            if (!ofd.FileName.Equals(""))
            {
                fileName = ofd.FileName;
            }
			
            //by end
            if (fileName != null && fileName.Length > 0)
            {
                selectedVideo = new FileInfo(fileName);
            }
            else
            {
                return -1;
            }
            return 1;
		}
		private void PlaySelectedVideo()
		{
            //by liqingyu 2013.04.11 start
            timerProgress.Enabled = true;
            //by end
            if (selectedVideo == null)
            {
                if (fileName != null && fileName.Length > 0)
                {
                    selectedVideo = new FileInfo(fileName);
                }
            }

            FFQlay.FFQLAY_start(selectedVideo.FullName, pbVideo.Handle, pbVideo.Width, pbVideo.Height);
            SetPlayStatePlaying();

            
		}

		private void btnPlay_Click(object sender, System.EventArgs e)
		{
			clipDuration = 0.0;
			if( playState == FFQlay.PlayState.None )
			{
                if (selectedVideo == null)
                { 
                    if(SelectVideo()>0)
                        PlaySelectedVideo();
                }
					
				
			}
			else if( playState == FFQlay.PlayState.Playing )
			{
				FFQlay.FFQLAY_pause();
				SetPlayStatePaused();
			}
			else if( playState == FFQlay.PlayState.Paused )
			{
				FFQlay.FFQLAY_pause();
				SetPlayStatePlaying();
			}
            else if (playState == FFQlay.PlayState.Stopped)
            {
                PlaySelectedVideo();
                /*
                if (fileName!=null && !fileName.Equals(""))
                {
                    FFQlay.FFQLAY_start(selectedVideo.FullName, pbVideo.Handle, pbVideo.Width, pbVideo.Height);
                    SetPlayStatePlaying();
                }*/
            }
		}

		private void btnStop_Click(object sender, System.EventArgs e)
		{
            //by liqingyu 2013.04.11 start
            /*
            if (playState == FFQlay.PlayState.Playing)
            {
                FFQlay.FFQLAY_stop();
                SetPlayStateStopped();
            }*/
   
            FFQlay.FFQLAY_stop();
            SetPlayStateStopped();
            //by end
           
		}

		private void timerProgress_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			playState = (FFQlay.PlayState) FFQlay.FFQLAY_get_play_state();
			if( playState == FFQlay.PlayState.Stopped )
				SetPlayStateStopped();

            if (playState == FFQlay.PlayState.Playing)
            {
                if (clipDuration <= 0.0)
                    clipDuration = FFQlay.FFQLAY_get_duration();
                double position = FFQlay.FFQLAY_get_position();
                if (position < 0)
                    position = 0;
                int progress = (int)(position * 100 / clipDuration);
                if (progress < 0)
                    progress = 0;
                if (progress > 100)
                    progress = 100;
                SetProgressString(position, clipDuration);
                tbProgress.Value = progress;
            }

            //by liqingyu 2013.04.11 start
            else// file play end,we clean the play status
            {
                SetProgressString(0, 0);
                clipDuration = 0;
                timerProgress.Enabled = false;
                tbProgress.Enabled = false;
            }
            //by end
		}

		private void FFQlayerForm_Closed(object sender, System.EventArgs e)
		{
            FFQlay.FFQLAY_quit();
			System.Environment.Exit(0);
            //by liqingyu 2013.04.11 start:Clean the ffplay memory
            //by end
		}

		private void btnOpen_Click(object sender, EventArgs e)
		{
            int ret = -1;
			ret = SelectVideo();
            if (ret > 0)
                PlaySelectedVideo();
            else
                return;
		}

		private void tbProgress_Scroll(object sender, System.EventArgs e)
		{
			if( playState == FFQlay.PlayState.Playing )
			{
				timerProgress.Enabled = false;
				if( clipDuration <= 0.0 )
					clipDuration = FFQlay.FFQLAY_get_duration();
				double position = tbProgress.Value*clipDuration/100;
				FFQlay.FFQLAY_set_position(position);
				timerProgress.Enabled = true;
			}
		}

		private void FFQlayerForm_Resize(object sender, System.EventArgs e)
		{
			pbVideo.Width = this.Width-8;
			pbVideo.Height = this.Height-168;
			int newY = pbVideo.Height;
			int newWidth = pbVideo.Width;
			plToolbar.SetBounds(plToolbar.Location.X, newY, newWidth, plToolbar.Height);
			FFQlay.FFQLAY_resize(pbVideo.Width, pbVideo.Height);
		}
	}
}
