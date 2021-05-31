using Application.DTO;
using Application.Interfaces;
using Application.Interfaces.API;
using Application.ViewModels;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class AsigneeService: IAsigneeService
    {

        private IAsigneeAPI _asigneeApi;
        public AsigneeService(IAsigneeAPI asigneeApi)
        {
            _asigneeApi = asigneeApi;
        }

        public void Delete(int asigneeId)
        {
            throw new NotImplementedException();
        }

        public AsigneeDTO Get(int asigneeId)
        {
            throw new NotImplementedException();
        }

        public List<AsigneeDTO> GetAsignees()
        {
            return (List<AsigneeDTO>)_asigneeApi.GetAll();
        }

        public AsigneeViewModel GetAsigneeViewModel()
        {
            throw new NotImplementedException();
        }

        public AsigneeDTO Save(AsigneeDTO asignee)
        {
            throw new NotImplementedException();
        }
    }
}
