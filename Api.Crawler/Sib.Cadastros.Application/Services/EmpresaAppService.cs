using AutoMapper;
using Sib.Cadastros.Application.Models;
using Sib.Cadastros.Domain;
using Sib.Cadastros.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Sib.Cadastros.Application.Services
{
    public class EmpresaAppService : IEmpresaAppService
    {
        private readonly IMapper _mapper;
        private readonly IEmpresaService _empresaService;

        public EmpresaAppService(IMapper mapper, IEmpresaService empresaService)
        {
            this._mapper = mapper;
            this._empresaService = empresaService;
        }

        public async Task<int> Adicionar(EmpresaModel empresaModel)
        {
            var empresa = _mapper.Map<Empresa>(empresaModel);
            if (await _empresaService.Adicionar(empresa))
            {
                return empresa.Id;
            }
            return 0;
        }

        public async Task<EmpresaModel> ObterPeloCnpj(string cnpj)
        {

            var empresa = await _empresaService.ObterPeloCnpj(cnpj);
            var model = _mapper.Map<EmpresaModel>(empresa);
            return model;
        }

        public async Task<IEnumerable<EmpresaModel>> ObterTodos()
        {
            var empresas = await _empresaService.ObterTodos();
            var models = _mapper.Map<IEnumerable<EmpresaModel>>(empresas);
            return models;
        }
    }
}
