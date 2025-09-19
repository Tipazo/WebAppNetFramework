using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm1
{
    public partial class SiteMaster : MasterPage
    {
        string apiPerfilesUrl = ConfigurationManager.AppSettings["ApiPerfilesUrl"];

        protected void Page_Load(object sender, EventArgs e)
        {
            {
                if (!IsPostBack)
                {
                    CheckApiStatus();
                }
            }
        }

        private void CheckApiStatus()
        {
            try
            {
                var client = new RestClient(apiPerfilesUrl.Replace("api", ""));
                var request = new RestRequest(string.Empty, Method.Get);

                var response = client.Execute(request);

                if (!response.IsSuccessful)
                {
                    lblApiStatus.Text = "⚠️ API de PERFILES, S. A no responde, revisar conexión";
                    lblApiStatus.CssClass = "alert alert-warning";
                }
            }
            catch
            {
                lblApiStatus.Text = "❌ API de PERFILES, S. A no responde, revisar conexión";
                lblApiStatus.CssClass = "alert alert-danger";
            }
        }
    }
}