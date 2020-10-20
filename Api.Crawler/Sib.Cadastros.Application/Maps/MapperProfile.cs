using AutoMapper;
using Sib.Cadastros.Application.Models;
using Sib.Cadastros.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sib.Cadastros.Application.Maps
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<EmpresaModel, Empresa>().ReverseMap();
            CreateMap<Endereco, EnderecoModel>().ReverseMap();
            CreateMap<Cidade, CidadeModel>().ReverseMap();
        }
    }
}
