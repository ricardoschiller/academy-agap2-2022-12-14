using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;

namespace Agap2IT.Academy.SuperMarket.Data.Models;

public partial class Cart
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}

	
	//	○ Para criar uma migração, usamos o comando: Add-Migration CreatedAt -Project Agap2IT.Labs.Arq.Data
	//	○ Para aplicar as migrações, usamos: Update-Database -Project Agap2IT.Labs.Arq.Data
	//• Se já existir a base de dados, existia a opção IgnoreChanges, que foi descontinuada.O comando era:
	//	○ Add-Migration InitialCreate -Project Agap2IT.Labs.Arq.Data -IgnoreChanges
	//	○ Agora já não é possível fazer assim







