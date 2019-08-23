using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace DENTALMIS.Web.ReportHelper
{
    public static class ReportConverter
    {
        public static FileStreamResult ConvertPdf(string bodyContent, string headerText)
        {
            string date = DateTime.Now.Date.ToString("dd-MM-yyyy");
            string exportData =
                String.Format("<html><head >{0}</head><body><h3>{1}<br/>{2}</h3><p>Date :{3}</p>{4}</body></html>",
                    "<style> table " +
                    "{" +
                    " background-color: #ffffff; " +
                    "font-size: 11px; " +
                    "font-family: Verdana; " +
                    "width: 100%; " +
                    "border-collapse: collapse; " +
                    "border: 1px solid #333;" +
                    " border-top: 0px;}" +
                    " table, th, td {border: 1px solid #222;}" +
                    "p{" +
                    "font-weight: bold;" +
                    "font-style: italic;" +
                    "font-size: 12px; }" +
                    "h3{  text-align: center;" +

                    "}" +
                    "</style>", "Plummy Fashions", headerText, date, bodyContent);
            var bytes = System.Text.Encoding.UTF8.GetBytes(exportData);
            using (var input = new MemoryStream(bytes))
            {
                var output = new MemoryStream();
                var document = new Document(PageSize.A4, 50, 50, 50, 50);
                var writer = PdfWriter.GetInstance(document, output);
                writer.CloseStream = false;
                document.Open();
                var xmlWorker = iTextSharp.tool.xml.XMLWorkerHelper.GetInstance();
                xmlWorker.ParseXHtml(writer, document, input, System.Text.Encoding.UTF8);
                document.Close();
                output.Position = 0;
                return new FileStreamResult(output, "application/pdf");
                // return File(output, "application/pdf", "myPDF.pdf");
            }
        }
        public static void CustomGridView(List<BoundField> boundFields, object datasources, string fileName)
        {
            var gv = new GridView();
            gv.AutoGenerateColumns = false;
            gv.DataSource = datasources;
            foreach (var boundField in boundFields)
            {
                gv.Columns.Add(boundField);
            }
            gv.DataBind();

            System.Web.HttpContext.Current.Response.ClearContent();
            System.Web.HttpContext.Current.Response.ClearContent();
            System.Web.HttpContext.Current.Response.Buffer = true;
            System.Web.HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + fileName + ".xls");
            System.Web.HttpContext.Current.Response.ContentType = "application/ms-excel";
            System.Web.HttpContext.Current.Response.Charset = "";
            var sw = new StringWriter();
            var htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            System.Web.HttpContext.Current.Response.Output.Write(sw.ToString());
            System.Web.HttpContext.Current.Response.Flush();
            System.Web.HttpContext.Current.Response.End();
        }
    }
}
