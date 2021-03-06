﻿// Copyright (c) 2020 Bitcoin Association

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;

namespace MerchantAPI.APIGateway.Rest
{
  public static class ExtensionMethods
  {

    public static BadRequestObjectResult ReturnBadRequestIfInvalid(this ControllerBase controller, IValidatableObject obj)
    {
      var vc = new ValidationContext(obj);

      return controller.ToBadRequest(obj.Validate(vc).ToArray());

    }

    public static BadRequestObjectResult ToBadRequest(this ControllerBase controller, ValidationResult[] errors)
    {
      if (!errors.Any())
      {
        return null;
      }

      var problemDetail = controller.ProblemDetailsFactory.CreateProblemDetails(controller.HttpContext, (int)HttpStatusCode.BadRequest);
      problemDetail.Title = string.Join(" ", errors.Select(x => x.ErrorMessage));
      return controller.BadRequest(problemDetail);
    }
  }
}
