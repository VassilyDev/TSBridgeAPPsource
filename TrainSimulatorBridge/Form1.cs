using Sharer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace TrainSimulatorBridge
{
    public partial class Form1 : Form

    {
        // PROGRAM VARIABLES
        public static String prevName = "";
        // COMMON
        public static int thrID = 0;
        public static int thrMIN = 0;
        public static int thrMAX = 0;
        public static int brkID = 0;
        public static int revID = 0;
        public static int hornID = 0;
        public static int wipID = 0;
        public static int spdID = 0;
        public static int sndID = 0;
        public static int ampID = 0;
        public static int pantID = 0;
        public static int strtID = 0;
        public static int lightsID = 0;
        // VIGIL
        public static int vigilENID = 0;
        public static int vigilALID = 0;
        public static int vigilREID = 0;
        // AWS
        public static int AWSID = 0;
        public static int AWSResetID = 0;
        // PZB
        public static int PZB40ID = 0;
        public static int PZB55ID = 0;
        public static int PZB70ID = 0;
        public static int PZB85ID = 0;
        public static int PZB500ID = 0;
        public static int PZB1000ID = 0;
        public static int PZBWarnID = 0;
        public static int CMD40ID = 0;
        public static int CMDFreeID = 0;
        public static int CMDWID = 0;
        // OTHER
        public static int emergencyID = 0;
        public static int doorRID = 0;
        public static int doorLID = 0;

        SharerConnection conn;
        Boolean ardu_conn = false;
        Sharer.Command.SharerGetInfosCommand info;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // DLLs INIT
            RailDriverDLL.Load();
            init();
            // LISTBOX INIT (update the current available COM ports)
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            listBox1.ResetText();
            for (int i = 0; i < ports.Length; i++)
            {
                listBox1.Items.Add(ports[i]);
            }
        }

        // Timer for variables reading/sending to Arduino
        private void timer2_Tick(object sender, EventArgs e)
        {
            // SEND TO ARDUINO
            float tmp;
            var values = new List<Sharer.Command.SharerWriteValue>();
            var values2 = new List<Sharer.Command.SharerWriteValue>();
            // Speed KPH
            tmp = RailDriverDLL.GetControllerValue(spdID, 0);
            values.Add(new Sharer.Command.SharerWriteValue("kph", tmp.ToString()));
            // Current
            tmp = RailDriverDLL.GetControllerValue(ampID, 0);
            values.Add(new Sharer.Command.SharerWriteValue("ammeter", tmp.ToString()));
            // Vigil Alarm
            tmp = RailDriverDLL.GetControllerValue(vigilALID, 0);
            values.Add(new Sharer.Command.SharerWriteValue("vigilAlarm", tmp.ToString()));
            // AWS Alarm
            tmp = RailDriverDLL.GetControllerValue(AWSID, 0);
            values.Add(new Sharer.Command.SharerWriteValue("AWS", tmp.ToString()));
            // PZB
            tmp = RailDriverDLL.GetControllerValue(PZB40ID, 0);
            values2.Add(new Sharer.Command.SharerWriteValue("PZB40", tmp.ToString()));
            tmp = RailDriverDLL.GetControllerValue(PZB55ID, 0);
            values2.Add(new Sharer.Command.SharerWriteValue("PZB55", tmp.ToString()));
            tmp = RailDriverDLL.GetControllerValue(PZB70ID, 0);
            values2.Add(new Sharer.Command.SharerWriteValue("PZB70", tmp.ToString()));
            tmp = RailDriverDLL.GetControllerValue(PZB85ID, 0);
            values2.Add(new Sharer.Command.SharerWriteValue("PZB85", tmp.ToString()));
            tmp = RailDriverDLL.GetControllerValue(PZB500ID, 0);
            values2.Add(new Sharer.Command.SharerWriteValue("PZB500", tmp.ToString()));
            tmp = RailDriverDLL.GetControllerValue(PZB1000ID, 0);
            values2.Add(new Sharer.Command.SharerWriteValue("PZB1000", tmp.ToString()));
            tmp = RailDriverDLL.GetControllerValue(PZBWarnID, 0);
            values2.Add(new Sharer.Command.SharerWriteValue("PZBWarn", tmp.ToString()));

            try
            {
                conn.WriteVariables(values);
                conn.WriteVariables(values2);
            }
            catch { }

            // READ FROM ARDUINO
            String[] reqVarC = { "thCH", "brCH", "revCH", "hCH", "sCH", "pCH", "startCH", "lCH", "VIGILCH", "AWSRCH", "C40CH", "CFCH", "CMDWCH", "eCH" };
            var valuess = new List<Sharer.Command.SharerReadVariableReturn>();
            var valuessC = new List<Sharer.Command.SharerReadVariableReturn>();
            
            try
            {
                valuessC = conn.ReadVariables(reqVarC);
                conn.WriteVariable("beat", true);
            }  
            catch { }

            if (valuessC.Count.Equals(0)) return;

            // Data conversion and game injection
            Sharer.Command.SharerReadVariableReturn reply;
            float sp;
            if (valuessC[0].Value.ToString().Contains("1")){
                reply = conn.ReadVariable("throttle");
                //sp = float.Parse(valuess[0].Value.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                sp = float.Parse(reply.Value.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                RailDriverDLL.SetControllerValue(thrID, sp / 1000);
            }
            if (valuessC[1].Value.ToString().Contains("1")){
                reply = conn.ReadVariable("brake");
                sp = float.Parse(reply.Value.ToString(), CultureInfo.InvariantCulture.NumberFormat); 
                RailDriverDLL.SetControllerValue(brkID, sp / 1000);
            }
            if (valuessC[2].Value.ToString().Contains("1")){
                reply = conn.ReadVariable("reverser");
                sp = float.Parse(reply.Value.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                RailDriverDLL.SetControllerValue(revID, sp);
            }
            if (valuessC[3].Value.ToString().Contains("1")){
                reply = conn.ReadVariable("horn");
                sp = float.Parse(reply.Value.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                label1.Text = sp.ToString();
                RailDriverDLL.SetControllerValue(hornID, sp);
            }
            if (valuessC[4].Value.ToString().Contains("1"))
            {
                reply = conn.ReadVariable("sander");
                sp = float.Parse(reply.Value.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                RailDriverDLL.SetControllerValue(sndID, sp);
            }
            if (valuessC[5].Value.ToString().Contains("1"))
            {
                reply = conn.ReadVariable("pantograph");
                sp = float.Parse(reply.Value.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                RailDriverDLL.SetControllerValue(pantID, sp);
            }
            if (valuessC[6].Value.ToString().Contains("1"))
            {
                reply = conn.ReadVariable("startup");
                sp = float.Parse(reply.Value.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                RailDriverDLL.SetControllerValue(strtID, sp);
            }
            if (valuessC[7].Value.ToString().Contains("1"))
            {
                reply = conn.ReadVariable("lights");
                sp = float.Parse(reply.Value.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                RailDriverDLL.SetControllerValue(lightsID, sp);
            }
            if (valuessC[8].Value.ToString().Contains("1"))
            {
                reply = conn.ReadVariable("vigilReset");
                sp = float.Parse(reply.Value.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                RailDriverDLL.SetControllerValue(vigilREID, sp);
            }
            if (valuessC[9].Value.ToString().Contains("1"))
            {
                reply = conn.ReadVariable("AWSReset");
                sp = float.Parse(reply.Value.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                RailDriverDLL.SetControllerValue(AWSResetID, sp);
            }
            if (valuessC[10].Value.ToString().Contains("1"))
            {
                reply = conn.ReadVariable("CMD40");
                sp = float.Parse(reply.Value.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                RailDriverDLL.SetControllerValue(CMD40ID, sp);
            }
            if (valuessC[11].Value.ToString().Contains("1"))
            {
                reply = conn.ReadVariable("CMDFree");
                sp = float.Parse(reply.Value.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                RailDriverDLL.SetControllerValue(CMDFreeID, sp);
            }
            if (valuessC[13].Value.ToString().Contains("1"))
            {
                reply = conn.ReadVariable("emergency");
                sp = float.Parse(reply.Value.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                RailDriverDLL.SetControllerValue(emergencyID, sp);
            }
            /*sp = float.Parse(valuess[14].Value.ToString(), CultureInfo.InvariantCulture.NumberFormat);
            RailDriverDLL.SetControllerValue(doorRID, sp);
            sp = float.Parse(valuess[15].Value.ToString(), CultureInfo.InvariantCulture.NumberFormat);
            RailDriverDLL.SetControllerValue(doorLID, sp);*/
        }

        // Timer to check current operative locomotive and remap controls
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (prevName.Equals(Decoder.getLocoName())) return;
            prevName = Decoder.getLocoName();
            Decoder.nameControls();
            label2.Text = ("Loco: " + Decoder.getLocoName());
            Console.WriteLine("Loco: " + Decoder.getLocoName());
        }



        // Referesh button
        private void button3_Click(object sender, EventArgs e)
        {
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            listBox1.Items.Clear();
            for (int i = 0; i < ports.Length; i++)
            {
                listBox1.Items.Add(ports[i]);
            }

        }
        // Report button
        private void button4_Click(object sender, EventArgs e)
        {
            // Generate a loco.txt file containing all the data available in Raildriver.
            String temp = RailDriverDLL.GetControllerList();
            String id = Decoder.getLocoName();
            System.IO.File.WriteAllText("loco.txt", id + temp);
            System.Windows.Forms.MessageBox.Show("Please upload the loco.txt file to the GitHub project page or send it to webmaster@felicetti-a.eu.");
        }


        // GAME INIT AND SYNC
        private void init()
        {
            RailDriverDLL.SetRailDriverConnected(true);
            Decoder.nameControls();
            label2.Text = ("Loco: " + Decoder.getLocoName());

        }
        // Connect button
        private void button2_Click(object sender, EventArgs e)
        {

            if (ardu_conn == true)
            {
                if (conn.Connected == true)
                {
                    conn.Disconnect();
                    button2.Text = "CONNECT";
                    button2.BackColor = Color.FromArgb(255, 255, 255);
                    timer1.Stop();
                    timer2.Stop();
                    return;
                }
            }
            if (listBox1.SelectedIndices.Count.Equals(0)) return;
            if (listBox1.SelectedItem.ToString().Contains("COM"))
            {
                conn = new SharerConnection(listBox1.SelectedItem.ToString(), 115200, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One, System.IO.Ports.Handshake.None);
                var port = (System.IO.Ports.SerialPort)conn.GetType().GetField("_serialPort", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(conn);
                port.RtsEnable = true;
                port.DtrEnable = true;
                try
                {
                    conn.Connect();
                }
                catch { }


                if (conn.Connected.Equals(true))
                {
                    label2.Text = ("Loco: " + Decoder.getLocoName());
                    timer1.Start();
                    timer2.Start();
                    button2.Text = "DISCONNECT";
                    button2.BackColor = Color.FromArgb(0, 255, 51);
                    info = conn.GetInfos();
                    ardu_conn = true;
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://icons8.com/");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://felicetti-a.eu/");
        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Updates verification
            if (CheckForInternetConnection() == true)
            {
                // Download the dbversion file, containing a single number relative to the version of the database.
                // If the number is bigger than the current one, download the new database.
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                WebClient wc = new WebClient();
                wc.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.Revalidate);
                wc.Headers.Add("Cache-Control", "no-cache");
                string theTextFile = wc.DownloadString("https://raw.githubusercontent.com/VassilyDev/TSBridgeAPP/main/dbversion.txt");

                /*String theTextFile = ""; 
                var webRequest = WebRequest.Create(@"https://raw.githubusercontent.com/VassilyDev/TSBridgeAPP/main/dbversion.txt");
                using (var response = webRequest.GetResponse())
                using (var content = response.GetResponseStream())
                using (var reader = new StreamReader(content))
                {
                     theTextFile = reader.ReadToEnd();
                }*/
                Console.Write("Remote version: ");
                Console.WriteLine(theTextFile);
                if (File.Exists("dbversion.txt")){
                    Console.WriteLine("File exists");
                    string temp2 = File.ReadAllText("dbversion.txt");
                    if (temp2.Equals(theTextFile))
                    {
                        // Database up to date
                        Console.WriteLine("Version matches");
                        button1.Text = "UP TO DATE";
                    }
                    else
                    {
                        using (var client = new WebClient())
                        {
                            // Download the new database
                            client.DownloadFile("https://raw.githubusercontent.com/VassilyDev/TSBridgeAPP/main/dbversion.txt", "dbversion.txt");
                            client.DownloadFile("https://raw.githubusercontent.com/VassilyDev/TSBridgeAPP/main/LocoData.xml", "LocoData.xml");
                            Console.WriteLine("Update received");
                            button1.Text = "UPDATE RECEIVED, PLEASE RESTART";
                        }
                    }
                }
                else{
                    using (var client = new WebClient())
                    {
                        // Download the database and dbversion. Used in case of fresh install.
                        client.DownloadFile("https://raw.githubusercontent.com/VassilyDev/TSBridgeAPP/main/dbversion.txt", "dbversion.txt");
                        client.DownloadFile("https://raw.githubusercontent.com/VassilyDev/TSBridgeAPP/main/LocoData.xml", "LocoData.xml");
                        Console.WriteLine("Downloaded new files");
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}