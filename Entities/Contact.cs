using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AtividadeAPI.Entities
{   
    //criar classe entity
    //criar context
    //configurar conexao no main e appsettings
    //vira tabela atraves do dotnet-ef migrations add CreationContactsTable
    //update tabela atraves dotnet-ef database update
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; } 
        public bool Active { get; set; }
    }
}
