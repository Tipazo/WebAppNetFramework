using System;
using System.Web.UI;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;
using System.Web.UI.WebControls;
using System.Configuration;

namespace WebForm1
{
    public partial class CrearEmpleado : System.Web.UI.Page
    {
        string apiPerfilesUrl = ConfigurationManager.AppSettings["ApiPerfilesUrl"];
        protected List<Department> DepartamentosList = new List<Department>();

        public class Department
        {
            public int departmentID { get; set; }
            public string name { get; set; }
            public string status { get; set; }
        }

        public class APiResponse
        {
            public List<Department> data { get; set; }
            public string message { get; set; }
            public int code { get; set; } = 1;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DepartamentosList = GetAllDepartments();
                ddlDepartamentos.DataSource = DepartamentosList;
                ddlDepartamentos.DataTextField = "Name";
                ddlDepartamentos.DataValueField = "DepartmentID";
                ddlDepartamentos.DataBind();

                ddlDepartamentos.Items.Insert(0, new ListItem("-- Seleccione --", string.Empty));
            }
        }

        private List<Department> GetAllDepartments()
        {
            try
            {
                var client = new RestClient($@"{apiPerfilesUrl}/Department?status=Active");
                var request = new RestRequest(string.Empty, Method.Get);
                request.RequestFormat = DataFormat.Json;

                var result = client.Execute(request);
                if (result.IsSuccessful && !string.IsNullOrEmpty(result.Content))
                {
                    var departamentos = JsonConvert.DeserializeObject<APiResponse>(result.Content);

                    return departamentos.data ?? new List<Department>();
                }
            }
            catch (Exception ex)
            {
                // Manejo de Excepciones ex.message
            }

            return new List<Department>();
        }


        protected void btnCrear_Click(object sender, EventArgs e)
        {
            var client = new RestClient($@"{apiPerfilesUrl}/Employee");
            var request = new RestRequest(string.Empty, Method.Post);

            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            request.AddParameter("FirstName", txtFirstName.Text);
            request.AddParameter("LastName", txtLastname.Text);
            request.AddParameter("DPI", txtDPI.Text);
            request.AddParameter("BirthDate", txtBirthDay.Text);
            request.AddParameter("Gender", rblGenre.SelectedValue);
            request.AddParameter("HireDate", txtHideDate.Text);
            request.AddParameter("Status", rblStatus.SelectedValue);
            request.AddParameter("NIT", txtNit.Text);
            request.AddParameter("Address", txtAddress.Text);
            request.AddParameter("DepartmentID", ddlDepartamentos.SelectedValue);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                Response.Redirect("Empleados.aspx");
            }
            else
            {
                Response.Write("Error al crear: " + response.Content);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Empleados.aspx");
        }
    }
}