namespace TestWebProjec3T.Helper
{
    public static class Upload
    {
        public static string UploadFile(string FolderName, IFormFile File)
        {
            try
            {
              
                string FolderPath = Directory.GetCurrentDirectory() + "/wwwroot/" + FolderName;

    
                if (!Directory.Exists(FolderPath))
                {
                    Directory.CreateDirectory(FolderPath);
                }

               
                string FileName = Guid.NewGuid() + Path.GetExtension(File.FileName);
              

                
                string FilePath = Path.Combine(FolderPath, FileName);

               
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
