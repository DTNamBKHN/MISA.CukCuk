using MISA.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BL.Exceptions
{
    public class GuardException<MISAEntity>:Exception
    {
        public GuardException (string msg, MISAEntity customer): base(msg)
        {
            this.Data.Add(1, customer);
        }
    }
}
