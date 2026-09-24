namespace TestWebProjec3T.Helper
{
    public static class Upload
    {
        public static string UploadFile(string FolderName, IFormFile File)
        {
            try
            {
                // 1) Get Directory
                string FolderPath = Directory.GetCurrentDirectory() + "/wwwroot/" + FolderName;

                // لو الفولدر مش موجود، اعمله
                if (!Directory.Exists(FolderPath))
                {
                    Directory.CreateDirectory(FolderPath);
                }

                // 2) Get File Name
                string FileName = Guid.NewGuid() + Path.GetExtension(File.FileName);
                // Guid => Word Contain 36 Character 

                // 3) Merge Path With File Name
                string FilePath = Path.Combine(FolderPath, FileName);

                // 4) Save File As Stream
                using (FileStream Stream = new FileStream(FilePath, FileMode.Create))
                {
                    File.CopyTo(Stream);
                }

                return FileName;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string RemoveFile(string FolderName, string FileName)
        {
            try
            {
                string directory = Path.
                Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", FolderName, FileName);

                if (File.Exists(directory))
                {
                    File.Delete(directory);
                    return "File Deleted";
                }
                return "File Not Deleted";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            
        }

    }
}
