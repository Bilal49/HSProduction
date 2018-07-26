using FIL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


public class Utility
{

    public void setOnlyNumberic(TextBox Control, bool IsDecimal, KeyPressEventArgs e)
    {
        if (IsDecimal)
        {
            // means only one . decimal dot allow 
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && (Control.Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        else
        {
            // means only integer value , not decimal.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }

    public static string GetConnectionStringValues(string cnnStr, string ColumnValue)
    {
        dynamic re = new System.Text.RegularExpressions.Regex(ColumnValue + "=");
        dynamic m = re.Match(cnnStr);
        int i = cnnStr.IndexOf(";", m.Index) - (m.Index + m.Length);
        if (i > 0)
        {
            return cnnStr.Substring(m.Index + m.Length, i);
        }
        else
        {
            return cnnStr.Substring(m.Index + m.Length);
        }
    }
    public static void SetReportDefaultParameter(ref CrystalDecisions.CrystalReports.Engine.ReportDocument document)
    {
        try
        { 
            if (document.ParameterFields["CName"] != null)
            {
                document.SetParameterValue("CName", MainForm.globelInfo.Rows[0]["Company"].ToString());
            }
            if (document.ParameterFields["PoweredBy"] != null)
            {
                document.SetParameterValue("PoweredBy", MainForm.globelInfo.Rows[0]["PoweredBy"].ToString());
            }
            if (document.ParameterFields["FooterText"] != null)
            {
                document.SetParameterValue("FooterText", MainForm.globelInfo.Rows[0]["FooterText"].ToString());
            }
        }
        catch (Exception ex)
        { 
        }
    }

    public Image Base64ToImage(string base64String)
    {
        // Convert Base64 String to byte[]
        byte[] imageBytes = Convert.FromBase64String(base64String);
        MemoryStream ms = new MemoryStream(imageBytes, 0,
          imageBytes.Length);

        // Convert byte[] to Image
        ms.Write(imageBytes, 0, imageBytes.Length);
        Image image = Image.FromStream(ms, true);
        return image;
    }
}

