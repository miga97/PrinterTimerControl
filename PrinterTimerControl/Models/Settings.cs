using System;
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
        public string Function { get; set; }
        public string FileType { get; set; }
        public bool MigMaster { get; set; }
        public DropboxConnection Connection { get; set; }
        public Settings()
        {            
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
