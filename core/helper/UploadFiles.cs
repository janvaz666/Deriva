using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace core.helper
{
    public class UploadFiles
    {
        private static string basePublicWebPath = "wwwroot/";
        private static string basePrivateFile = "uploads/";
        
        /// <summary>   
        /// Sube archivos
        /// </summary>      
        /// <returns>Devuelve el path del archivo</returns>
        public static async Task<string> UploadFile(IFormFile file, string _path, string prefijo = "", bool isPublic = true)
        {
            var path = basePublicWebPath + _path;
            if (!isPublic)
            {
                path = basePrivateFile + _path;
            }
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            var ext = Path.GetExtension(file.FileName);
            var fileName = prefijo+DateTime.Now.ToString("yyyyMMddhhmmssffff") + ext;
            var filePath = Path.GetFullPath(path + "/" + fileName);
            var webPath = _path + "/" + fileName;

            using (var stream = File.Create(filePath))
            {
                await file.CopyToAsync(stream);
                return webPath;
            }   
        }
        
        /// <summary>   
        /// Remueve directorio    
        /// </summary>      
        public static void RemoveDirectory(string _path, bool isPublic = true)
        {
            var path = basePublicWebPath + _path;
            if (!isPublic)
            {
                path = basePrivateFile + _path;
            }
            if (Directory.Exists(path))
            {
                DirectoryInfo di = new DirectoryInfo(path);
                foreach (FileInfo file in di.GetFiles()) file.Delete();
                foreach (DirectoryInfo dir in di.GetDirectories()) dir.Delete(true);
                Directory.Delete(path);
            }
        }
    }
}