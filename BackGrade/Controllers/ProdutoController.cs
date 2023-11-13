﻿using BackGrade.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackGrade.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ReclameAquiAPI _reclameAquiAPI;
        private readonly ChatGPTAPI _chatGPTAPI;

        public ProdutoController(ReclameAquiAPI reclameAquiAPI, ChatGPTAPI chatGPTAPI)
        {
            _reclameAquiAPI = reclameAquiAPI;
            _chatGPTAPI = chatGPTAPI;
        }


            public async Task<IActionResult> Detalhes(string nome)
            {
                // Lógica para obter avaliações do Reclame Aqui
                var avaliacoes = await _reclameAquiAPI.ObterAvaliacoesAsync(nome);

                // Criar o modelo do produto
                var produtoModel = new ProdutoModel
                {
                    Nome = nome,
                    Avaliacoes = avaliacoes
                };

            // Pergunta ao ChatGPT com base nas avaliações
            produtoModel.RespostaChatGPT = await _chatGPTAPI.ObterRespostaAsync(avaliacoes, produtoModel.PerguntaChatGPT);


            // Passar o modelo para a View
            return View("Detalhes", produtoModel);
            }

          
        }
    }


