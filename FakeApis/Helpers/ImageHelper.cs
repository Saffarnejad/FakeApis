namespace FakeApis.Helpers
{
    public static class ImageHelper
    {
        private static readonly string _defaultImageFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");

        static ImageHelper()
        {
            if (!Directory.Exists(_defaultImageFolderPath))
            {
                Directory.CreateDirectory(_defaultImageFolderPath);
            }
        }

        public static async Task<string> UploadImageAsync(Stream imageStream, string fileName, string folderPath = null)
        {
            folderPath ??= _defaultImageFolderPath;

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var filePath = Path.Combine(folderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageStream.CopyToAsync(stream);
            }

            return filePath;
        }

        public static void DeleteImage(string fileName, string folderPath = null)
        {
            folderPath ??= _defaultImageFolderPath;

            var filePath = Path.Combine(folderPath, fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
