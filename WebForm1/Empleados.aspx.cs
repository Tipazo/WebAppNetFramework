using System;
using System.Web.UI;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;
using System.Web.UI.WebControls;
using System.Configuration;

namespace WebForm1
{
    public partial class Empleados : System.Web.UI.Page
    {
        string apiPerfilesUrl = ConfigurationManager.AppSettings["ApiPerfilesUrl"];

        protected List<Department> DepartamentosList = new List<Department>();

        protected List<Employee> EmployeesList = new List<Employee>();

        public class Employee
        {
            public int employeeID { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string dpi { get; set; }
            public string birthDate { get; set; }
            public string age { get; set; }
            public string gender { get; set; }
            public string hireDate { get; set; }
            public string antiguedad { get; set; }
            public string status { get; set; }
            public string address { get; set; }
            public string nit { get; set; }
            public string departmentName { get; set; }
            public string departmentStatus { get; set; }
        }

        public class Department
        {
            public int departmentID { get; set; }
            public string name { get; set; }
            public string status { get; set; }
        }

        public class APiResponseEmployee
        {
            public List<Employee> data { get; set; }
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
                EmployeesList = GetAllEmployees();
                rptEmpleados.DataSource = EmployeesList;
                rptEmpleados.DataBind();

                DepartamentosList = GetAllDepartments();
                ddlFiltroDepartamento.DataSource = DepartamentosList;
                ddlFiltroDepartamento.DataTextField = "Name";
                ddlFiltroDepartamento.DataValueField = "DepartmentID";
                ddlFiltroDepartamento.DataBind();

                ddlFiltroDepartamento.Items.Insert(0, new ListItem("-- Seleccione --", string.Empty));
            }
        }

        private List<Employee> GetAllEmployees(string departamentoId = null, string status = null, string fechaInicio = null, string fechaFin = null)
        {
            try
            {
                var client = new RestClient($@"{apiPerfilesUrl}/Employee?departmentId={departamentoId}&status={status}&startDate={fechaInicio}&endDate={fechaFin}");
                var request = new RestRequest(string.Empty, Method.Get);
                request.RequestFormat = DataFormat.Json;

                var result = client.Execute(request);
                if (result.IsSuccessful && !string.IsNullOrEmpty(result.Content))
                {
                    var departamentos = JsonConvert.DeserializeObject<APiResponseEmployee>(result.Content);

                    return departamentos.data ?? new List<Employee>();
                }
            }
            catch (Exception ex)
            {
                // Manejo de Excepciones ex.message
            }

            return new List<Employee>();
        }

        protected void rptEmpleados_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                string id = e.CommandArgument.ToString();
                Response.Redirect($"EditarEmpleado.aspx?id={id}");
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearEmpleado.aspx");
        }


        private List<Department> GetAllDepartments()
        {
            try
            {
                var client = new RestClient($@"{apiPerfilesUrl}/Department");
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
                // Manejo de Excepciones ex.message
            }

            return new List<Department>();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                string status = ddlFiltroEstado.SelectedValue; 
                string departamentoIdStr = ddlFiltroDepartamento.SelectedValue; 
                string fechaInicio = txtFiltroFechaInicio.Text; 
                string fechaFin = txtFiltroFechaFin.Text; 

                var empleados = GetAllEmployees(departamentoIdStr, status, fechaInicio, fechaFin);
               
                rptEmpleados.DataSource = empleados;
                rptEmpleados.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("Error al filtrar empleados: " + ex.Message);
            }
        }

    }
}