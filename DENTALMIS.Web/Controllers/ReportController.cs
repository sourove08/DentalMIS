using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DENTALMIS.Model;
using DENTALMIS.Model.Custom;
using DENTALMIS.Web.Models.ReportViewModel;
using Microsoft.Reporting.WebForms;

namespace DENTALMIS.Web.Controllers
{
    public class ReportController : BaseController
    {
        //
        // GET: /Report/
        public ActionResult Bill(DynamicReportHeaderViewModel model)
        {
            ModelState.Clear();
            return View(model);
        }
        public ActionResult BillReport(string patientCode, DateTime fromDate, DateTime toDate)
      {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Report"), "Bill.rdlc");

            if (System.IO.File.Exists(path))
                lr.ReportPath = path;
            else
                return View("Index");

            Patient patient = PatientManager.GetAllPatienByCode(patientCode) ?? new Patient();

            SqlParameter pC = new SqlParameter("@PatientCode", patient.PatientCode);

            SqlParameter fromD = new SqlParameter("@FromDate", fromDate);
            SqlParameter toD = new SqlParameter("@ToDate", toDate);
          
            object[] objs = new object[] { pC, fromD, toD };

            List<PaymentView> bil = new List<PaymentView>();
            bil = ReportManager.GetPatientBill(objs);

            ReportDataSource rd = new ReportDataSource("DentalDataSet", bil);
            //ReportParameter[] parameters = new ReportParameter[8];

            //string[] heads = reportHeads.Split(',');

            //if (heads.Contains("Shift"))
            //    parameters[0] = new ReportParameter("Param_Shift", "True");
            //else
            //    parameters[0] = new ReportParameter("Param_Shift", "False");

            //if (heads.Contains("Status"))
            //    parameters[1] = new ReportParameter("Param_Status", "True");
            //else
            //    parameters[1] = new ReportParameter("Param_Status", "False");

            //if (heads.Contains("InTime"))
            //    parameters[2] = new ReportParameter("Param_InTime", "True");
            //else
            //    parameters[2] = new ReportParameter("Param_InTime", "False");

            //if (heads.Contains("OutTime"))
            //    parameters[3] = new ReportParameter("Param_OutTime", "True");
            //else
            //    parameters[3] = new ReportParameter("Param_OutTime", "False");

            //if (heads.Contains("Delay"))
            //    parameters[4] = new ReportParameter("Param_Delay", "True");
            //else
            //    parameters[4] = new ReportParameter("Param_Delay", "False");

            //if (heads.Contains("OTHours"))
            //    parameters[5] = new ReportParameter("Param_OTHours", "True");
            //else
            //    parameters[5] = new ReportParameter("Param_OTHours", "False");

            //if (heads.Contains("Remarks"))
            //    parameters[6] = new ReportParameter("Param_Remarks", "True");
            //else
            //    parameters[6] = new ReportParameter("Param_Remarks", "False");

            //if (heads.Contains("Salary"))
            //    parameters[7] = new ReportParameter("Param_Salary", "True");
            //else
            //    parameters[7] = new ReportParameter("Param_Salary", "False");

            //lr.SetParameters(parameters);
            lr.DataSources.Add(rd);
            string reportType = "pdf";
            string mimeType;
            string encoding;
            string fileNameExtension;

            string deviceInfo =
                "<DeviceInfo>" +
                "  <OutputFormat>" + 2 + "</OutputFormat>" +
                "  <PageWidth>8.5in</PageWidth>" +
                "  <PageHeight>11.7in</PageHeight>" +
                "  <MarginTop>0.4in</MarginTop>" +
                "  <MarginLeft>.4in</MarginLeft>" +
                "  <MarginRight>.2in</MarginRight>" +
                "  <MarginBottom>0.2in</MarginBottom>" +
                "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);

            return File(renderedBytes, mimeType);
        }

        //public ActionResult BillReport(DynamicReportHeaderViewModel model)
        //{
        //    model.PaymentMethods = ReportManager.GetPatientBill(model);
        //    var voucherModels = model.VoucherModels = _reportManager.GetVoucherStatements(model);
        //    var lr = new LocalReport();
        //    var path = Path.Combine(Server.MapPath("~/Report"), "VoucherStatement.rdlc");
        //    if (System.IO.File.Exists(path))
        //        lr.ReportPath = path;
        //    else
        //        return View("Index", "Home");
        //    var rd = new ReportDataSource("VoucherStatementDS", voucherModels);
        //    lr.DataSources.Add(rd);
        //    const string reportType = "pdf";
        //    string mimeType;
        //    string encoding;
        //    string fileNameExtension;
        //    var deviceInfo =
        //        "<DeviceInfo>" +
        //        "  <OutputFormat>" + 2 + "</OutputFormat>" +
        //        "  <PageWidth>8.3in</PageWidth>" +
        //        "  <PageHeight>5.84in</PageHeight>" +
        //        "  <MarginTop>0..2in</MarginTop>" +
        //        "  <MarginLeft>.4in</MarginLeft>" +
        //        "  <MarginRight>.2in</MarginRight>" +
        //        "  <MarginBottom>0.2in</MarginBottom>" +
        //        "</DeviceInfo>";
        //    Warning[] warnings;
        //    string[] streams;
        //    var renderedBytes = lr.Render(
        //        reportType,
        //        deviceInfo,
        //        out mimeType,
        //        out encoding,
        //        out fileNameExtension,
        //        out streams,
        //        out warnings);
        //    return File(renderedBytes, mimeType);

        //}
	}
}