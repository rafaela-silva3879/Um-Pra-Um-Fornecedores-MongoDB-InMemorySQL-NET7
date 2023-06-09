using Fornecedores.Domain.Interfaces.Cache;
using Fornecedores.Application.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fornecedores.Application.NotificationHandlers
{
    internal class EnderecoNotificationHandler : INotificationHandler<EnderecoNotification>
    {
        private readonly IEnderecoCache? _EnderecoCache;

        public EnderecoNotificationHandler(IEnderecoCache? EnderecoCache)
        {
            _EnderecoCache = EnderecoCache;
        }

        public Task Handle(EnderecoNotification notification,
CancellationToken cancellationToken)
        {
            switch (notification.Notification)
            {
                case ActionNotification.Create:
                    _EnderecoCache.Add(notification.Endereco);
                    break;
                case ActionNotification.Update:
                    _EnderecoCache.Update(notification.Endereco);
                    break;
                case ActionNotification.Delete:
                    _EnderecoCache.Delete(notification.Endereco);
                    break;
            }
            return Task.CompletedTask;
        }
    }
}
