using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeTarefa.Dominio.Entitidades
{
    public class Usuario : EntityBase.EntityBase
    {
        public string UserName { get;private set; }
        public string Senhar { get; private set; }

        public  Usuario(string username ,string senhar)
        {
            UserName = username;
            Senhar = senhar;
        }
    }
}
