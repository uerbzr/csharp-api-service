using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using workshop.service;
using workshop.service.interfaces;
using workshop.wwwapi.DTO;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace workshop.wwwapi.Endpoints
{
    public static class CalculatorEndpoints
    {
        public static void ConfigureCalculatorEndpoints(this WebApplication app)
        {
            var calculations = app.MapGroup("/calculations");

            calculations.MapGet("/", GetAll);
            calculations.MapGet("/queued", GetQueued);
            calculations.MapGet("/queue/{a}/{b}", QueueItem);
            calculations.MapGet("/calculate", Calculate);



        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll(ICalculatorService calculatorService, IMapper mapper)
        {
            var calculations = await calculatorService.GetAll();   
            
            var response = mapper.Map<List<CalculationDTO>>(calculations);
            
            return TypedResults.Ok(response);
            
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetQueued(ICalculatorService calculatorService, IMapper mapper)
        {
            var calculations = await calculatorService.GetQueued();

            var response = mapper.Map<List<CalculationDTO>>(calculations);

            return TypedResults.Ok(response);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> QueueItem(ICalculatorService calculatorService, IMapper mapper, int a, int b)
        {
            return await calculatorService.QueueItem(a, b) ? TypedResults.Ok() : TypedResults.BadRequest();
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> Calculate(ICalculatorService calculatorService, IMapper mapper)
        {
            return await calculatorService.Calculate() ? TypedResults.Ok("Done") : TypedResults.BadRequest("failed");
        }
    }
}
