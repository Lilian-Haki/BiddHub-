using BiddHub.DTO;
using BiddHub.Models;
using BiddHub.Models.Listings;
using BiddHub.Uploads;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;

namespace BiddHub.Controllers
{
    public class ProductImageController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductImageController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("imagefilesupload")] //api/main/uploadFile
        public IActionResult Upload(IFormFile file)
        {
            // Validate file extension
            List<string> validExtensions = new List<string> { ".jpg", ".png" };
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

            // Generate a new filename
            string fileName = Guid.NewGuid().ToString() + extension;
            string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads/images");

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
            string fileUrl = $"{Request.Scheme}://{Request.Host}/Uploads/images/{fileName}";

            // Save the file information to the database
            var productImage = new Photos
            {
                //FileName = fileName,
                Photos_Url = fileUrl
            };
            _context.ProductImages.Add(productImage);
            _context.SaveChanges();

            return Ok(new { fileName, fileUrl });
        }
    }
}
