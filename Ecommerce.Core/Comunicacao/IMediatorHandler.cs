

using Ecommerce.Core.Messages;
using Ecommerce.Core.Messages.Notificacao;
using System.Threading.Tasks;

namespace Ecommerce.Core.Comunicacao
{
    public interface IMediatorHandler
    {
        Task<bool> EnviarComando<T>(T comando) where T : Command;
        Task PublicarNotificacao<T>(T notificacao) where T : DomainNotification;
    }
}