﻿using System.Drawing;
using System.IO;

namespace BiddHub.Uploads
{
    public class UploadHandler
    {
        public string Upload(IFormFile file)
        {
            //extention
            List<string> validExtentions = new List<string>() { ".jpg", ".png", ".gif", ".pdf" ,".ppt"};
            string extention = Path.GetExtension(file.FileName);
            if (!validExtentions.Contains(extention))
            {
                return $"Extention is not valid({string.Join(',', validExtentions)})";
            }
            //file size
            long size = file.Length;
            if (size > (5 * 1024 * 1024))
                return "Maximum size can be 5mb";
            //name changing
            string fileName = Guid.NewGuid().ToString() + extention;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            using FileStream stream = new FileStream(Path.Combine(path,fileName), FileMode.Create);
            file.CopyTo(stream);
            return fileName;
        }

    }
}
