using Microsoft.AspNetCore.JsonPatch.Operations;
//using Microsoft.OpenApi.Models;
//using Microsoft.OpenApi.Models;
//using Ninject.Parameters;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoLivraria.OData.Swagger
{
    public class SwaggerFileOperationFilter : IOperationFilter
    {
        public void Apply(Swashbuckle.AspNetCore.Swagger.Operation operation, OperationFilterContext context)
        {
            if (operation.OperationId == "Post")
            {
                operation.Parameters = new List<IParameter>
                {
                    new NonBodyParameter
                    {
                        Name = "myFile",
                        Required = true,
                        Type = "file",
                        In = "formData"
                    }
                };
            }
        }
        //public void Apply(OpenApiOperation operation, OperationFilterContext context)
        //{
        //    if (operation.OperationId == "Post")
        //    {
        //        operation.Parameters = new List<IParameter>
        //            {
        //                new NonBodyParameter
        //                {
        //                    Name = "myFile",
        //                    Required = true,
        //                    Type = "file",
        //                    In = "formData"
        //                }
        //            };
        //    }
        //}
    }
}
