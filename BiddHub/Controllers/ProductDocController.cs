using BiddHub.DTO;
using BiddHub.Migrations;
using BiddHub.Models;
using BiddHub.Models.Listings;
using BiddHub.Uploads;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Xml.Linq;

namespace BiddHub.Controllers
{
    public class ProductDocController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductDocController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("documentsfilesupload")] //api/main/uploadFile
        public IActionResult Upload(IFormFile file, string fileName)
        {
            // Validate file extension
            List<string> validExtensions = new List<string> { ".pdf", ".ppt" };
            string extension = Path.GetExtension(file.FileName);
            if (!validExtensions.Contains(extension))
            {
                return BadRequest($"Extension is not valid ({string.Join(", ", validExtensions)})");
            }

            // Validate file size
            long size = file.Length;
            if (size > (5 * 1024 * 1024))
            {
                return BadRequest("Maximum size can be 5MB");
            }

            string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads/documents");

            // Create directory if it doesn't exist
            if (!Directory.Exists(uploadDir))
            {
                Directory.CreateDirectory(uploadDir);
            }

            string filePath = Path.Combine(uploadDir, fileName);

            // Save the file
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            // Generate the URL for the uploaded file
            string fileUrl = $"{Request.Scheme}://{Request.Host}/Uploads/documents/{fileName}";

            // Save the file information to the database
            var productDoc = new Documents
            {
                Document_Type = fileName,
                Document_Url = fileUrl
            };
            _context.ProductDocuments.Add(productDoc);
            _context.SaveChanges();

            return Ok(new { fileName, fileUrl });
        }
    }
}
