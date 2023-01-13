using System.Net;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Core.Model;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace EmailAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CurrencyController
{
    private ICurrencyService _currencyService;

    public CurrencyController(ICurrencyService currencyService)
    {
        _currencyService = currencyService;
    }


    [HttpGet]
    public async Task<string> Get()
    {
        return "CurrencyController Succesfull Reached.";
    }

    [HttpGet]
    public async Task GetCurrencyData()
    {
        using (var client = new WebClient())
        {
            var xmlResponse = await client.DownloadStringTaskAsync("https://www.tcmb.gov.tr/kurlar/today.xml");
            XDocument doc = XDocument.Parse(xmlResponse);
            var ns = doc.Root.Name.Namespace;

            var currencyUSD = doc.Descendants(ns + "Currency").First(x => x.Attribute("Kod").Value == "USD")
                .Element(ns + "ForexBuying").Value;

            GN_CURRENCY item = new GN_CURRENCY()
            {
                CURRENCY_CODE = "USD",
                CURRENCY_NAME = "DOLAR",
                CURRENCY_VALUE = Convert.ToDecimal(currencyUSD),
            };
            var result = await _currencyService.AddAsync(item);
        }
    }
}