﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;

namespace Client
{
    public interface ITesteesListForm
    {
        TesteesListPresenter Presenter { get; set; }
        void CloseForm();
        void SetBindings(List<Testee> testees);
        bool NotifyUnsavedData();
    }
}
