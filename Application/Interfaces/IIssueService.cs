﻿using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IIssueService
    {
        IssueViewModel GetIssues();
    }
}
