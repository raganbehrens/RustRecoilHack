using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace Compensation
{
    public partial class Form1 : Form
    {
        Thread th;
        bool started = false;
        bool paused = false;
        int[] akX = new int[] { -1, -3, -5, -12, -21, -5, 7, 12, 17, 18, 18, 16, 10, 0, -6 };
        int[] akY = new int[] { 18, 19, 19, 15, 14, 14, 9, 8, 7, 3, 4, 7, 11, 14, 13 };
        int[] akPause = new int[] { 10, 150, 130, 130, 130, 130, 130, 130, 130, 140, 130, 130, 135, 135, 135 };

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, int dx, int dy, uint cButtons, long dwExtraInfo);   

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern int RegisterHotKey(IntPtr hwnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern int UnregisterHotKey(IntPtr hwnd, int id);


        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        public Form1()
        {
            String akString = "AK";
            String lrString = "LR";
            String m2String = "M2";
            String customString = "Custom";
            String thompsonString = "Thompson";

            String ironSightsString = "Iron Sights";
            String holoString = "Holo";
            String simpleString = "Simple Handmade";
            String scopeString = "4x Scope";

            RegisterHotKey(this.Handle, 0, 0, Keys.C.GetHashCode());
            RegisterHotKey(this.Handle, 2, 0x0002, Keys.C.GetHashCode());
            RegisterHotKey(this.Handle, 1, 0, Keys.F2.GetHashCode());
            InitializeComponent();

            weaponBox.Items.Add(akString);
            weaponBox.Items.Add(lrString);
            weaponBox.Items.Add(m2String);
            weaponBox.Items.Add(customString);
            weaponBox.Items.Add(thompsonString);

            opticsBox.Items.Add(ironSightsString);
            opticsBox.Items.Add(holoString);
            opticsBox.Items.Add(simpleString);
            opticsBox.Items.Add(scopeString);

        }


        protected override void WndProc(ref Message m)
        {
            //Thread th = null;
            base.WndProc(ref m);

            if (m.Msg == 0x0312)
            {
                /* Note that the three lines below are not needed if you only want to register one hotkey.
                 * The below lines are useful in case you want to register multiple keys, which you can use a switch with the id as argument, or if you want to know which key/modifier was pressed for some particular reason. */

                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);                  // The key of the hotkey that was pressed.
                //KeyModifier modifier = (KeyModifier)((int)m.LParam & 0xFFFF);       // The modifier of the hotkey that was pressed.
                int id = m.WParam.ToInt32();                                        // The id of the hotkey that was pressed.
                float multiplier = 1;

                int count = 0;
                int direction = 0;
                int loops = 0;
                bool right = false;
                bool left = false;
                //mouse_event(0x02, 0, 0, 0, 0);
                if (id == 1)
                {
                    if (!paused)
                    {
                        textBox1.Text = ("Paused");
                        UnregisterHotKey(this.Handle, 0);
                        paused = true;
                    }
                    else if (paused)
                    {
                        RegisterHotKey(this.Handle, 0, 0, Keys.C.GetHashCode());
                        textBox1.Text = ("Unpaused");
                        paused = false;
                    }

                }

                else
                {
                    if (started != true && !paused)
                    {
                        th = new Thread(shoot);

                        textBox1.Text = ("started");
                        th.Start();
                        started = true;
                    }
                    else if (started == true)
                    {
                        mouse_event(0x04, 0, 0, 0, 0); // mouse up

                        textBox1.Text = ("stopped");
                        started = false;
                        th.Abort();
                    }
                }

                //SendKeys.Send("{^}");



                /*
                while (loops < 2)
                {


                    if (count > 25 && count <= 60)
                    {
                        direction = -1;
                        //multiplier = .6f;
                    }
                    
                    else if (count > 60 && count <= 85)
                    {
                        direction = 1;

                    }

                    else if (count > 85)
                    {
                        direction = -1;
                        count = 25;
                        loops++;
                    }

                    /*
                    else if (count > 100 && count <= 150)
                        direction = 1;

                    else if (count > 150 && count <= 200)
                    {
                        direction = -1;
                        count = 50;
                        loops++;
                    }
                    

                    mouse_event(0x0001, direction, 1, 0, 0);
                    System.Threading.Thread.Sleep((int)(10));
                    //mouse_event(0x0001, 10 * direction, 10, 0, 0);
                    //System.Threading.Thread.Sleep(175);
                    //mouse_event(0x0001, 10 * direction, 10, 0, 0);
                    //System.Threading.Thread.Sleep(175);
                    //mouse_event(0x0001, 10 * direction, 10, 0, 0);
                    //System.Threading.Thread.Sleep(175);
                    //mouse_event(0x0001, 10 * direction, 10, 0, 0);
                    //System.Threading.Thread.Sleep(175);
                    //mouse_event(0x0001, 10 * direction, 10, 0, 0);
                    //System.Threading.Thread.Sleep(175);
                    //direction *= -1;
                    count++;
                }
                */

            }
        }

        public void shoot()
        {
            // Bullet 2 - 160 ms
            // Bullet 3 - 130 ms

            //--------
            // M2
            //--------

            /* 
            System.Threading.Thread.Sleep(100);
            mouse_event(0x02, 0, 0, 0, 0); // shoot

            while (true)
            {
                System.Threading.Thread.Sleep(14);
                mouse_event(0x0001, 3, 10, 0, 0); // recoil for bullet 2
                System.Threading.Thread.Sleep(14);
                mouse_event(0x0001, -3, 10, 0, 0); // recoil for bullet 2

            }
            //mouse_event(0x02, 0, 0, 0, 0); // shoot
            */

            //keybd_event(0x11, 0, 0, 0); // Crouch
            String text = "";
            this.Invoke((MethodInvoker)delegate ()
            {
                text = opticsBox.Text;
            });
            int num = 15;
            double multiplier = 1.0;
            if (text.Equals("4x Scope"))
                multiplier = 4.4;
            else if (text.Equals("Holo"))
                multiplier = .95;
            else if (text.Equals("Simple Handmade"))
                multiplier = .8;
            System.Threading.Thread.Sleep(100);
            mouse_event(0x02, 0, 0, 0, 0); // shoot

            for (int x = 0; x < num; x++)
            {
                System.Threading.Thread.Sleep(akPause[x]);
                mouse_event(0x0001, (int)(akX[x] * (multiplier + (double)(sensBox.Value * (decimal).1))), (int)(akY[x] * (multiplier + (double)(sensBox.Value * (decimal).1))), 0, 0); // recoil for bullet 2


            }

            /*
            mouse_event(0x02, 0, 0, 0, 0); // shoot
            System.Threading.Thread.Sleep(10);
            mouse_event(0x0001, -1, 18, 0, 0); // recoil for bullet 2
            System.Threading.Thread.Sleep(150);
            mouse_event(0x0001, -3, 19, 0, 0); // recoil for bullet 3
            System.Threading.Thread.Sleep(130);
            mouse_event(0x0001, -5, 19, 0, 0); // recoil for bullet 4
            System.Threading.Thread.Sleep(130);
            mouse_event(0x0001, -12, 15, 0, 0); // recoil for bullet 5
            System.Threading.Thread.Sleep(130);
            mouse_event(0x0001, -21, 14, 0, 0); // recoil for bullet 6
            System.Threading.Thread.Sleep(130);
            mouse_event(0x0001, -5, 14, 0, 0); // recoil for bullet 7
            System.Threading.Thread.Sleep(130);
            mouse_event(0x0001, 7, 9, 0, 0); // recoil for bullet 8
            System.Threading.Thread.Sleep(130);
            mouse_event(0x0001, 12, 8, 0, 0); // recoil for bullet 9
            System.Threading.Thread.Sleep(130);
            mouse_event(0x0001, 17, 7, 0, 0); // recoil for bullet 10
            System.Threading.Thread.Sleep(140);
            mouse_event(0x0001, 18, 3, 0, 0); // recoil for bullet 10
            System.Threading.Thread.Sleep(130);
            mouse_event(0x0001, 18, 4, 0, 0); // recoil for bullet 10
            System.Threading.Thread.Sleep(130);
            mouse_event(0x0001, 16, 7, 0, 0); // recoil for bullet 10
            System.Threading.Thread.Sleep(135);
            mouse_event(0x0001, 10, 11, 0, 0); // recoil for bullet 10
            System.Threading.Thread.Sleep(135);
            mouse_event(0x0001, 0, 14, 0, 0); // recoil for bullet 10
            System.Threading.Thread.Sleep(135);
            mouse_event(0x0001, -6, 13, 0, 0); // recoil for bullet 10
            */




            mouse_event(0x04, 0, 0, 0, 0); // mouse up


            System.Threading.Thread.Sleep(500);
            keybd_event(0x11, 0, 0x0002, 0); //key up
            started = false;




            //keybd_event(0x11, 0, 0, 0); // Crouch
            //mouse_event(0x08, 0, 0, 0, 0); // Aim

            /*
            System.Threading.Thread.Sleep(100);

            mouse_event(0x02, 0, 0, 0, 0); // mouse down
            System.Threading.Thread.Sleep(70);

            mouse_event(0x0001, -1, 19, 0, 0); // mouse move
            System.Threading.Thread.Sleep(100);
            System.Threading.Thread.Sleep(70);

            mouse_event(0x0001, -1, 19, 0, 0); // mouse move

            System.Threading.Thread.Sleep(70);
            System.Threading.Thread.Sleep(70);

            mouse_event(0x0001, -8, 16, 0, 0); // mouse move
            System.Threading.Thread.Sleep(70);
            System.Threading.Thread.Sleep(50);

            mouse_event(0x0001, -8, 16, 0, 0); // mouse move
            System.Threading.Thread.Sleep(90);
            System.Threading.Thread.Sleep(30);

            mouse_event(0x0001, -23, 12, 0, 0); // mouse move
            System.Threading.Thread.Sleep(110);

            mouse_event(0x0001, 0, 12, 0, 0); // mouse move
            System.Threading.Thread.Sleep(110);

            mouse_event(0x0001, 5, 12, 0, 0); // mouse move
            System.Threading.Thread.Sleep(110);

            mouse_event(0x0001, 9, 10, 0, 0); // mouse move
            System.Threading.Thread.Sleep(110);

            mouse_event(0x0001, 11, 10, 0, 0); // mouse move
            System.Threading.Thread.Sleep(110);

            mouse_event(0x0001, 9, -4, 0, 0); // mouse move
            System.Threading.Thread.Sleep(110);

            mouse_event(0x0001, 15, 5, 0, 0); // mouse move
            System.Threading.Thread.Sleep(110);

            mouse_event(0x0001, 15, 0, 0, 0); // mouse move
            System.Threading.Thread.Sleep(110);

            mouse_event(0x0001, 15, 5, 0, 0); // mouse move
            System.Threading.Thread.Sleep(110);

            mouse_event(0x0001, 15, 10, 0, 0); // mouse move
            System.Threading.Thread.Sleep(110);

            mouse_event(0x0001, 15, 5, 0, 0); // mouse move
            System.Threading.Thread.Sleep(50);

            mouse_event(0x0001, -18, 5, 0, 0); // mouse move
            System.Threading.Thread.Sleep(170);

            mouse_event(0x0001, -14, 8, 0, 0); // mouse move
            System.Threading.Thread.Sleep(50);
            System.Threading.Thread.Sleep(60);

            mouse_event(0x0001, 5, 10, 0, 0); // mouse move
            System.Threading.Thread.Sleep(80);

            mouse_event(0x0001, -20, 11, 0, 0); // mouse move
            System.Threading.Thread.Sleep(120);

            mouse_event(0x0001, -20, 10, 0, 0); // mouse move
            System.Threading.Thread.Sleep(150);

            mouse_event(0x0001, -20, 10, 0, 0); // mouse move
            System.Threading.Thread.Sleep(150);

            mouse_event(0x0001, -20, 10, 0, 0); // mouse move
            System.Threading.Thread.Sleep(150);

            mouse_event(0x0001, -20, 10, 0, 0); // mouse move
            System.Threading.Thread.Sleep(150);

            mouse_event(0x0001, -10, 10, 0, 0); // mouse move
            System.Threading.Thread.Sleep(150);

            mouse_event(0x0001, -10, 10, 0, 0); // mouse move
            System.Threading.Thread.Sleep(150);

            mouse_event(0x0001, 7, 5, 0, 0); // mouse move
            System.Threading.Thread.Sleep(150);

            mouse_event(0x0001, 7, 5, 0, 0); // mouse move
            System.Threading.Thread.Sleep(150);

            mouse_event(0x0001, 15, 15, 0, 0); // mouse move
            System.Threading.Thread.Sleep(150);

            mouse_event(0x0001, 15, 15, 0, 0); // mouse move
            System.Threading.Thread.Sleep(150);

            mouse_event(0x0001, 15, 15, 0, 0); // mouse move
            System.Threading.Thread.Sleep(150);

                //mouse_event(0x010, 0, 0, 0, 0); // leave ADS
                mouse_event(0x04, 0, 0, 0, 0); // mouse up
            started = false;

            /* Stuff which needs ctrl to be pressed is done here 
            System.Threading.Thread.Sleep(1000);
            */
            //keybd_event(0x11, 0, 0x0002, 0); //key up
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //keybd_event(0x11, 0, 0, 0); // Crouch
            //mouse_event(0x08, 0, 0, 0, 0); // Aim



            System.Threading.Thread.Sleep(100);

            mouse_event(0x02, 0, 0, 0, 0); // mouse down
            System.Threading.Thread.Sleep(70);

            mouse_event(0x0001, -1, 19, 0, 0); // mouse move
            System.Threading.Thread.Sleep(100);
            System.Threading.Thread.Sleep(70);

            mouse_event(0x0001, -1, 19, 0, 0); // mouse move

            System.Threading.Thread.Sleep(70);
            System.Threading.Thread.Sleep(70);

            mouse_event(0x0001, -8, 16, 0, 0); // mouse move
            System.Threading.Thread.Sleep(70);
            System.Threading.Thread.Sleep(50);

            mouse_event(0x0001, -8, 16, 0, 0); // mouse move
            System.Threading.Thread.Sleep(90);
            System.Threading.Thread.Sleep(30);

            mouse_event(0x0001, -23, 12, 0, 0); // mouse move
            System.Threading.Thread.Sleep(110);

            mouse_event(0x0001, 0, 12, 0, 0); // mouse move
            System.Threading.Thread.Sleep(110);

            mouse_event(0x0001, 5, 12, 0, 0); // mouse move
            System.Threading.Thread.Sleep(110);

            mouse_event(0x0001, 9, 10, 0, 0); // mouse move
            System.Threading.Thread.Sleep(110);

            mouse_event(0x0001, 11, 10, 0, 0); // mouse move
            System.Threading.Thread.Sleep(110);

            mouse_event(0x0001, 9, -4, 0, 0); // mouse move
            System.Threading.Thread.Sleep(110);

            mouse_event(0x0001, 15, 5, 0, 0); // mouse move
            System.Threading.Thread.Sleep(110);

            mouse_event(0x0001, 15, 0, 0, 0); // mouse move
            System.Threading.Thread.Sleep(110);

            mouse_event(0x0001, 15, 5, 0, 0); // mouse move
            System.Threading.Thread.Sleep(110);

            mouse_event(0x0001, 15, 10, 0, 0); // mouse move
            System.Threading.Thread.Sleep(110);

            mouse_event(0x0001, 15, 5, 0, 0); // mouse move
            System.Threading.Thread.Sleep(50);

            mouse_event(0x0001, -18, 5, 0, 0); // mouse move
            System.Threading.Thread.Sleep(170);

            mouse_event(0x0001, -14, 8, 0, 0); // mouse move
            System.Threading.Thread.Sleep(50);
            System.Threading.Thread.Sleep(60);

            mouse_event(0x0001, 5, 10, 0, 0); // mouse move
            System.Threading.Thread.Sleep(80);

            mouse_event(0x0001, -20, 11, 0, 0); // mouse move
            System.Threading.Thread.Sleep(120);

            mouse_event(0x0001, -20, 10, 0, 0); // mouse move
            System.Threading.Thread.Sleep(150);

            mouse_event(0x0001, -20, 10, 0, 0); // mouse move
            System.Threading.Thread.Sleep(150);

            mouse_event(0x0001, -20, 10, 0, 0); // mouse move
            System.Threading.Thread.Sleep(150);

            mouse_event(0x0001, -20, 10, 0, 0); // mouse move
            System.Threading.Thread.Sleep(150);

            mouse_event(0x0001, -10, 10, 0, 0); // mouse move
            System.Threading.Thread.Sleep(150);

            mouse_event(0x0001, -10, 10, 0, 0); // mouse move
            System.Threading.Thread.Sleep(150);

            mouse_event(0x0001, 7, 5, 0, 0); // mouse move
            System.Threading.Thread.Sleep(150);

            mouse_event(0x0001, 7, 5, 0, 0); // mouse move
            System.Threading.Thread.Sleep(150);

            mouse_event(0x0001, 15, 15, 0, 0); // mouse move
            System.Threading.Thread.Sleep(150);

            mouse_event(0x0001, 15, 15, 0, 0); // mouse move
            System.Threading.Thread.Sleep(150);

            mouse_event(0x0001, 15, 15, 0, 0); // mouse move
            System.Threading.Thread.Sleep(150);
        }
    }
}
