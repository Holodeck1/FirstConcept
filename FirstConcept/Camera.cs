using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aldebaran.Proxies;
namespace FirstConcept
{
    public struct NaoCamImageFormat
    {
        public string name;
        public int id;
        public int width;
        public int height;
    }
    class Camera
    {
       
        private VideoDeviceProxy VD = null; //creates a new comunicator
        private string ip = ""; //initializes the ip

        public List<NaoCamImageFormat> NaoCamImageFormats = new List<NaoCamImageFormat>(); //creates a list of formats for the camera to use

        public Camera() // camera constructor
        {
            NaoCamImageFormat format0 = new NaoCamImageFormat(); // creates format for low res WiFi
            format0.name = "320 * 240";
            format0.id = 0;
            format0.width = 320;
            format0.height = 240;

            NaoCamImageFormat format1 = new NaoCamImageFormat(); // creates format for med res, gibit ethernet
            format1.name = "640 * 480";
            format1.id = 1;
            format1.width = 640;
            format1.height = 480;
            NaoCamImageFormats.Add(format0);//adds the formats to the list
            NaoCamImageFormats.Add(format1);
        } // end constructor
        public void Connect(string ip , NaoCamImageFormat format, int ColorSpace, int Fps){ // creates the connecting method for camera class
            try
            {
                if (VD != null) //checks to see if already connected
                {
                     Disconnect(); 
                }
                this.ip = ip;
                VD = new VideoDeviceProxy(ip, 9559);
                try { VD.unsubscribe("HolodeckStream"); }
                catch (Exception) { }
                VD.subscribe("HolodeckStream", format.id, ColorSpace, Fps); // links the proxy to particular feed using a format certain format
            }
            catch(Exception e)
            {
                VD = null;
                MessageBox.Show("Camera cannot connect, error. " + e);
            }

        } // end camera connection class
        public void Disconnect()
        {
            try
            {
                if (VD != null)//if connected
                {
                    VD.unsubscribe("HolodeckStream");//set proxy to null
                    VD = null;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Camera cannot disconnect, error. " + e);
            }
        }
        public byte[] getImage() //retreaves the byte data from the camera
        {
            byte[] imageBytes = new byte[0]; // creates new byte array for image, starts at 0
            try
            {
                if (VD != null)
                {
                    object imageObject = VD.getImageRemote("HolodeckStream");
                    imageBytes = (byte[])((ArrayList)imageObject)[6]; //Vodoo. haha, says " Take the 6th element of the imageObject as a byte array" on website
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Camera cannot get data stream. " + e);
            }
            return imageBytes;
        }
        
    }
}
