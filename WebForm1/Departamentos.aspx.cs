using System;
using System.Web.UI;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;
using System.Web.UI.WebControls;
using System.Configuration;

namespace WebForm1
{
    public partial class Departamentos : Page
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
                rptDepartamentos.DataSource = DepartamentosList;
                rptDepartamentos.DataBind();
            }
        }

        protected void rptDepartamentos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                string id = e.CommandArgument.ToString();
                Response.Redirect($"EditarDepartamento.aspx?id={id}");
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearDepartamento.aspx");
        }

        private List<Department> GetAllDepartments()
        {
            try
            {
                var client = new RestClient($@"{apiPerfilesUrl}/Department");
                var request = new RestRequest(string.Empty,Method.Get); 
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

    }
}