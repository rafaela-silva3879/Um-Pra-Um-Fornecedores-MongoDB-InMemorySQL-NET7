using Fornecedores.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fornecedores.Application.Notifications
{
    public class EnderecoNotification : INotification
    {
        public Endereco? Endereco { get; set; }
        public ActionNotification? Notification { get; set; }
    }
}
