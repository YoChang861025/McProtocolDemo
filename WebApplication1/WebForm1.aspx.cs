using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Station;
using ClassLibrary5;
using System.Threading;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SV report = new SV();
            report.getVolue();
           
            Label1.Text = report.temperatue.ToString();
            Label2.Text = report.pa.ToString();
            Label3.Text = report.rotationX.ToString();
            Label4.Text = report.rotationY.ToString();
            Label5.Text = report.rotationZ.ToString();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SV report = new SV();
           
                report.getVolue();
                Label1.Text = report.temperatue.ToString("#0.00000");
                Label2.Text = report.pa.ToString("#0.00000");
                Label3.Text = report.rotationX.ToString();
                Label4.Text = report.rotationY.ToString();
                Label5.Text = report.rotationZ.ToString();
     
        }
    }
}