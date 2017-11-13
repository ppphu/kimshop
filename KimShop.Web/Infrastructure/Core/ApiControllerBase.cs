using KimShop.Model.Models;
using KimShop.Service;
using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KimShop.Web.Infrastructure.Core
{
    public class ApiControllerBase : ApiController
    {
        private IErrorService _errorSevice;
        
        public ApiControllerBase(IErrorService errorSevice)
        {
            _errorSevice = errorSevice;
        }

        protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage requestMessage, Func<HttpResponseMessage> function)
        {
            HttpResponseMessage response = null;
            try
            {
                response = function.Invoke();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error.");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                    }
                }
                ErrorLog(ex);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.InnerException.Message);
            }
            catch (DbUpdateException dbEx)
            {
                ErrorLog(dbEx);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, dbEx.InnerException.Message);
            }
            catch (Exception ex)
            {
                ErrorLog(ex);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest,ex.Message); 
            }
            return response;
        }
        private void ErrorLog(Exception ex)
        {
            try
            {
                Error error = new Error();
                error.Message = "";
                error.StackTrace = "";
                error.CreatedDate = DateTime.Now;
                _errorSevice.Create(error);
                _errorSevice.Save();
            }
            catch
            {
                
            }
        }
    }
}