// See https://aka.ms/new-console-template for more information
using Agap2IT.Academy.SuperMarket.Data.Models;
using Microsoft.VisualBasic;
using Agap2IT.Academy.SuperMarket.Dal;

Console.WriteLine("Hello, World!");



var productsDao = new ProductsDao();

var results = productsDao.GetProductsInClientShoppingCart(1);


Console.ReadLine();




