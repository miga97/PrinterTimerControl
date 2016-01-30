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
        int _annoCompilazine;
        int _meseCompilazione;
        int _giornoCompilazione;
        int _oraCompilazione;
        int _minutiCompilazione;
        string _nomeFile;
        public Sostituzione(string nomeFile)
        {
            _annoCompilazine = Convert.ToInt32(nomeFile.Split('_')[1].Substring(0, 4));
            _meseCompilazione = Convert.ToInt32(nomeFile.Split('_')[1].Substring(4, 2));
            _giornoCompilazione = Convert.ToInt32(nomeFile.Split('_')[1].Substring(6, 2));
            _oraCompilazione = Convert.ToInt32(nomeFile.Split('_')[2].Substring(0, 2));
            _minutiCompilazione = Convert.ToInt32(nomeFile.Split('_')[2].Substring(2, 2));
            _nomeFile = nomeFile;
        }
        public bool DataMaggioreData2(string nomeFile2)
        {
            int annoCompilazine = Convert.ToInt32(nomeFile2.Split('_')[1].Substring(0, 4));
            int meseCompilazione = Convert.ToInt32(nomeFile2.Split('_')[1].Substring(4, 2));
            int giornoCompilazione = Convert.ToInt32(nomeFile2.Split('_')[1].Substring(6, 2));
            int oraCompilazione = Convert.ToInt32(nomeFile2.Split('_')[2].Substring(0, 2));
            int minutiCompilazione = Convert.ToInt32(nomeFile2.Split('_')[2].Substring(2, 2));
            if (_annoCompilazine > annoCompilazine)
                return true;
            else
            {
                if (_meseCompilazione > meseCompilazione)
                    return true;
                else
                {
                    if (_giornoCompilazione > giornoCompilazione)
                        return true;
                    else
                    {
                        if (_oraCompilazione > oraCompilazione)
                            return true;
                        else
                        {
                            if (_minutiCompilazione > minutiCompilazione)
                                return true;
                            else
                                return false;
                        }
                    }
                }
            }
        }
        public string NomeFile
        {
            get { return _nomeFile; }
        }
        public string Estensione()
        {
            return _nomeFile.Split('.')[1];
        }
    }
}
