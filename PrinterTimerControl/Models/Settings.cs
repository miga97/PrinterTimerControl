using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PrinterTimerControl
{
    public class Settings
    {
        public string TokenPath { get; }
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
        public string Function { get; set; }
        public string FileType { get; set; }
        public bool MigMaster { get; set; }
        public DropboxConnection Connection { get; set; }
        public Settings()
        {
            TokenPath = @"Data\Token.txt";
            UseDropbox = false;
            Path = "";
            AutomaticStart = false;
            Function = "message";
            FileType = "*";
            MigMaster = false;
            Delay = 1;
        }
    }
}
