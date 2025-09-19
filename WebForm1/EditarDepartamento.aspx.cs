using System;
using System.Web.UI;
using RestSharp;
using Newtonsoft.Json;
using System.Configuration;
using System.Collections.Generic;

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

        public class ApiValidationError
        {
            public string Title { get; set; }
            public int Status { get; set; } = 200;
            public Dictionary<string, string[]> Errors { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblErrores.Visible = false;
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
                var errorResponse = JsonConvert.DeserializeObject<ApiValidationError>(response.Content);
                if (errorResponse != null && errorResponse.Errors != null)
                {
                    lblErrores.Text = "<ul class='list-unstyled'>";
                    foreach (var fieldError in errorResponse.Errors)
                    {
                        foreach (var message in fieldError.Value)
                        {
                            lblErrores.Text += $"<li><b>{fieldError.Key}</b>: {message}</li>";
                        }
                    }
                    lblErrores.Text += "</ul>";
                    lblErrores.Visible = true;
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Departamentos.aspx");
        }
    }
}