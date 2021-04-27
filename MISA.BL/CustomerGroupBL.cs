using MISA.BL.Exceptions;
using MISA.Common.Entities;
using MISA.DL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BL
{
    public class CustomerGroupBL : BaseBL
    {
        protected override void Validate<MISAEntity>(MISAEntity entity)
        {
            throw new GuardException<CustomerGroup>("O zê", entity as CustomerGroup);
        }


    }
}
