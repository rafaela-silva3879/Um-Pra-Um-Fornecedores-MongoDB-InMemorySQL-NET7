﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fornecedores.Application.Notifications
{
    /// <summary>
    /// ENUM para definir quais os tipos de notificações serão disparados pelos 
    /// componentes Request Handlers.
    /// </summary>
    public enum ActionNotification
    {
        Create = 1,
        Update = 2,
        Delete = 3
    }
}
