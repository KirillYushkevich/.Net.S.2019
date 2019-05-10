using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gallery.DAL;
using Gallery.Models;

namespace Gallery.Controllers
{
    public class HomeController : Controller
    {
        private GalleryContext db = new GalleryContext();

        private ImageConverter imageConverter = new ImageConverter();

        public ActionResult Index(string filter = null, int page = 1, int pageSize = 20)
        {
            var records = new PagedList<Photo>();
            ViewBag.filter = filter;
            records.Content = this.db.Photos
                        .Where(x => filter == null || x.Description.Contains(filter))
                        .OrderByDescending(x => x.PhotoId)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

            records.TotalRecords = this.db.Photos
                            .Where(x => filter == null || x.Description.Contains(filter)).Count();

            records.CurrentPage = page;
            records.PageSize = pageSize;
            return this.View(records);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return this.View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return this.View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var photo = new Photo();
            return this.View(photo);
        }

        public Size NewImageSize(Size imageSize, Size newSize)
        {
            Size finalSize;
            double tempval;
            if (imageSize.Height > newSize.Height || imageSize.Width > newSize.Width)
            {
                if (imageSize.Height > imageSize.Width)
                {
                    tempval = newSize.Height / (imageSize.Height * 1.0);
                }
                else
                {
                    tempval = newSize.Width / (imageSize.Width * 1.0);
                }                   

                finalSize = new Size((int)(tempval * imageSize.Width), (int)(tempval * imageSize.Height));
            }
            else
            {
                finalSize = imageSize;
            }

            return finalSize;
        }

        [HttpPost]
        public ActionResult Create(Photo photo, IEnumerable<HttpPostedFileBase> files)
        {
            if (!ModelState.IsValid)
            {
                return this.View(photo);
            }

            if (files.Count() == 0 || files.FirstOrDefault() == null)
            {
                ViewBag.error = "Please choose a file";
                return this.View(photo);
            }

            var model = new Photo();
            foreach (var file in files)
            {
                if (file.ContentLength == 0)
                {
                    continue;
                }

                model.Description = photo.Description;
                var fileName = Guid.NewGuid().ToString();
                var extension = System.IO.Path.GetExtension(file.FileName).ToLower();
                using (var img = System.Drawing.Image.FromStream(file.InputStream))
                {
                    model.Thumb = this.ImageToBase64(img, new Size(400, 400));
                    model.Image = this.ImageToBase64(img, new Size(100, 100));
                }

                model.CreatedOn = DateTime.Now;
                this.db.Photos.Add(model);
                this.db.SaveChanges();
            }

            return this.RedirectPermanent("/home");
        }

        private string ImageToBase64(Image img, Size newSize)
        {
            Image temp = new Bitmap(img, newSize);
            using (MemoryStream m = new MemoryStream())
            {
                temp.Save(m, img.RawFormat);
                byte[] imageBytes = m.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }
    }
}