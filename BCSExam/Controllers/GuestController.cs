using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BCSExam.Interface;
using BCSExam.Model;
using BCSExam.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BCSExam.Controllers
{
    [Route("api/NPS/[action]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestRepo _context;
        public GuestController(IGuestRepo context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Customer>> GetAll()
        {
            try
            {
                var result = await _context.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetSpoken()
        {

            try
            {
                var result = await _context.GetSpoken();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

        }

        [HttpGet]
        public async Task<ActionResult<Customer>> Customers(string parkCode, string arriving)
        {

            if (parkCode == null || arriving == null) return BadRequest("You must filter the contents of the talktoguests table by finding only records matching parkCode and arrived (exact string match)");
        
            try
            {
                var result = await _context.Customers(parkCode, arriving);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }


        }

        [HttpPost]
        public async Task<ActionResult> Response(SpokenToGuest spoken)
        {

            if (spoken.ResId == null || spoken.UserEmail == null) return BadRequest("Invalid parameters are provided");

            try
            {
                var result = await _context.Response(spoken);

                if (result.GetType().GetProperty("Error") != null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, result);
                }
                else
                {
                    return Ok();
                }
            
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

        }

    }
}