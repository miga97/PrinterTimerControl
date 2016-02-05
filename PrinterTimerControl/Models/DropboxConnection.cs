using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dropbox.Api;
using Dropbox.Api.Files;
using Dropbox.Api.Sharing;
using System.IO;

namespace PrinterTimerControl
{
    public class DropboxConnection
    {
        public DropboxClient Connection { get; set; }
        public string NomeAccount { get; set; }
        public string EmailAccount { get; set; }
        public string[] FolderList { get; set; }
        public string[] FileList { get; set; }
        public DropboxConnection() { }
        public async Task Connetti(string token)
        {
            Connection = new DropboxClient(token);
            await Credenziali();
            await RefreshFolderList();
            await RefreshFileList();
        }
        private async Task Credenziali()
        {
            var data = await Connection.Users.GetCurrentAccountAsync();
            NomeAccount = data.Name.DisplayName;
            EmailAccount = data.Email;
        }
        public async Task RefreshFolderList()
        {
            List<string> lista = new List<string>();
            var list = await Connection.Files.ListFolderAsync(string.Empty);
            foreach (var item in list.Entries.Where(i => i.IsFolder))
            {
                Console.WriteLine("Folder: " + item.Name);
                lista.Add(item.Name);
            }
            FolderList = lista.ToArray();
        }
        public async Task RefreshFileList()
        {
            List<string> lista = new List<string>();
            var list = await Connection.Files.ListFolderAsync(string.Empty);
            foreach (var item in list.Entries.Where(i => i.IsFile))
            {
                Console.WriteLine("File: " + item.Name);
                lista.Add(item.Name);
            }
            FileList = lista.ToArray();
        }
        public async Task Download(string folder, string file, string destinationPath)
        {
            byte[] data;
            using (var response = await Connection.Files.DownloadAsync(folder + "/" + file))
            {
                data = await response.GetContentAsByteArrayAsync();
            }
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }
            File.WriteAllBytes(destinationPath + @"\" + file, data);
        }
        public async Task Download(string file, string destinationPath)
        {
            byte[] data;
            //StreamWriter save = new StreamWriter(@"Test\" + file);            
            using (var response = await Connection.Files.DownloadAsync("/" +file))
            {
                data = await response.GetContentAsByteArrayAsync();
                //Stream io = await response.GetContentAsStreamAsync();                
                //await save.WriteLineAsync(await response.GetContentAsStringAsync());                
            }
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }
            File.WriteAllBytes(destinationPath +@"\" + file, data);
            //save.Close();
        }

    }
}
