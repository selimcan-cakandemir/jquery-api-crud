using _100_WebApiCrud.Models.Entity;
using _100_WebApiCrud.Models.Entity.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _100_WebApiCrud.Controllers
{
    public class EmployeesController : ApiController
    {
        EmployeeDbContext context = new EmployeeDbContext();

 

        public HttpResponseMessage GetEmployees()
        {
            return Request.CreateResponse(HttpStatusCode.OK, context.Employees.ToList());
        }

        public HttpResponseMessage DeleteEmployee(int id)
        {
            try
            {
                var employee = context.Employees.Find(id);
                context.Employees.Remove(employee);
                context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, GetEmployees());
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
            
        }

        public HttpResponseMessage PostEmployee([FromBody] Employee employee)
        {
            //checks to see if the attributes we have set on the class side are being met, like requirements that the property not be empty
            if(ModelState.IsValid)
            {
                context.Employees.Add(employee);
                context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.Created, employee);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "doldurulması zorunlu alanlar mevcut");
            }
        }

        //public HttpResponseMessage PutEmployee(Employee employee)
        //{
        //    try
        //    {
        //        Employee updated = context.Employees.Find(employee.EmployeeId);
        //        context.Entry(updated).CurrentValues.SetValues(employee);
        //        context.SaveChanges();
        //        return Request.CreateResponse(HttpStatusCode.OK, "Veri güncellendi");
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
        //    }
        //}

        public IHttpActionResult PutEmployee(Employee employee)
        {
            try
            {
                Employee updated = context.Employees.Find(employee.EmployeeId);
                context.Entry(updated).CurrentValues.SetValues(employee);
                context.SaveChanges();
                return Json(GetEmployees());
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
