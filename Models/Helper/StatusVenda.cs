using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Models
{
    public class StatusVenda
    {
        public static List<string> GetAll ()
        {
            return new List<string>{
                "Aguardando Pagamento",
                "Pagamento Aprovado",
                "Enviado para Transportadora",
                "Entregue",
                "Cancelado"

            };

        }

        public static List<string> GetEditStatus (string status)
        {
            if(status == "Aguardando Pagamento"){

                return new List<string>{
                    "Aguardando Pagamento",
                    "Pagamento Aprovado",
                    "Cancelado"
                };
            }

            else if(status == "Pagamento Aprovado"){

                return new List<string>{
                    "Pagamento Aprovado",
                    "Enviado para Transportadora",
                    "Cancelado"
                };
            }

            else if(status == "Cancelado"){

                return new List<string>{
                    "Cancelado"
                };
            }

            else if(status == "Enviado para Transportadora"){

                return new List<string>{
                    "Enviado para Transportadora",
                    "Entregue"
                };
            }

            else {
                return new List<string>{
                    "Entregue"
                };
            }
        }
    }
}