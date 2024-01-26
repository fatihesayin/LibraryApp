using AutoMapper;
using LibraryApp.CrossCutting;
using LibraryApp.Dto;
using LibraryApp.Utils;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Newtonsoft.Json.Serialization;

namespace LibraryApp.Manager
{
    public class FileManager : BaseManager ,IFileManager
    {
        public FileManager(IGuidGenerator guidGenerator, IMapper mapper) : base(guidGenerator, mapper)
        {
        }
        public async Task<string> UploadImage(string base64img)
        {
            var filePath = Directory.GetCurrentDirectory();
            var path = Path.Combine(filePath, "files", _guidGenerator.Create().ToString());
            await File.WriteAllBytesAsync(path, Convert.FromBase64String(base64img));
            return path;
        }
        public async Task<string> GetImage(string path)
        {
            return Convert.ToBase64String(await File.ReadAllBytesAsync(path));
        }
    }
    public interface IFileManager
    {
        Task<string> UploadImage(string base64);
        Task<string> GetImage(string path);
    }
}