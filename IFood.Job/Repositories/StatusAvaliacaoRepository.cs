using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IFoody.Job.Repositories
{
    public class StatusAvaliacaoRepository : BaseRepository
    {
        const string ATUALIZAR_STATUS_AVALIACAO_EXECUTE = "update StatusAvaliacaoRestaurante set [status] = 1 where idRestaurante in (select r.id  from Restaurante r join Avaliacao a on r.id = a.idRestaurante join StatusAvaliacaoRestaurante s on r.id = s.idRestaurante where s.[status] = 0 GROUP by r.id HAVING count(a.id)>5)";
        const string DELETAR_AVALIACAO_PADRAO_RESTAURANTE_EXECUTE = "delete Avaliacao from Avaliacao a join StatusAvaliacaoRestaurante s on a.idRestaurante = s.idRestaurante where s.[status] = 1 and a.idCliente = '79e0480a-a50c-4b76-aef9-f1cb29f67a7e'";

        public int AtualizarSituacaoAvaliacaoRotina()
        {
            return Executar(ATUALIZAR_STATUS_AVALIACAO_EXECUTE, null);
        }

        public int DeletarAvaliacaoPadraoRestaurante()
        {
            return Executar(DELETAR_AVALIACAO_PADRAO_RESTAURANTE_EXECUTE, null);
        }
    }
}
