using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Collections.ObjectModel;

using ShreeMehtaPublicity.MODEL;

namespace ShreeMehtaPublicity.Utility
{
    public class PDFUtil
    {
        public PDFUtil()
        {
            if (!Directory.Exists(FileOperations.CautationFilePath))
            {
                Directory.CreateDirectory(FileOperations.CautationFilePath);
            }
        }

        public void createCautationPDFFile(ObservableCollection<SiteCautationModel> ListofSelectedCautation, string FileName)
        {
            using (FileStream msReport = new FileStream(FileName, FileMode.Create))
            {
                using (Document pdfDoc = new Document(PageSize.A4, 25, 25, 30, 30))
                {
                    try
                    {
                        PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, msReport);
                        pdfWriter.PageEvent = new ITextEvents();
                        pdfDoc.SetMargins(0, 0, 100, 50);
                        pdfDoc.Open();
                        
                        for (int i = 0; i < 95; i++)
                        {
                            Phrase p1Header = new Phrase("Shree Mehta Publicity");

                            PdfPTable pdfTab = new PdfPTable(3);
                            
                            PdfPCell pdfCell1 = new PdfPCell();
                            PdfPCell pdfCell2 = new PdfPCell(p1Header);
                            PdfPCell pdfCell3 = new PdfPCell();

                            pdfCell1.HorizontalAlignment = Element.ALIGN_CENTER;
                            pdfCell2.HorizontalAlignment = Element.ALIGN_CENTER;
                            pdfCell3.HorizontalAlignment = Element.ALIGN_CENTER;

                            pdfCell2.VerticalAlignment = Element.ALIGN_BOTTOM;
                            pdfCell3.VerticalAlignment = Element.ALIGN_MIDDLE;

                            pdfCell1.Border = 0;
                            pdfCell2.Border = 0;
                            pdfCell3.Border = 0;

                            pdfTab.AddCell(pdfCell1);
                            pdfTab.AddCell(pdfCell2);
                            pdfTab.AddCell(pdfCell3);

                            pdfDoc.Add(pdfTab);
                        }
                        pdfDoc.Close();
                    
                    } catch (Exception e) {

                    } finally {

                    }
                }
            }
        }
    }
}
