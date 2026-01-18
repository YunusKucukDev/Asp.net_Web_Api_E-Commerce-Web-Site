using Dapper;
using Udemy.Discount.Context;
using Udemy.Discount.Dtos;

namespace Udemy.Discount.Services
{
    public class DiscountService : IDiscountService
    {

        private readonly DapperContext _contex;
        public DiscountService(DapperContext contex)
        {
            _contex = contex;
        }

        public async Task CreateCouponAsync(CreateCoupunDto createCoupunDto)
        {
            string query = "insert into Coupons(Code,Rate,IsActive,ValidDate) values (@code,@rate,@isactive,@validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createCoupunDto.Code);
            parameters.Add("@rate", createCoupunDto.Rate);
            parameters.Add("@isActive", createCoupunDto.IsActive);
            parameters.Add("@validDate", createCoupunDto.ValidDate);
            using (var connection = _contex.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }

        public async Task DeleteCoupunAsync(int id)
        {
            string query = "Delete From Coupons where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("couponId", id);
            using (var connection = _contex.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResutCouponDto>> GetAllCouponAsync()
        {
            string query = "Select * From Coupons";
            using (var connection = _contex.CreateConnection())
            {
                var values = await connection.QueryAsync<ResutCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdCouponDto> GetByIdCouponAsync(int id)
        {
            string query = "Select * From Coupons Where CouponId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("couponId", id);
            using (var connection = _contex.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdCouponDto>(query,parameters);
                return values;
            }
        }

        public async Task<ResutCouponDto> GetCodeDetailByCodeAsync(string code)
        {
            string query = "Select * from Coupons Where Code=@code";
            var parameters = new DynamicParameters();
            parameters.Add("@code", code);
            using (var connection = _contex.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResutCouponDto>(query, parameters);
                return values;
            }
        }

        public async Task<int> GetDiscountCouponCount()
        {
            string query = "SELECT COUNT(*) FROM Coupons";
            using (var connection = _contex.CreateConnection())
            {
                var value = await connection.QuerySingleAsync<int>(query);
                return value;
            }
        }

        public async Task<int> GetDiscountCouponRate(string code)
        {
            string query = "SELECT Rate FROM Coupons WHERE Code = @code";

            var parameters = new DynamicParameters();
            parameters.Add("@code", code);

            using (var connection = _contex.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<int>(query, parameters);
                return value; // Kupon yoksa 0 döner
            }
        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            string query = @"Update Coupons 
                     Set Code = @code,
                         Rate = @rate,
                         IsActive = @isActive,
                         ValidDate = @validDate 
                     Where CouponId = @couponId";

            var parameters = new DynamicParameters();
            parameters.Add("@code", updateCouponDto.Code);
            parameters.Add("@rate", updateCouponDto.Rate);
            parameters.Add("@isActive", updateCouponDto.IsActive);
            parameters.Add("@validDate", updateCouponDto.ValidDate);
            parameters.Add("@couponId", updateCouponDto.CouponId); 

            using (var connection = _contex.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

       
        
    }
}
