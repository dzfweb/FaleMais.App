using FaleMais.Models;
using FaleMais.Negocio.Models;
using FaleMais.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaleMais.Negocio
{
    public class Calculos
    {
        

        /// <summary>
        /// Realiza o calculo de Tarifa de acordo com os parametros enviados
        /// </summary>
        /// <param name="_pedido">Pedido de Calculo de Tarifa</param>
        /// <returns>Resultado do Calculo Detalhado</returns>
        public ResultadoCalculo CalcularTarifa(PedidoCalculo _pedido)
        {
            
            var resultado = new ResultadoCalculo();
            using (var repo = new Entities())
            {
                var listDDD = repo.DDD.Where(p => p.DDD_ATIVO).ToList();
                var objPlano = repo.PLANO.FirstOrDefault(p => p.PLANO_ID == _pedido.PlanoID) ?? new PLANO();
                var objOrigem = listDDD.Where(p => p.DDD_CODIGO == _pedido.Origem).FirstOrDefault() ?? new DDD();
                var objDestino = listDDD.Where(p => p.DDD_CODIGO == _pedido.Destino).FirstOrDefault() ?? new DDD();
                var objPreco = repo.PRECO.ToList().Where(p => p.PRECO_IDDESTINO == objDestino.DDD_ID && p.PRECO_IDORIGEM == objOrigem.DDD_ID).FirstOrDefault();

                #region Popular Dados Resultado
                resultado.Plano = new PLANO() { 
                    PLANO_ID = objPlano.PLANO_ID,
                    PLANO_MINUTOS = objPlano.PLANO_MINUTOS,
                    PLANO_DESCR = objPlano.PLANO_DESCR,
                    PLANO_PRECO = objPlano.PLANO_PRECO,
                    PLANO_ATIVO = objPlano.PLANO_ATIVO,
                    PLANO_TARIFAEXCEDENTE = objPlano.PLANO_TARIFAEXCEDENTE
                };

                resultado.Origem = new DDD()
                {
                    DDD_ID = objOrigem.DDD_ID,
                    DDD_ATIVO = objOrigem.DDD_ATIVO,
                    DDD_CODIGO = objOrigem.DDD_CODIGO
                };
                resultado.Destino = new DDD()
                {
                    DDD_ID = objDestino.DDD_ID,
                    DDD_ATIVO = objDestino.DDD_ATIVO,
                    DDD_CODIGO = objDestino.DDD_CODIGO
                };
                #endregion

                //Possui preço parametrizado
                if (objPreco != null && objPlano.PLANO_ATIVO)
                {
                    resultado.Detalhe.Sucesso = true;
                    decimal valorComPlano = 0;
                    decimal valorSemPlano = 0;
                    decimal tempoExcedido = _pedido.Tempo - objPlano.PLANO_MINUTOS;

                    valorComPlano = tempoExcedido > 0 ? (tempoExcedido * ((objPreco.PRECO_VALORMINUTO * (objPlano.PLANO_TARIFAEXCEDENTE /100)) + objPreco.PRECO_VALORMINUTO) ): 0;
                    valorSemPlano = _pedido.Tempo * objPreco.PRECO_VALORMINUTO;

                    resultado.Detalhe.Tempo = _pedido.Tempo;
                    resultado.Detalhe.ValorComPlano = valorComPlano;
                    resultado.Detalhe.ValorSemPlano = valorSemPlano;
                                        
                }
                else
                {
                    resultado.Detalhe.Sucesso = false;
                }
                

                return resultado;
            }
        }
    }


}
