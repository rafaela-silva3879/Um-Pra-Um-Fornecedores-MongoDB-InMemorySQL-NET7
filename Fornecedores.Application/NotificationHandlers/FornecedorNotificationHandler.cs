using Fornecedores.Application.Notifications;
using Fornecedores.Domain.Interfaces.Cache;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fornecedores.Application.NotificationHandlers
{
    internal class FornecedorNotificationHandler : INotificationHandler<FornecedorNotification>
    {
        private readonly IFornecedorCache? _fornecedorCache;

        public FornecedorNotificationHandler(IFornecedorCache? fornecedorCache)
        {
            _fornecedorCache = fornecedorCache;
        }

        public Task Handle(FornecedorNotification notification,
CancellationToken cancellationToken)
        {
            switch (notification.Notification)
            {
                case ActionNotification.Create:
                    _fornecedorCache.Add(notification.Fornecedor);
                    break;
                case ActionNotification.Update:
                    _fornecedorCache.Update(notification.Fornecedor);
                    break;
                case ActionNotification.Delete:
                    _fornecedorCache.Delete(notification.Fornecedor);
                    break;
            }
            return Task.CompletedTask;
        }
    }
}
