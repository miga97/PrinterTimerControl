using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace PrinterTimerControl
{
    public class Settings
    {
        public string Path { get; set; }
        public bool UseDropbox { get; set; }
        private int delay;
        public int Delay
        {
            get { return delay; }
            set
            {
                if (value > 360 || value < 1)
                {
                    delay = 1;
                    throw new Exception("Errore: il delay è errato o inesistente");                    
                }
                else
                    delay = value;
            }
        }
        public bool AutomaticStart { get; set; }
        public bool AutomaticPrint { get; set; }
        public string FileType { get; set; }
        public bool MigMaster { get; set; }
        public DropboxConnection Connection { get; set; }
        public Settings()
        {            
            UseDropbox = false;
            Path = "";
            AutomaticStart = false;
            AutomaticPrint = false;
            FileType = "*";
            MigMaster = false;
            Delay = 1;
        }
        public bool CaricaXML(string filePath)
        {
            bool impostazioniCorrette = false;
            XmlDocument fileXML = new XmlDocument();
            fileXML.Load(filePath);
            XmlNode set = fileXML.DocumentElement;
            
            foreach (XmlNode item in set.ChildNodes)
            {
                switch (item.Name)
                {
                    case "Path": Path = item.InnerText; break;
                    case "UseDropbox": UseDropbox = Convert.ToBoolean(item.InnerText); break;
                    case "Delay": Delay = Convert.ToInt32(item.InnerText); break;
                    case "AutomaticStart": AutomaticStart = Convert.ToBoolean(item.InnerText); break;
                    case "AutomaticPrint": AutomaticPrint = Convert.ToBoolean(item.InnerText); break;
                    case "FileType": FileType = item.InnerText.ToLower(); break;
                    case "MigMaster": MigMaster = Convert.ToBoolean(item.InnerText); break;
                    default: impostazioniCorrette = false; break;
                }
            }
            return impostazioniCorrette;
        }
        public void SalvaXML(string filePath)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = false;
            settings.NewLineOnAttributes = true;
            XmlWriter writer = XmlWriter.Create(filePath, settings);
            writer.WriteStartElement("Settings");
            writer.WriteElementString("Path", Path);
            writer.WriteElementString("Delay", Delay.ToString());
            writer.WriteElementString("AutomaticStart", AutomaticStart.ToString());
            writer.WriteElementString("UseDropbox", UseDropbox.ToString());
            writer.WriteElementString("AutomaticPrint", AutomaticPrint.ToString());
            writer.WriteElementString("FileType", FileType);
            if (MigMaster)
                writer.WriteElementString("MigMaster", "True");
            writer.WriteEndElement();
            writer.Flush();
        }       
    }
}