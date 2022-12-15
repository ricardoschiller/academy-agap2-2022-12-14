// See https://aka.ms/new-console-template for more information
using Agap2IT.Academy.SuperMarket.Data.Models;
using Microsoft.VisualBasic;
using Agap2IT.Academy.SuperMarket.Dal;
using Agap2IT.Academy.SuperMarket.Business;

Console.WriteLine("Hello, World!");


var bo = new ProductsBO();

var opResult = await bo.GetClientAsync(Guid.Parse("873B0989-1E2F-4D11-BA6B-3857B3BCFCAE"));

if (opResult.HasSucceeded)
{

}
else
{

}




Console.ReadLine();




