using System;
using System.Web.UI;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;
using System.Web.UI.WebControls;
using System.Configuration;

namespace WebForm1
{
    public partial class EditarEmpleado : System.Web.UI.Page
    {
        string apiPerfilesUrl = ConfigurationManager.AppSettings["ApiPerfilesUrl"];
        protected List<Department> DepartamentosList = new List<Department>();

        public class Employee
        {
            public int employeeID { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string dpi { get; set; }
            public string birthDate { get; set; }
            public string gender { get; set; }
            public string hireDate { get; set; }
            public string status { get; set; }
            public string address { get; set; }
            public string nit { get; set; }
            public int departmentID { get; set; }   
        }

        public class Department
        {
            public int departmentID { get; set; }
            public string name { get; set; }
            public string status { get; set; }
        }

        public class APiResponseEmployee
        {
            public Employee data { get; set; }
            public string message { get; set; }
            public int code { get; set; }
        }

        public class APiResponseDepartment
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

                string id = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(id))
                {
                    CargarEmpleado(id);
                }
            }
        }

        private List<Department> GetAllDepartments()
        {
            try
            {
                var client = new RestClient("https://localhost:7175/api/Department?status=Active");
                var request = new RestRequest(string.Empty, Method.Get);
                request.RequestFormat = DataFormat.Json;

                var result = client.Execute(request);
                if (result.IsSuccessful && !string.IsNullOrEmpty(result.Content))
                {
                    var departamentos = JsonConvert.DeserializeObject<APiResponseDepartment>(result.Content);

                    return departamentos.data ?? new List<Department>();
                }
            }
            catch (Exception ex)
            {
                // loguear si quieres
            }

            return new List<Department>();
        }

        private void CargarEmpleado(string id)
        {
            var client = new RestClient($@"{apiPerfilesUrl}/Employee");
            var request = new RestRequest($"{id}", Method.Get);

            var result = client.Execute(request);

            if (result.IsSuccessful && !string.IsNullOrEmpty(result.Content))
            {
                var depto = JsonConvert.DeserializeObject<APiResponseEmployee>(result.Content);

                if (depto != null)
                {
                    hfEmployeeID.Value = depto.data.employeeID.ToString();
                    txtFirstName.Text = depto.data.firstName;
                    txtLastname.Text = depto.data.lastName;
                    txtDPI.Text = depto.data.dpi;
                    txtBirthDay.Text = depto.data.birthDate;
                    txtHideDate.Text = depto.data.hireDate;
                    rblGenre.SelectedValue = depto.data.gender;
                    rblStatus.SelectedValue = depto.data.status;
                    txtNit.Text = depto.data.nit;
                    txtAddress.Text = depto.data.address;
                    ddlDepartamentos.SelectedValue = depto.data.departmentID.ToString();
                }
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            var id = hfEmployeeID.Value;
            var client = new RestClient($@"{apiPerfilesUrl}/Employee");
            var request = new RestRequest(string.Empty, Method.Put);

            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            request.AddParameter("EmployeeID", id);
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
                Response.Write("Error al guardar: " + response.Content);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Empleados.aspx");
        }

    }
}