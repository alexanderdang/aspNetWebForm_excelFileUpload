using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.OleDb;
using System.Configuration;
using System.IO;
using System.Data;

namespace uCarenet_test
{
    public partial class excelFile_upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //Retrieve path from Web.config file to upload excel file
            string filePath = ConfigurationManager.AppSettings["filePath"].ToString();

            if (excelFileUpload.HasFile)
            {
                try
                {
                    string[] allowedFileTypes = { ".xls", ".xlsx" };
                    excelFileUpload.SaveAs(filePath + excelFileUpload.FileName);
                    string fileExtension = System.IO.Path.GetExtension(excelFileUpload.PostedFile.FileName);

                    //bool isFileValid = allowedFileTypes.Contains(fileExtension);

                    OleDbConnection excelFileConnection = null;
                    if (fileExtension == ".xls")
                    {
                        excelFileConnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + "; Extended Properties=Excel 8.0;");
                    }
                    else if (fileExtension == ".xlsx")
                    {
                        excelFileConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + "; Extended Properties=Excel 12.0;");
                    }
                    excelFileConnection.Open();

                    DataTable dt = excelFileConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    //string getExcelSheetName = dt.Rows[0]["Table Name"].ToString;

                    excelFileGridView.DataBind();
                    

                } catch (Exception error)
                {
                    lblMessage.Text = error.Message;
                }

            }
        }
    }
}