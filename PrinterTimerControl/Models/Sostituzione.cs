using System;
using System.Collections.Generic;
using System.Text;

namespace PrinterTimerControl
{
    class Sostituzione
    {
        // file
        // Summary:
        // 
        //file: S_datacompilazione_orariocompilazione_datafinale.rtf
        //S_20150923_1146_20150924.rtf
        //
        public int AnnoCompilazione { get; }
        public int MeseCompilazione { get; }
        public int GiornoCompilazione { get; }
        public int OraCompilazione { get; }
        public int MinutiCompilazione { get; }
        public string NomeFile { get;}
        public DateTime Data { get;}
        public string Estensione { get;}
        public Sostituzione(string nomeFile)
        {
            AnnoCompilazione = Convert.ToInt32(nomeFile.Split('_')[1].Substring(0, 4));
            MeseCompilazione = Convert.ToInt32(nomeFile.Split('_')[1].Substring(4, 2));
            GiornoCompilazione = Convert.ToInt32(nomeFile.Split('_')[1].Substring(6, 2));
            OraCompilazione = Convert.ToInt32(nomeFile.Split('_')[2].Substring(0, 2));
            MinutiCompilazione = Convert.ToInt32(nomeFile.Split('_')[2].Substring(2, 2));
            NomeFile = nomeFile;
            Data = new DateTime(AnnoCompilazione, MeseCompilazione, GiornoCompilazione, OraCompilazione, MinutiCompilazione, 0);
            Estensione = nomeFile.Split('.')[1];
        }
        public bool DataMaggioreDi(string nomeFile2)
        {
            Sostituzione file2 = new Sostituzione(nomeFile2);
            if (Data > file2.Data)
                return true;
            else
                return false;            
        }
    }
}
