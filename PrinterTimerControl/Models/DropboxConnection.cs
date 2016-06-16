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
    public class DropboxConnection //1.0 build 25022016
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
        public async void Upload(string folder, string file, string content)
        {
            var mem = new MemoryStream(Encoding.UTF8.GetBytes(content));
            var updated = await Connection.Files.UploadAsync(folder + "/" + file, WriteMode.Overwrite.Instance, body: mem);
        }
        public async void Delete(string folder, string file)
        {
            await Connection.Files.DeleteAsync(folder + "/" + file);
        }
    }
}
