using Application.DTO;
using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IAsigneeService
    {
        AsigneeViewModel GetAsigneesViewModel();
        List<AsigneeDTO> GetAsignees();
        AsigneeDTO Save(AsigneeDTO asignee);
        AsigneeDTO Get(int asigneeId);
        void Delete(int asigneeId);
    }
}
