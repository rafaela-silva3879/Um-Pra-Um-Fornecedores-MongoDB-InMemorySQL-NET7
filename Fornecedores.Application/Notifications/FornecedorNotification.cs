using Fornecedores.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fornecedores.Application.Notifications
{
    public class FornecedorNotification : INotification
    {
        public Fornecedor? Fornecedor { get; set; }
        public ActionNotification? Notification { get; set; }
    }
}
