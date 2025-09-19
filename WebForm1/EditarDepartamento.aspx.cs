using System;
using System.Web.UI;
using RestSharp;
using Newtonsoft.Json;
using System.Configuration;

namespace WebForm1
{
    public partial class EditarDepartamento : System.Web.UI.Page
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
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(id))
                {
                    CargarDepartamento(id);
                }
            }
        }


        private void CargarDepartamento(string id)
        {
            var client = new RestClient($@"{apiPerfilesUrl}/Department");
            var request = new RestRequest($"{id}", Method.Get);

            var result = client.Execute(request);

            if (result.IsSuccessful && !string.IsNullOrEmpty(result.Content))
            {
                var depto = JsonConvert.DeserializeObject<APiResponse>(result.Content);

                if (depto != null)
                {
                    hdnId.Value = depto.data.departmentID.ToString();
                    txtNombre.Text = depto.data.name;
                    rblStatus.Text = depto.data.status;
                }
            }
        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            var id = hdnId.Value;
            var client = new RestClient($@"{apiPerfilesUrl}/Department");
            var request = new RestRequest(string.Empty, Method.Put);

            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            request.AddParameter("DepartmentID", id);
            request.AddParameter("Name", txtNombre.Text);
            request.AddParameter("Status", rblStatus.SelectedValue);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                Response.Redirect("Departamentos.aspx");
            }
            else
            {
                Response.Write("Error al guardar: " + response.Content);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Departamentos.aspx");
        }
    }
}