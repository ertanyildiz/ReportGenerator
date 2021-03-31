using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator.Helper
{
    public static class EmailHelper
    {

        public static void MergePDFs(string targetPath, List<string> pdfs)
        {
            using (PdfDocument targetDoc = new PdfDocument())
            {
                foreach (string pdf in pdfs)
                {
                    using (PdfDocument pdfDoc = PdfReader.Open(pdf, PdfDocumentOpenMode.Import))
                    {
                        for (int i = 0; i < pdfDoc.PageCount; i++)
                        {
                            targetDoc.AddPage(pdfDoc.Pages[i]);
                        }
                    }
                }
                targetDoc.Save(targetPath);
            }
        }

        internal static void SendEmail(DataTable emailConfig, string finalPdfFileName, string emailAddresses, string emailAddressesBcc, List<string> reportNames)
        {
            var emailConfigRow = emailConfig.Rows[0];
            MailMessage mailMessage = new MailMessage(emailConfigRow["MailAddress"].ToString(), emailAddresses);
            if (! string.IsNullOrEmpty(emailAddressesBcc))
            {
                var emailAddressesBccList = emailAddressesBcc.Split(';').ToList();
                foreach (var bcc in emailAddressesBccList)
                {
                    mailMessage.Bcc.Add(bcc.Trim());
                }
            }
            mailMessage.Subject = $"Günlük rapor - {DateTime.Now:HH: mm})";
            mailMessage.Attachments.Add(new Attachment(finalPdfFileName));
            mailMessage.Body = reportNames.Count > 1 ? "Aşağıdaki raporlar için PDFler oluşturulmuştur. Ektedir"
                : $"{reportNames.FirstOrDefault()} için rapor PDF oluşturulmuştur. Ektedir.";



            var smtpClient = new SmtpClient(emailConfigRow["ServerName"].ToString(), Convert.ToInt32(emailConfigRow["Port"]))
            {
                Credentials = new NetworkCredential(emailConfigRow["MailAddress"].ToString(), LoginHelper.Decrypt(emailConfigRow["Password"].ToString())),
                EnableSsl = Convert.ToBoolean(emailConfigRow["Ssl"])
            };
            smtpClient.Send(mailMessage);
        }

        internal static bool SendEmail(string serverName, string senderEmail, string toMailAddress,  string password, int port, bool ssl)
        {

            try
            {
                MailMessage mailMessage = new MailMessage(senderEmail, toMailAddress);

                mailMessage.Subject = $"Email konfigurasyon test";
                mailMessage.Body = "Test email";



                var smtpClient = new SmtpClient(serverName, port)
                {
                    Credentials = new NetworkCredential(senderEmail, LoginHelper.Decrypt(password)),
                    EnableSsl = Convert.ToBoolean(ssl)
                };
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                ReportService.Log($"{ex.Message} {ex.InnerException}", "HATA");
                return false;
            }
        }
    }
}
