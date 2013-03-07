using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aldebaran.Proxies;



namespace FirstConcept
{

    public partial class Form1 : Form
    {
        private Camera cam = null;
        private const int kColorSpace = 13; // BGR
        private const int kFps = 30;
        private bool _naoCamInitialised;
        private NaoCamImageFormat CurrentImageFormat;
        private Bitmap CamBitmap;
        private Timer timer = new Timer();
        String textToSay;
        String IP = null;
        int x = 0, port = 9559, timeInterval = 500;
       
        public Form1()
        {
            InitializeComponent();
            cam = new Camera();
            CurrentImageFormat = cam.NaoCamImageFormats[0];
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textToSpeach_Click(object sender, EventArgs e)
        {

            Control[] cs = this.Controls.Find("speach", true);
            TextBox tb = (TextBox)cs[0];
            string textToSay = tb.Text;
            this.textToSay = textToSay;
         try{
             TextToSpeechProxy tts = new TextToSpeechProxy(IP, port);
                tts.say(textToSay);
                speach.Text = textToSay;
            }
          catch
            {
                speach.Text = "could not connect!!!";

            }

        }

        private void Connect_Click(object sender, EventArgs e)
        {
            Control[] cs = this.Controls.Find("iPGetter", true);
            TextBox tb = (TextBox)cs[0];
            string ip = tb.Text;
            this.IP = ip;
            try
            {
                MotionProxy wake = new MotionProxy(ip, port);
                if (!wake.robotIsWakeUp()) { wake.wakeUp(); } // puts robot into intial position * I think*
                if (wake.robotIsWakeUp()) // checks for definite connection
                {
                    wake.setFallManagerEnabled(true); // detects fall, and protects
                    MessageBox.Show("You have succesfully connected!");
                    Aldebaran.Proxies.LedsProxy led = new LedsProxy(ip, port); // led proxy
                    led.randomEyes(3);
                    RobotPostureProxy post = new RobotPostureProxy(ip, port);
                    post.goToPosture("StandInit", 1.0f);
                    cam.Connect(ip, CurrentImageFormat, kColorSpace, kFps);
                    CamBitmap = new Bitmap(CurrentImageFormat.width, CurrentImageFormat.height, PixelFormat.Format24bppRgb);
                    timer1.Interval = (int)Math.Ceiling(1000.0 / kFps);
                    _naoCamInitialised = true;
                }

            }
            catch { MessageBox.Show("Primary Connection failed! Oh No!"); }

            if (_naoCamInitialised && !timer1.Enabled)
            {
                timer1.Start();
            }
        }
        void UpdateScreen(object sender, EventArgs e)
        {
            camImageToPictureBox(pictureBox1); // calls the camimage method to fill the picturebox on the form
        }

        private bool updatingPicture = false;
        void camImageToPictureBox(PictureBox pb)
        {
            if (_naoCamInitialised && !updatingPicture)
            {
                updatingPicture = true; // lets the form know its now updating the picture
            }
            try
            {
                byte[] imageBytes = cam.getImage(); // gets a stream of bytes, in the form of an arry from the camera
                if (imageBytes != null)
                {
                    unsafe
                    {
                        BitmapData bm = CamBitmap.LockBits(new Rectangle(0, 0, CamBitmap.Width, CamBitmap.Height), 
                            ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

                        // pixel pointer
                        byte* p = (byte*)bm.Scan0; // byte p, is set to first byte in the bitmap bm
                        int diff = bm.Stride - CamBitmap.Width * 3; // vodoo
                        for (int i = 0; i < imageBytes.Length; i++)
                        {
                            *p++ = imageBytes[i];
                            if (i % (CamBitmap.Width * 3) == 0 && i > 0)
                            {
                                p += diff;
                            }
                        }
                        CamBitmap.UnlockBits(bm);
                    }
                    pb.Image = CamBitmap;
                }
            }
            catch { MessageBox.Show("error connecting to Camera!"); }

        }
        private void forwardClicked_Click(object sender, EventArgs e)
        {
            x = 1;
            // moves robot forward
            if (IP != null) // only activates if IP has been set.
            {
                timer.Tick += new EventHandler(timer_TickForward);// sets a timer, so that you can click inbetween signals
                timer.Interval = (timeInterval);// timer, fires every second can reduce or increase if nessesary.
                timer.Enabled = true;
                timer.Start();

            }
            else
            {
                MessageBox.Show("IP has not been set!");
            }

        }
        private void kill_Click(object sender, EventArgs e)
        {
            this.x = -1; // kills the timer.
            MotionProxy move = new MotionProxy(IP, port);
            move.setWalkArmsEnabled(false, false); //stops the arms
            move.stopMove(); // stops the motion
            Control[] cs = this.Controls.Find("errorTicker", true);
            TextBox tb = (TextBox)cs[0];
            tb.Clear();
            tb.Text = ("motion stopped!");
        }
        void timer_TickForward(object sender, EventArgs e)
        {
          int x = this.x;
          float xAxis, yAxis, theta; // declares motion varibles
          xAxis = (float).1;
          yAxis = (float)0;
          theta = (float)0;
          if (x == -1)
          {
              timer.Enabled = false; // stops timer if kill button has been clicked
          }
          else
          {
              try
              {
                  MotionProxy move = new MotionProxy(IP, port);
                  move.setWalkArmsEnabled(true, true); // starts arms
                  move.moveTo(xAxis, yAxis, theta); // move forward 10 centemeters
                  Control[] cs = this.Controls.Find("errorTicker", true);
                  TextBox tb = (TextBox)cs[0];
                  tb.Clear();
                  tb.Text = ("moving forward!");

              }
              catch
              {
                  MessageBox.Show("Cannot connect to robot!");
              }
          }


        }

        private void moveRightClicked_Click(object sender, EventArgs e)
        {
            x = 1;
            if (IP != null) // only activates if IP has been set.
            {
                timer.Tick += new EventHandler(timer_TickRight);// sets a timer, so that you can click inbetween signals
                timer.Interval = (timeInterval);// timer, fires every second can reduce or increase if nessesary.
                timer.Enabled = true;
                timer.Start();

            }
            else
            {
                MessageBox.Show("IP has not been set!");
            }
        }
        void timer_TickRight(object sender, EventArgs e)
        {
            int x = this.x;
            if (x == -1)
            {
                timer.Enabled = false; // stops timer if kill button has been clicked
            }
            else
            {
                float xAxis, yAxis, theta; // declares motion varibles
                xAxis = (float).1;
                yAxis = (float)-.1;
                theta = (float)-.5;
                try
                {
                    MotionProxy move = new MotionProxy(IP, port);
                    move.setWalkArmsEnabled(true, true); // starts arms
                    move.moveTo(xAxis, yAxis , theta); // rotate right, one radian.
                    Control[] cs = this.Controls.Find("errorTicker", true);
                    TextBox tb = (TextBox)cs[0];
                    tb.Clear();
                    tb.Text = ("moving right!");

                }
                catch
                {
                    MessageBox.Show("Cannot connect to robot!");
                }
            }


        }

        private void moveLeftClicked_Click(object sender, EventArgs e)
        {
            x = 1;
            if (IP != null) // only activates if IP has been set.
            {
                timer.Tick += new EventHandler(timer_TickLeft);// sets a timer, so that you can click inbetween signals
                timer.Interval = (timeInterval);// timer, fires every second can reduce or increase if nessesary.
                timer.Enabled = true;
                timer.Start();
            }
            else
            {
                MessageBox.Show("IP has not been set!");
            }
        }
        void timer_TickLeft(object sender, EventArgs e)
        {
            int x = this.x;
            float xAxis, yAxis, theta; // declares motion varibles
            xAxis = (float)0;
            yAxis = (float).1;
            theta = (float).5;
            if (x == -1)
            {
                timer.Enabled = false; // stops timer if kill button has been clicked
            }
            else
            {
                try
                {
                    MotionProxy move = new MotionProxy(IP, port);
                    move.setWalkArmsEnabled(true, true); // starts arms
                    move.moveTo(xAxis, yAxis, theta); // rotate left, one radian.
                    Control[] cs = this.Controls.Find("errorTicker", true);
                    TextBox tb = (TextBox)cs[0];
                    tb.Clear();
                    tb.Text = ("moving left!");

                }
                catch
                {
                    MessageBox.Show("Cannot connect to robot!");
                }
            }


        }

        private void errorTicker_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MotionProxy move = new MotionProxy(IP, 9559);
            move.rest();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateScreen(sender, e);
        }
        
    }
}
