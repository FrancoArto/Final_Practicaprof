using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface ICouponsRepository
    {
        Coupon Add(Coupon coupon);

        bool Delete(int couponId);

        Coupon GetCouponById(int couponId);
    }
}
