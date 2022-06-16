using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace _16._06Praktika.Uti
{
    public static class FileEx
    {
        public static string SaveFile(this IFormFile file,string path)
        {
            string fileName = Guid.NewGuid().ToString() + file.FileName;
            string fullPath = Path.Combine(path + fileName);
            using (FileStream stream = new FileStream(fullPath,FileMode.Create))
            {
               file.CopyTo(stream);
            }
            return fileName;
        }
        public static bool CheckSize(this IFormFile file , int kb)
        {
            if (file.Length / 1024 > kb) return false;
            return true;
        }
    }
}
