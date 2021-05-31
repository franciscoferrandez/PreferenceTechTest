using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.API
{
    public interface IAsigneeAPI
    {
        IEnumerable<AsigneeDTO> GetAll();
    }
}
