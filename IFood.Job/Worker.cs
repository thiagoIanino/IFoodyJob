using IFoody.Job.Repositories;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IFood.Job
{
    public class Worker : IHostedService, IDisposable
    {
        private Timer _timer = null!;


        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
            TimeSpan.FromSeconds(15));

            return Task.CompletedTask;
        }

        private void DoWork(object? state)
        {
            var statusavaliacaoService = new StatusAvaliacaoRepository();

            var rows = statusavaliacaoService.AtualizarSituacaoAvaliacaoRotina();
            if(rows == 1)
            {
                statusavaliacaoService.DeletarAvaliacaoPadraoRestaurante();
            }
            Console.WriteLine("Foi");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
