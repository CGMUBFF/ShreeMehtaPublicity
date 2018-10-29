using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;

namespace ShreeMehtaPublicity.Utility
{
    public class FileOperations
    {
        private static string DocumentDirectory = "C:\\ShreeMehtaPublicity\\";
        private static string SiteImagePath = DocumentDirectory + "Site Images\\";

        public static string SelectFile()
        {
            OpenFileDialog open = new OpenFileDialog();

            try
            {
                open.Filter = "Image Files(*.jpg;*.jpeg;*.bmp;*.png;)|*.jpg;*.jpeg;*.bmp;*.png;";
                if (open.ShowDialog() == true)
                {
                    return open.FileName;
                }
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }

        public static string CopySiteImage(string Source,int siteSeqNo)
        {
            DateTime d = DateTime.Now;
            string ImagePath = String.Concat(SiteImagePath, "Site No - ",siteSeqNo, "\\");
            string ImageFile = String.Concat(ImagePath, "SMP_SN_", siteSeqNo, "_", d.ToString("yyyyMMdd"),"_",d.ToString("HHmmssFFF"), Path.GetExtension(Source));
            //if (!Source.Contains(SiteImagePath))
            //{
                try
                {
                    if (!Directory.Exists(ImagePath))
                    {
                        Directory.CreateDirectory(ImagePath);
                    }

                    File.Copy(Source, ImageFile, true);
                    return ImageFile;
                }
                catch (Exception)
                {
                    return null;
                }
            /*}
            else
            {
                return Source;
            }*/
        }
    }
}
