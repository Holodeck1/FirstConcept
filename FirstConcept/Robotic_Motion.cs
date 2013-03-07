using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aldebaran.Proxies;

namespace FirstConcept
{
    class Robotic_Motion
    {
        string ip;
        int port;
        string input = null;
        MotionProxy move = null;

        public Robotic_Motion(string ip, int port)
        {
            input = null;
            this.ip = ip;
            this.port = port;
            if (move == null)
                try
                {
                    move = new MotionProxy(this.ip, port);
                }
                catch { MessageBox.Show("cannot connect to motion proxy"); }



        }
        public string motion(string input)
        {
               if(input.Equals("forward")){

                   move.moveTo(1, 0, 0);

           }
           else if(input.Equals("backward")){
                move.moveTo(-1, 0, 0);
           }
              else if(input.Equals("left")){
                   move.moveTo(0, 1, 0);
           }
                         else if(input.Equals("right")){
                             move.moveTo(0, -1, 0);

           }
            input = "done";
            return input;

        }
        public void wake(){
                 if (!move.robotIsWakeUp()) { move.wakeUp(); } // puts robot into intial position * I think*
                if (move.robotIsWakeUp()) // checks for definite connection
                {
                    move.setFallManagerEnabled(true); // detects fall, and protects
                    MessageBox.Show("You have succesfully connected!");
                    Aldebaran.Proxies.LedsProxy led = new LedsProxy(ip, port); // led proxy
                    led.randomEyes(3);
                    RobotPostureProxy post = new RobotPostureProxy(ip, port);
                    post.goToPosture("StandInit", 1.0f);
    }
}