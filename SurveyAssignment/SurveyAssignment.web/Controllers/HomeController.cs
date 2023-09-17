using Azure;
using Microsoft.AspNetCore.Mvc;
using SurveyAssignment.web.Data;
using SurveyAssignment.web.Entities;
using SurveyAssignment.web.Models;
using System.Diagnostics;
using System.Net;

namespace SurveyAssignment.web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        // localIPAddress 
        string hostName = Dns.GetHostName();
        string localIPAddress = Dns.GetHostByName(hostName).AddressList[0].ToString();

        // Dynamic IP addresses are assigned from a pool of available addresses, and they may change each time a user reconnects to the internet.
        string DynamicIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        bool hasVoted = _context.Response.Any(r => r.UserIpAddress == localIPAddress);

        if (hasVoted)
        {
            // If the user has already voted, redirect them to another action.
            return RedirectToAction("AlreadyVotedAction");
        }
        return View();
    }

    public IActionResult AlreadyVotedAction()
    {
        var responses = _context.Response.ToList(); // Replace with your actual data retrieval logic

        var groupedResponses = responses
                .GroupBy(r => r.Option)
                .Select(group => new GroupedResponseModel
                {
                    Option = group.Key,
                    Count = group.Count()
                })
                .ToList();


        return View(groupedResponses);
    }


    [HttpPost]
    public ActionResult RecordResponse(string question, string option)
    {

        //for example, a hotel probably has a static IP address, but each individual device within its rooms would have a dynamic IP address.
        // On the internet, your home or office may be assigned a dynamic IP address by your ISP's DHCP server.
        // localIPAddress 
        string hostName = Dns.GetHostName();
        string localIPAddress = Dns.GetHostByName(hostName).AddressList[0].ToString();

        //dynamicIpAddress
        string userIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();

        // Save the response to the database.
        var response = new ResponseModel { Option = option, UserIpAddress = localIPAddress };
        _context.Response.Add(response);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

}