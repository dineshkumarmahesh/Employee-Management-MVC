using DataAccessLayer.Model;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: EmployeeController

        EmployeeRepository obj;

        public EmployeeController()
        {
            obj = new EmployeeRepository();
        }
        public ActionResult List()
        {
            try
            {
                return View("List", obj.GetEmployeeData());
            }
            catch(SqlException e)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int Empid)
        {
            try
            {
                var result = obj.GetEmployeeDataById(Empid);
                return View("Details",result);
            }
            catch (SqlException e)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            try
            {
                return View("create",new EmployeeModel());
            }
            catch (SqlException e)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeModel emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    obj.InsertEmployeeData(emp);
                    return RedirectToAction(nameof(List));
                }
                else
                {
                    return View("Create", emp);
                }
            }
            catch (SqlException e)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int Empid)
        {
            try
            {
                var result = obj.GetEmployeeDataById(Empid);
                return View("Edit",result);
            }
            catch (SqlException e)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Empid, EmployeeModel Emp)
        {
            try
            {
                obj.UpdateEmployeeData(Emp);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int Empid)
        {
            try
            {
                var result = obj.GetEmployeeDataById(Empid);
                return View("Delete",result);
            }
            catch (SqlException e)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(int Empid)
        {
            try
            {
                obj.DeleteEmployeeData(Empid);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View("error");
            }
        }
    }
}
