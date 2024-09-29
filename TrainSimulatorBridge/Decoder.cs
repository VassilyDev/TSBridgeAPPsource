using System;
using System.Xml;

namespace TrainSimulatorBridge
{
    class Decoder
    {
        private const String filename = "LocoData.xml";
        public static void nameControls()
        {
            // Get the correct data from the locomotive
            String tmp = RailDriverDLL.GetControllerList();
            String[] splitter = tmp.Split(new string[] { "::" }, StringSplitOptions.RemoveEmptyEntries);

            var xmlFile = "LocoData.xml";
            var doc = new XmlDocument();
            try
            {
                doc.Load(xmlFile); doc.Load(xmlFile);
            }
            catch { }

            String id = Decoder.getLocoName();
            XmlNode node = doc.SelectSingleNode($"/locos/loco[@id='{id}']");

            for (int i = 0; i < splitter.Length; i++)
            {
                if (node != null)
                {
                    if (splitter[i].Equals(node.ChildNodes[0]?.InnerText))
                    {
                        Form1.thrID = i;

                    }
                    if (splitter[i].Equals(node.ChildNodes[1]?.InnerText))
                    {
                        Form1.brkID = i;

                    }
                    if (splitter[i].Equals(node.ChildNodes[2]?.InnerText))
                    {
                        Form1.revID = i;

                    }
                }
                if( node == null)
                {
                    for (int ii = 0; ii < Dictionary.thrNames.Length; ii++)
                    {
                        if (splitter[i].Equals(Dictionary.thrNames[ii].ToString()))
                        {
                            Form1.thrID = i;
                        }

                    }
                    for (int ii = 0; ii < Dictionary.brkNames.Length; ii++)
                    {
                        if (splitter[i].Equals(Dictionary.brkNames[ii].ToString()))
                        {
                            Form1.brkID = i;
                        }

                    }
                    for (int ii = 0; ii < Dictionary.revNames.Length; ii++)
                    {
                        if (splitter[i].Equals(Dictionary.revNames[ii].ToString()))
                        {
                            Form1.revID = i;
                        }

                    }
                }
                for (int ii = 0; ii < Dictionary.hornNames.Length; ii++)
                {
                    if (splitter[i].Equals(Dictionary.hornNames[ii].ToString()))
                    {
                        Form1.hornID = i;
                    }

                }
                for (int ii = 0; ii < Dictionary.wipNames.Length; ii++)
                {
                    if (splitter[i].Equals(Dictionary.wipNames[ii].ToString()))
                    {
                        Form1.wipID = i;
                    }

                }
                for (int ii = 0; ii < Dictionary.speedNames.Length; ii++)
                {
                    if (splitter[i].Equals(Dictionary.speedNames[ii].ToString()))
                    {
                        Form1.spdID = i;
                    }

                }
                for (int ii = 0; ii < Dictionary.sandNames.Length; ii++)
                {
                    if (splitter[i].Equals(Dictionary.sandNames[ii].ToString()))
                    {
                        Form1.sndID = i;
                    }

                }
                for (int ii = 0; ii < Dictionary.ampNames.Length; ii++)
                {
                    if (splitter[i].Equals(Dictionary.ampNames[ii].ToString()))
                    {
                        Form1.ampID = i;
                    }

                }
                for (int ii = 0; ii < Dictionary.pantNames.Length; ii++)
                {
                    if (splitter[i].Equals(Dictionary.pantNames[ii].ToString()))
                    {
                        Form1.pantID = i;
                    }

                }
                for (int ii = 0; ii < Dictionary.strtNames.Length; ii++)
                {
                    if (splitter[i].Equals(Dictionary.strtNames[ii].ToString()))
                    {
                        Form1.strtID = i;
                    }

                }
                for (int ii = 0; ii < Dictionary.lightsNames.Length; ii++)
                {
                    if (splitter[i].Equals(Dictionary.lightsNames[ii].ToString()))
                    {
                        Form1.lightsID = i;
                    }

                }
                // VIGIL
                for (int ii = 0; ii < Dictionary.vigilENNames.Length; ii++)
                {
                    if (splitter[i].Equals(Dictionary.vigilENNames[ii].ToString()))
                    {
                        Form1.vigilENID = i;
                    }

                }
                for (int ii = 0; ii < Dictionary.vigilALNames.Length; ii++)
                {
                    if (splitter[i].Equals(Dictionary.vigilALNames[ii].ToString()))
                    {
                        Form1.vigilALID = i;
                    }

                }
                for (int ii = 0; ii < Dictionary.vigilRENames.Length; ii++)
                {
                    if (splitter[i].Equals(Dictionary.vigilRENames[ii].ToString()))
                    {
                        Form1.vigilREID = i;
                    }

                }
                // AWS
                for (int ii = 0; ii < Dictionary.AWSNames.Length; ii++)
                {
                    if (splitter[i].Equals(Dictionary.AWSNames[ii].ToString()))
                    {
                        Form1.AWSID = i;
                    }

                }
                for (int ii = 0; ii < Dictionary.AWSResetNames.Length; ii++)
                {
                    if (splitter[i].Equals(Dictionary.AWSResetNames[ii].ToString()))
                    {
                        Form1.AWSResetID = i;
                    }

                }
                // PZB
                for (int ii = 0; ii < Dictionary.PZB40Names.Length; ii++)
                {
                    if (splitter[i].Equals(Dictionary.PZB40Names[ii].ToString()))
                    {
                        Form1.PZB40ID = i;
                    }

                }
                for (int ii = 0; ii < Dictionary.PZB55Names.Length; ii++)
                {
                    if (splitter[i].Equals(Dictionary.PZB55Names[ii].ToString()))
                    {
                        Form1.PZB55ID = i;
                    }

                }
                for (int ii = 0; ii < Dictionary.PZB70Names.Length; ii++)
                {
                    if (splitter[i].Equals(Dictionary.PZB70Names[ii].ToString()))
                    {
                        Form1.PZB70ID = i;
                    }

                }
                for (int ii = 0; ii < Dictionary.PZB85Names.Length; ii++)
                {
                    if (splitter[i].Equals(Dictionary.PZB85Names[ii].ToString()))
                    {
                        Form1.PZB85ID = i;
                    }

                }
                for (int ii = 0; ii < Dictionary.PZB500Names.Length; ii++)
                {
                    if (splitter[i].Equals(Dictionary.PZB500Names[ii].ToString()))
                    {
                        Form1.PZB500ID = i;
                    }

                }
                for (int ii = 0; ii < Dictionary.PZB1000Names.Length; ii++)
                {
                    if (splitter[i].Equals(Dictionary.PZB1000Names[ii].ToString()))
                    {
                        Form1.PZB1000ID = i;
                    }

                }
                for (int ii = 0; ii < Dictionary.PZBWarnNames.Length; ii++)
                {
                    if (splitter[i].Equals(Dictionary.PZBWarnNames[ii].ToString()))
                    {
                        Form1.PZBWarnID = i;
                    }

                }
                for (int ii = 0; ii < Dictionary.CMD40Names.Length; ii++)
                {
                    if (splitter[i].Equals(Dictionary.CMD40Names[ii].ToString()))
                    {
                        Form1.CMD40ID = i;
                    }

                }
                for (int ii = 0; ii < Dictionary.CMDFreeNames.Length; ii++)
                {
                    if (splitter[i].Equals(Dictionary.CMDFreeNames[ii].ToString()))
                    {
                        Form1.CMDFreeID = i;
                    }

                }
                for (int ii = 0; ii < Dictionary.CMDWNames.Length; ii++)
                {
                    if (splitter[i].Equals(Dictionary.CMDWNames[ii].ToString()))
                    {
                        Form1.CMDWID = i;
                    }

                }
                for (int ii = 0; ii < Dictionary.emergencyNames.Length; ii++)
                {
                    if (splitter[i].Equals(Dictionary.emergencyNames[ii].ToString()))
                    {
                        Form1.emergencyID = i;
                    }

                }
                for (int ii = 0; ii < Dictionary.doorRNames.Length; ii++)
                {
                    if (splitter[i].Equals(Dictionary.doorRNames[ii].ToString()))
                    {
                        Form1.doorRID = i;
                    }

                }
                for (int ii = 0; ii < Dictionary.doorLNames.Length; ii++)
                {
                    if (splitter[i].Equals(Dictionary.doorLNames[ii].ToString()))
                    {
                        Form1.doorLID = i;
                    }

                }
            }
        }
        public static String getLocoName()
        {
            string currentLoco = RailDriverDLL.GetLocoName();
            string[] splitter = currentLoco.Split(new string[] { ".:." }, StringSplitOptions.RemoveEmptyEntries);
            if (splitter.Length > 1)
            {
                return splitter[2];
            }
            else
            {
                return "";
            }

        }
    }


}
