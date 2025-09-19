using System;
using Newtonsoft.Json;
using System.Configuration;
using RestSharp;

namespace WebForm1
{
    public partial class CrearDepartamento : System.Web.UI.Page
    {
        string apiPerfilesUrl = ConfigurationManager.AppSettings["ApiPerfilesUrl"];

        public class Department
        {
            public int departmentID { get; set; }
            public string name { get; set; }
            public string status { get; set; }
        }

        public class APiResponse
        {
            public Department data { get; set; }
            public Error error { get; set; } = new Error();
        }

        public class Error
        {
            public int code { get; set; } = 0;
            public string message { get; set; } = "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            var client = new RestClient($@"{apiPerfilesUrl}/Department");
            var request = new RestRequest(string.Empty, Method.Post);

            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            request.AddParameter("Name", txtNombre.Text);
            request.AddParameter("Status", rblStatus.SelectedValue);

            var response = client.Execute(request);

            if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
            {
                var result = JsonConvert.DeserializeObject<APiResponse>(response.Content);

                if(result.error.code == 0)
                {
                    Response.Redirect("Departamentos.aspx");
                } else
                {
                    Response.Write("Error al crear: " + result.error.message);
                }

            } else {
                Response.Write("Error al crear: " + response.Content);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Departamentos.aspx");
        }
    }
}
