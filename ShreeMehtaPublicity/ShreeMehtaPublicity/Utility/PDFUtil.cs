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

        public void createCautationPDFFile(ObservableCollection<SiteCautationModel> Cautation, string FileName)
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
                        
                        for (int i = 0; i < Cautation.Count; i++)
                        {
                            Phrase Name = new Phrase(Cautation[i].SiteSeqNum + " : " + Cautation[i].SiteName);
                            Phrase Amount = new Phrase("Amount : " + Cautation[i].SiteAmount);
                            Phrase Height = new Phrase("Height : " + Cautation[i].SiteHeight);
                            Phrase Width = new Phrase("Width : " + Cautation[i].SiteWidth);
                            Phrase Address = new Phrase("Address : " + Cautation[i].SiteAddress);

                            PdfPTable Row1 = new PdfPTable(3);
                            PdfPTable Row2 = new PdfPTable(3);
                            PdfPTable Row3 = new PdfPTable(1);

                            PdfPCell R1C1 = new PdfPCell();
                            PdfPCell R1C2 = new PdfPCell(Name);
                            PdfPCell R1C3 = new PdfPCell();

                            PdfPCell R2C1 = new PdfPCell(Amount);
                            PdfPCell R2C2 = new PdfPCell(Height);
                            PdfPCell R2C3 = new PdfPCell(Width);

                            PdfPCell R3C1 = new PdfPCell(Address);

                            R1C1.HorizontalAlignment = Element.ALIGN_CENTER;
                            R1C2.HorizontalAlignment = Element.ALIGN_CENTER;
                            R1C3.HorizontalAlignment = Element.ALIGN_CENTER;

                            R2C1.HorizontalAlignment = Element.ALIGN_CENTER;
                            R2C2.HorizontalAlignment = Element.ALIGN_CENTER;
                            R2C3.HorizontalAlignment = Element.ALIGN_CENTER;

                            R3C1.HorizontalAlignment = Element.ALIGN_LEFT;

                            R1C1.Border = 0;
                            R1C2.Border = 0;
                            R1C3.Border = 0;
                            R2C1.Border = 0;
                            R2C2.Border = 0;
                            R2C3.Border = 0;
                            R3C1.Border = 0;

                            Row1.AddCell(R1C1);
                            Row1.AddCell(R1C2);
                            Row1.AddCell(R1C3);
                            Row2.AddCell(R2C1);
                            Row2.AddCell(R2C2);
                            Row2.AddCell(R2C3);
                            Row3.AddCell(R3C1);

                            pdfDoc.Add(Row1);
                            pdfDoc.Add(Row2);
                            pdfDoc.Add(Row3);

                            pdfDoc.Add(Chunk.NEWLINE);
                            pdfDoc.Add(Chunk.NEWLINE);
                            pdfDoc.Add(Chunk.NEWLINE);
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
